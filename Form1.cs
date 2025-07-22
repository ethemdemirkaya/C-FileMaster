using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace C_FileNameChanger
{
    
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public class FileItem
        {
            public string OriginalName { get; set; }
            public string NewName { get; set; }
            public string Status { get; set; }
            public string FullPath { get; set; }
        }
        private List<FileItem> _fileItems = new List<FileItem>();
        private List<Tuple<string, string>> _lastOperationHistory = new List<Tuple<string, string>>();

        public Form1()
        {
            InitializeComponent();
            SetupGridView();
            SetupEventHandlers();
            InitializeControlStates();
            cmbNumberPosition.Properties.Items.AddRange(new string[] { "Önek Olarak", "Sonek Olarak" });
            cmbNumberPosition.SelectedIndex = 0;
        }
        private void InitializeControlStates()
        {
            txtPrefix.Enabled = false;
            txtSuffix.Enabled = false;
            txtFind.Enabled = false;
            txtReplaceWith.Enabled = false;
            seStartNumber.Enabled = false;
            txtNumberPadding.Enabled = false;
            cmbNumberPosition.Enabled = false;
        }
        private void SetupGridView()
        {
            gridViewFiles.OptionsBehavior.AutoPopulateColumns = false;
            gridControlFiles.DataSource = _fileItems;

            gridViewFiles.Columns.AddField("OriginalName").Visible = true;
            gridViewFiles.Columns["OriginalName"].Caption = "Orijinal Adı";
            gridViewFiles.Columns["OriginalName"].OptionsColumn.AllowEdit = false;

            gridViewFiles.Columns.AddField("NewName").Visible = true;
            gridViewFiles.Columns["NewName"].Caption = "Yeni Adı";
            gridViewFiles.Columns["NewName"].OptionsColumn.AllowEdit = false;

            gridViewFiles.Columns.AddField("Status").Visible = true;
            gridViewFiles.Columns["Status"].Caption = "Durum";
            gridViewFiles.Columns["Status"].OptionsColumn.AllowEdit = false;

            gridViewFiles.Columns.AddField("FullPath").Visible = false;

            gridViewFiles.BestFitColumns();
            gridViewFiles.OptionsView.ShowGroupPanel = false; 
            gridViewFiles.OptionsFind.AlwaysVisible = true; 
            gridViewFiles.OptionsFind.FindNullPrompt = "Dosyalar içinde ara...";
       
        }
        private void SetupEventHandlers()
        {
            btnSelectFolder.Click += BtnSelectFolder_Click;
            btnPreview.Click += BtnPreview_Click;
            btnApplyChanges.Click += BtnApplyChanges_Click;

            chkAddPrefix.CheckedChanged += (s, e) => { txtPrefix.Enabled = chkAddPrefix.Checked; };
            chkAddSuffix.CheckedChanged += (s, e) => { txtSuffix.Enabled = chkAddSuffix.Checked; };
            chkReplaceText.CheckedChanged += (s, e) => {
                txtFind.Enabled = chkReplaceText.Checked;
                txtReplaceWith.Enabled = chkReplaceText.Checked;
            };
            chkAddNumber.CheckedChanged += (s, e) => {
                bool isChecked = chkAddNumber.Checked;
                seStartNumber.Enabled = isChecked;
                txtNumberPadding.Enabled = isChecked;
                cmbNumberPosition.Enabled = isChecked;
            };
            gridViewFiles.RowStyle += GridViewFiles_RowStyle;


        }
        private void BtnSelectFolder_Click(object sender, EventArgs e)
        {
            if (xtraFolderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                txtFolderPath.Text = xtraFolderBrowserDialog1.SelectedPath;
                LoadFilesFromFolder(txtFolderPath.Text);
            }
        }
        private void LoadFilesFromFolder(string folderPath)
        {
            try
            {
                _fileItems.Clear();
                var files = Directory.GetFiles(folderPath);

                foreach (var file in files)
                {
                    _fileItems.Add(new FileItem
                    {
                        FullPath = file,
                        OriginalName = Path.GetFileName(file),
                        NewName = Path.GetFileName(file),
                        Status = "Hazır"
                    });
                }

                gridControlFiles.RefreshDataSource();
                gridViewFiles.BestFitColumns();
                btnApplyChanges.Enabled = false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Dosyalar yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnPreview_Click(object sender, EventArgs e)
        {
            if (!_fileItems.Any())
            {
                XtraMessageBox.Show("Lütfen önce bir klasör seçip dosyaları listeleyin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int counter = (int)seStartNumber.Value;

            foreach (var item in _fileItems)
            {
                string currentName = item.OriginalName;
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(currentName);
                string extension = Path.GetExtension(currentName);

                if (chkReplaceText.Checked && !string.IsNullOrEmpty(txtFind.Text))
                {
                    fileNameWithoutExt = fileNameWithoutExt.Replace(txtFind.Text, txtReplaceWith.Text);
                }

                if (chkAddNumber.Checked)
                {
                    string format = "0"; 
                    if (!string.IsNullOrWhiteSpace(txtNumberPadding.Text))
                    {
                        format = txtNumberPadding.Text;
                    }

                    try
                    {
                        string numberStr = counter.ToString(format);
                        if (cmbNumberPosition.SelectedItem.ToString() == "Önek Olarak")
                        {
                            fileNameWithoutExt = numberStr + fileNameWithoutExt;
                        }
                        else 
                        {
                            fileNameWithoutExt = fileNameWithoutExt + numberStr;
                        }
                    }
                    catch (FormatException)
                    {
                        fileNameWithoutExt += counter.ToString();
                    }
                }

                if (chkAddPrefix.Checked && !string.IsNullOrEmpty(txtPrefix.Text))
                {
                    fileNameWithoutExt = txtPrefix.Text + fileNameWithoutExt;
                }

                if (chkAddSuffix.Checked && !string.IsNullOrEmpty(txtSuffix.Text))
                {
                    fileNameWithoutExt = fileNameWithoutExt + txtSuffix.Text;
                }

                counter++;

                item.NewName = fileNameWithoutExt + extension;
                item.Status = (item.OriginalName != item.NewName) ? "Değiştirilecek" : "Değişiklik Yok";
            }

            gridControlFiles.RefreshDataSource();
            btnApplyChanges.Enabled = _fileItems.Any(item => item.OriginalName != item.NewName);
        }

        private void BtnApplyChanges_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Dosya adları kalıcı olarak değiştirilecektir. Emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            int successCount = 0;
            int errorCount = 0;

            foreach (var item in _fileItems.Where(i => i.Status == "Değiştirilecek"))
            {
                try
                {
                    string oldPath = item.FullPath;
                    string newPath = Path.Combine(Path.GetDirectoryName(oldPath), item.NewName);

                    if (File.Exists(newPath))
                    {
                        item.Status = "Hata: Bu isimde dosya var!";
                        errorCount++;
                        continue;
                    }

                    File.Move(oldPath, newPath);
                    item.Status = "Başarılı";
                    item.FullPath = newPath;
                    item.OriginalName = item.NewName; 
                    successCount++;
                }
                catch (Exception ex)
                {
                    item.Status = $"Hata: {ex.Message.Substring(0, Math.Min(ex.Message.Length, 30))}";
                    errorCount++;
                }
            }

            gridControlFiles.RefreshDataSource();
            btnApplyChanges.Enabled = false;
            XtraMessageBox.Show($"{successCount} dosya başarıyla yeniden adlandırıldı.\n{errorCount} dosyada hata oluştu.", "İşlem Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void GridViewFiles_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                GridView view = sender as GridView;
                if (view == null) return;
                string status = view.GetRowCellValue(e.RowHandle, "Status") as string;
                if (string.IsNullOrEmpty(status)) return;

                switch (status.ToLower())
                {
                    case "başarılı":
                        e.Appearance.ForeColor = Color.ForestGreen;
                        e.Appearance.FontStyleDelta = FontStyle.Bold;
                        break;

                    case "değişiklik yok":
                        e.Appearance.ForeColor = Color.Gray;
                        break;

                    case var s when s.StartsWith("hata"):
                        e.Appearance.BackColor = Color.FromArgb(255, 204, 204);
                        e.Appearance.ForeColor = Color.DarkRed;
                        break;
                }
            }
        }
    }
}
