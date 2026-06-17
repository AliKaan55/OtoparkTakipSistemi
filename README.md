# 🚗 Otopark Takip Sistemi

Küçük ve orta ölçekli otoparklar için geliştirilmiş, araç giriş-çıkış işlemlerini, park yeri doluluk durumunu ve ücretlendirmeyi yöneten bir Windows Forms masaüstü uygulaması.

## Özellikler

- **Araç Girişi:** Plaka ve araç tipi (Otomobil, Motosiklet, Kamyon, Otobüs) girilip boş bir park yeri seçilerek kayıt oluşturulur.
- **Araç Çıkışı:** Seçilen araç için kalış süresine göre ücret otomatik hesaplanır, park yeri boşaltılır.
- **Esnek Kapasiteli Park Yerleri:** Her park yeri kendine özel bir araç kapasitesine sahiptir (örn. A-1 aynı anda 3 araç alabilir, B-1 sadece 1 araç).
- **Anlık Doluluk Takibi:** Toplam boş yer sayısı ekranda sürekli güncellenir; otopark dolduğunda etiket kırmızıya döner.
- **Tarife Bazlı Ücretlendirme:** İlk saat için taban ücret, sonraki her saat için ek ücret uygulanır. Araç tipine göre katsayı farkı vardır (motosiklet %25 indirimli, kamyon %50 zamlı, otobüs 2 katı tarife).
- **Kalıcı Veri Saklama:** SQLite veritabanı kullanılır, uygulama her açılışta bekleyen migration'ları otomatik uygular.

## Mimari

Proje, sorumlulukların ayrıldığı 3 katmanlı (N-tier) bir mimariyle tasarlanmıştır:

| Katman | Proje | Açıklama |
|---|---|---|
| Çekirdek | `OtoparkTakipSistemi.Core` | Entity/model sınıfları: `ParkingSlot`, `ParkingRecord`, `Tariff`, `Vehicle`, `VehicleType` enum |
| Veri Erişim | `OtoparkTakipSistemi.DataAccess` | Entity Framework Core `DbContext`, migration'lar, SQLite bağlantı yapılandırması |
| İş Mantığı | `OtoparkTakipSistemi.Business` | Giriş/çıkış işlemleri, ücret hesaplama kuralları (`ParkingManager`) |
| Arayüz | `OtoparkTakipSistemi.UI` | Windows Forms arayüzü (`FormMain`) |

## Kullanılan Teknolojiler

- C# / .NET 9
- Windows Forms
- Entity Framework Core 8 (SQLite provider)
- SQLite

## Kurulum ve Çalıştırma

1. Bu repoyu klonlayın:
   ```
   git clone <repo-url>
   ```
2. Visual Studio 2022 (17.14 veya üzeri) ve .NET 9 SDK kurulu olmalıdır.
3. `OtoparkTakipSistemi.sln` dosyasını Visual Studio ile açın.
4. Projeyi çalıştırın (F5). Uygulama ilk açılışta:
   - Veritabanını `Belgelerim\OtoparkDb.db` yolunda otomatik oluşturur,
   - Bekleyen migration'ları uygular,
   - Örnek park yerlerini (A-1, A-2, B-1, B-2) ve standart tarifeyi otomatik ekler.

## Ekran Görüntüleri



## Lisans

Bu proje eğitim amaçlı geliştirilmiştir.
