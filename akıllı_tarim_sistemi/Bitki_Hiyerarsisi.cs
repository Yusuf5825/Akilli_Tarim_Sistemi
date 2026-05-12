using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace akilli_tarim_sistemi
{
    // JSON için Polymorphism desteği (.NET 7+ gerektirir)
    [JsonDerivedType(typeof(Elma), "elma")]
    [JsonDerivedType(typeof(Kiraz), "kiraz")]
    [JsonDerivedType(typeof(Cilek), "cilek")]
    [JsonDerivedType(typeof(Misir), "misir")]
    [JsonDerivedType(typeof(Patates), "patates")]
    public abstract class Bitki
    {
        private static readonly Random _rnd = new Random();

        public string Id { get; set; } = Guid.NewGuid().ToString().Substring(0, 5);
        public string Ad { get; protected set; }
        public double NemOrani { get; set; }
        public double Sicaklik { get; set; }
        public string SaglikDurumu { get; set; } = "Analiz Bekleniyor";

        public Bitki(string ad)
        {
            Ad = ad;
            // Başlangıç değerleri ilkte rastgele atanır
            NemOrani = Math.Round(45 + _rnd.NextDouble() * 35, 1); // %45-%80 arası
            Sicaklik = Math.Round(18 + _rnd.NextDouble() * 12, 1); // 18-30 derece arası
        }

        public void ZamanGecir()
        {
            if (NemOrani > 0)
            {
                double kayip = Math.Round(2 + _rnd.NextDouble() * 4, 1);
                NemOrani = Math.Max(0, Math.Round(NemOrani - kayip, 1));
            }
        }

        // Metot imzası: string parametre almalı
        public abstract void TedaviEt(string hastalik);

        public virtual void DurumGoster()
        {
            string uyari = NemOrani < 35 ? "!!! KRİTİK SU SEVİYESİ !!!" : "Normal";
            Console.WriteLine($"[{Id}] {Ad} | Nem: %{NemOrani} ({uyari}) | Sıcaklık: {Sicaklik}°C | Sağlık: {SaglikDurumu}");
        }
    }

    // --- Ara Sınıflar (Meyve ve Sebze) ---
    public abstract class Meyve : Bitki
    {
        public Meyve(string ad) : base(ad) { }
    }

    public abstract class Sebze : Bitki
    {
        public Sebze(string ad) : base(ad) { }
    }

    // --- Spesifik Bitki Sınıfları ---
    public class Elma : Meyve
    {
        public Elma() : base("Elma") { }
        public override void TedaviEt(string hastalik) => SaglikDurumu = $"Sağlıklı ({hastalik} için ilaçlama yapıldı)";
    }

    public class Kiraz : Meyve
    {
        public Kiraz() : base("Kiraz") { }
        public override void TedaviEt(string hastalik) => SaglikDurumu = $"Sağlıklı ({hastalik} için külleme tedavisi uygulandı)";
    }

    public class Cilek : Meyve
    {
        public Cilek() : base("Cilek") { }
        public override void TedaviEt(string hastalik) => SaglikDurumu = $"Sağlıklı ({hastalik} için kurulama yapıldı)";
    }

    public class Misir : Sebze
    {
        public Misir() : base("Mısır") { }
        public override void TedaviEt(string hastalik) => SaglikDurumu = $"Sağlıklı ({hastalik} için gübreleme yapıldı)";
    }

    public class Patates : Sebze
    {
        public Patates() : base("Patates") { }
        public override void TedaviEt(string hastalik) => SaglikDurumu = $"Sağlıklı ({hastalik} için gerekenler yapıldı)";
    }
}