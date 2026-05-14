Akıllı Tarım Sistemi (Smart Farming System) Proje Özeti

Hazırlayanlar:

Yusuf Demir
İbrahim Yahya Ekinci
Yusuf Enes Işık

Bu çalışma, geleneksel tarım yöntemlerini modern yazılım teknolojileriyle birleştirerek bitki sağlığını optimize etmeyi amaçlayan bir yönetim ve teşhis sistemidir. Proje, tarımsal verimliliği artırmak adına bitki takibi, otomatik sulama planlaması ve yapay zeka destekli hastalık teşhisi süreçlerini tek bir platformda toplamaktadır.

Teknik Gereksinimler ve Nesne Yönelimli Tasarım
Projenin temel iskeleti, sürdürülebilir ve genişletilebilir bir yapı sunması adına nesne yönelimli programlama (OOP) prensiplerine tam uyumlu olarak C# diliyle geliştirilmiştir. Sistem, en az 5 temel sınıf (Bitki, Sebze, Cicek, BahceYonetici, VeriServisi) üzerine inşa edilerek modüler bir mimari sağlanmıştır.

Kalıtım (Inheritance): Tüm bitki türlerinin ortak özelliklerini barındıran soyut (abstract) bir Bitki temel sınıfı oluşturulmuştur. Sebze ve Cicek gibi sınıflar bu temel sınıftan türetilerek kodun tekrar kullanılabilirliği sağlanmıştır.

Çok Biçimlilik (Polymorphism): Her bitki türünün farklı su ihtiyacı olduğu gerçeğinden hareketle, Sula metodu alt sınıflarda "override" edilmiştir. Bu sayede sistem, her bitkiye türüne göre özel müdahalede bulunabilmektedir.

Kapsülleme (Encapsulation): Bitkilerin nem oranı, isim ve kimlik bilgileri gibi kritik veriler "private" erişim belirleyicileri ile korunmuştur. Verilere erişim ve veri atama işlemleri, mantıksal kontrollerin yapıldığı "Properties" yapıları üzerinden gerçekleştirilerek veri güvenliği sağlanmıştır.

Hata Yönetimi (Exception Handling): Uygulamanın çalışma kararlılığını korumak amacıyla özellikle dosya okuma/yazma ve dış veri yükleme süreçlerinde kapsamlı hata yakalama mekanizmaları (try-catch blokları) kullanılmıştır.

Modülerlik: Proje; Models, Interfaces ve Services katmanlarına ayrılarak profesyonel yazılım standartlarına uygun, bakımı kolay ve genişletilebilir bir yapıda tasarlanmıştır.

Fonksiyonel Özellikler ve Veri Yönetimi
Uygulama, kullanıcı deneyimini ön planda tutan bir grafik arayüz (GUI) sunarken arka planda karmaşık veri işlemlerini yönetmektedir.

CRUD İşlemleri: Kullanıcılar sistem üzerinden yeni bitki ekleyebilir, mevcut bitkileri listeleyebilir, durumlarını güncelleyebilir ve kayıtları silebilirler.

Veri Saklama Mekanizması: Sistemdeki tüm veriler kalıcı hafızada saklanmaktadır. Newtonsoft.Json kütüphanesi entegrasyonu ile bitki listeleri ve sağlık durumları JSON formatında dosyalara kaydedilmekte, uygulama yeniden başlatıldığında otomatik olarak yüklenmektedir.

Kullanıcı Etkileşimi: Windows Forms tabanlı kullanıcı arayüzü sayesinde tüm işlemler görsel kontroller aracılığıyla hızlı ve kolay bir şekilde gerçekleştirilmektedir.

Yapay Zeka Entegrasyonu ve Hastalık Teşhisi
Projenin en ayırt edici özelliği, Python tabanlı görüntü işleme modelleriyle olan entegrasyonudur. Sisteme yüklenen bitki fotoğrafları, yapay zeka algoritması tarafından analiz edilerek hastalık tespiti yapılmaktadır. Teşhis konulan bitki için sadece hastalığın ismi söylenmekle kalmayıp, bu duruma uygun tedavi yöntemleri, kullanılacak zirai ilaçlar ve iyileşme süreci için gerekli bakım talimatları kullanıcıya detaylı bir rapor olarak sunulmaktadır.