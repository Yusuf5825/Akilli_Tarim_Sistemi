using System;

namespace BahceYonetim.Models
{
    public class Bitki
    {
        public int Id { get; set; }
        public string Ad { get; set; } = string.Empty;
        public BitkiTuru Tur { get; set; }
        public double NemOrani { get; set; }
        public double Sicaklik { get; set; }
        public string SulamaSikligi { get; set; } = string.Empty;

        // AI ve Genel Durum
        public string Durum { get; set; } = "AI Analizi Bekliyor";
        public string Hastalik { get; set; } = "Bilinmiyor";
        public DateTime? SonAnalizTarihi { get; set; } = null;

        public string Not { get; set; } = string.Empty;
        public DateTime? SonSulama { get; set; } = null;

        // Modeldeki türlere göre ikonlar
        public string Ikon => Tur switch
        {
            BitkiTuru.Elma => "🍎",
            BitkiTuru.Kiraz => "🍒",
            BitkiTuru.Misir => "🌽",
            BitkiTuru.Patates => "🥔",
            BitkiTuru.Cilek => "🍓",
            _ => "🌱"
        };

        public string NemRengi => NemOrani switch
        {
            < 25 => "bar-kritik",
            < 50 => "bar-uyari",
            _ => "bar-saglikli"
        };

        public string DurumClass => Durum switch
        {
            "Kritik" => "badge badge-kritik",
            "AI Analizi Bekliyor" => "badge badge-bekliyor",
            "Sağlıklı" => "badge badge-saglikli",
            _ => "badge badge-hastalikli" // Hastalık durumları için UI sınıfı eklenebilir
        };

        // FastAPI'den gelen "Elma___Kara_Curuk" gibi stringi işleyen metot
        public void AIAnaliziniUygula(string aiCiktisi)
        {
            if (string.IsNullOrWhiteSpace(aiCiktisi) || aiCiktisi.StartsWith("HATA") || aiCiktisi == "Bilinmiyor___Saglikli")
            {
                Durum = "Analiz Başarısız";
                Hastalik = "Tespit Edilemedi";
                return;
            }

            var parcalar = aiCiktisi.Split("___");
            if (parcalar.Length == 2)
            {
                // Python'dan gelen '_' karakterlerini boşlukla değiştirerek okunabilir yapıyoruz
                string tespitEdilen = parcalar[1].Replace("_", " ");

                if (tespitEdilen == "Saglikli")
                {
                    Durum = "Sağlıklı";
                    Hastalik = "Yok";
                }
                else
                {
                    Durum = "Kritik";
                    Hastalik = tespitEdilen; // Örn: "Kara Curuk", "Kuzey Yaprak Yanikligi"
                }

                SonAnalizTarihi = DateTime.Now;
            }
        }

        public void DurumuGuncelle()
        {
            // Eğer bitki hastalıklıysa veya analiz bekliyorsa nem oranına göre durumu ezme
            if (Durum == "AI Analizi Bekliyor" || (Hastalik != "Yok" && Hastalik != "Bilinmiyor")) return;

            Durum = NemOrani < 25 ? "Kritik" : "Sağlıklı";

        }
        public string FotografBase64 { get; set; } = "";
    }
   

    }