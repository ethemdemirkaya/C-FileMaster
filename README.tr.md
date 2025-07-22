# Toplu Dosya Adı Değiştirici (Bulk File Renamer)

C# WinForms ve DevExpress kullanılarak geliştirilmiş, güçlü ve kullanıcı dostu bir toplu dosya yeniden adlandırma aracıdır. Bu uygulama, kullanıcıların bir klasördeki birden çok dosyayı, esnek kurallara göre ve değişiklikleri uygulamadan önce canlı önizleme ile yeniden adlandırmasına olanak tanır.


*(Not: Yukarıdaki URL'yi uygulamanızın gerçek bir ekran görüntüsü ile değiştirin)*

---

## ✨ Özellikler

- **Klasör Seçimi**: Adını değiştirmek istediğiniz dosyaları içeren klasörü kolayca seçin.
- **Canlı Dosya Listesi**: Seçilen klasördeki tüm dosyaları net ve düzenli bir tablo üzerinde görüntüleyin.
- **Anında Arama**: Dahili arama çubuğunu kullanarak listedeki belirli dosyaları hızla bulun.
- **Dinamik Yeniden Adlandırma Kuralları**:
    - **Önek/Sonek Ekleme**: Dosya adlarının başına veya sonuna özel metinler ekleyin.
    - **Metin Değiştirme**: Dosya adları içindeki belirli bir metni bulun ve başka bir metinle değiştirin.
    - **Sıralı Numaralandırma**: Önek veya sonek olarak, özelleştirilebilir formatta (`001`, `002` gibi) sıralı numaralar ekleyin.
- **Canlı Önizleme**: Değişiklikleri onaylamadan önce her dosyanın "Yeni Adı"nı görün. Kuralları değiştirdiğinizde tablo anında güncellenir.
- **Durum Vurgulama**:
    - Adı değiştirilecek dosyalar net bir şekilde işaretlenir.
    - Başarılı yeniden adlandırmalar **yeşil** renkte vurgulanır.
    - Hatalar (örn: dosya kullanımda, yinelenen ad) **kırmızı** renkte vurgulanır.
    - Değişmeyen dosyalar gri renkte gösterilir.
- **Güvenli Uygulama**: Onay diyaloğu, kazara yeniden adlandırmayı önler.
- **(Yakında / İsteğe Bağlı) Geri Al**: Son yeniden adlandırma işlemini geri alan bir özellik.

---

## 🛠️ Kullanılan Teknolojiler

- **[C#](https://learn.microsoft.com/tr-tr/dotnet/csharp/)** - Ana programlama dili.
- **[Windows Forms (.NET Framework)](https://learn.microsoft.com/tr-tr/dotnet/desktop/winforms/)** - Uygulama çatısı.
- **[DevExpress WinForms Kontrolleri](https://www.devexpress.com/products/net/controls/winforms/)** - `GridControl`, `TextEdit` ve `SpinEdit` gibi modern ve güçlü arayüz bileşenleri için kullanıldı.

---

## 🚀 Başlarken

### Gereksinimler

- .NET Framework 4.7.2 (veya kullandığınız sürüm).
- DevExpress WinForms Kontrolleri v2x.x (veya uyumlu bir sürüm).

### Kurulum

1.  [**Releases (Sürümler)**](https://github.com/your-username/your-repo-name/releases) sayfasına gidin.
2.  En son `Bulk.File.Renamer.zip` dosyasını indirin.
3.  ZIP arşivini istediğiniz bir klasöre çıkartın.
4.  `C_FileNameChanger.exe` dosyasını çalıştırın.

### Kaynaktan Çalıştırma

1.  Depoyu klonlayın:
    ```sh
    git clone https://github.com/your-username/your-repo-name.git
    ```
2.  `C_FileNameChanger.sln` çözüm dosyasını Visual Studio'da açın.
3.  Gerekli NuGet paketlerini geri yükleyin.
4.  Projeyi derleyin ve çalıştırın (F5 tuşuna basın).

---

## 📜 Lisans

Bu proje MIT Lisansı altında lisanslanmıştır - ayrıntılar için [LICENSE.md](LICENSE.md) dosyasına bakın.