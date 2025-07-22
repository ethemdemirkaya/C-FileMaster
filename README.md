# Bulk File Renamer

[**Türkçe versiyon için buraya tıklayın (Click here for the Turkish version)**](./README_tr.md)

A powerful and user-friendly bulk file renaming utility built with C# WinForms and DevExpress. This application allows users to rename multiple files in a folder based on a set of flexible rules, with a live preview before applying any changes.


*(Note: Replace the URL above with a real screenshot of your application)*

---

## ✨ Features

- **Select a Folder**: Easily choose a folder containing the files you want to rename.
- **Live File List**: View all files in the selected folder in a clear and organized grid.
- **Instant Search**: Quickly find specific files in the list using the built-in search bar.
- **Dynamic Renaming Rules**:
    - **Add Prefix/Suffix**: Add custom text to the beginning or end of filenames.
    - **Replace Text**: Find and replace specific text within filenames.
    - **Sequential Numbering**: Add sequential numbers with customizable formatting (e.g., `001`, `002`) as a prefix or suffix.
- **Live Preview**: See the "New Name" for each file before committing the changes. The grid updates instantly as you change the rules.
- **Status Highlighting**:
    - Files to be renamed are clearly marked.
    - Successful renames are highlighted in **green**.
    - Errors (e.g., file in use, duplicate name) are highlighted in **red**.
    - Unchanged files are shown in gray.
- **Safe Apply**: A confirmation dialog prevents accidental renaming.
- **(Coming Soon / Optional) Undo**: A feature to revert the last renaming operation.

---

## 🛠️ Built With

- **[C#](https://learn.microsoft.com/en-us/dotnet/csharp/)** - The primary programming language.
- **[Windows Forms (.NET Framework)](https://learn.microsoft.com/en-us/dotnet/desktop/winforms/)** - The application framework.
- **[DevExpress WinForms Controls](https://www.devexpress.com/products/net/controls/winforms/)** - Used for modern and powerful UI components like `GridControl`, `TextEdit`, and `SpinEdit`.

---

## 🚀 Getting Started

### Prerequisites

- .NET Framework 4.7.2 (or the version you used).
- DevExpress WinForms Controls v2x.x (or a compatible version).

### Installation

1.  Go to the [**Releases**](https://github.com/your-username/your-repo-name/releases) page.
2.  Download the latest `Bulk.File.Renamer.zip` file.
3.  Extract the ZIP archive to a folder of your choice.
4.  Run `C_FileNameChanger.exe`.

### Running from Source

1.  Clone the repository:
    ```sh
    git clone https://github.com/your-username/your-repo-name.git
    ```
2.  Open the `C_FileNameChanger.sln` solution file in Visual Studio.
3.  Restore the necessary NuGet packages.
4.  Build and run the project (press F5).

---

## 📜 License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.