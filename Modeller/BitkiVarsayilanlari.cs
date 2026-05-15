using System.Collections.Generic;

namespace BahceYonetim.Models
{
    public static class BitkiVarsayilanlari
    {
        public static readonly Dictionary<BitkiTuru, (double Nem, double Sicaklik, string Sulama)> Degerler
            = new()
            {
                { BitkiTuru.Elma, (60, 20, "Haftada 2 kez") },
                { BitkiTuru.Kiraz, (65, 22, "Haftada 2 kez") },
                { BitkiTuru.Misir, (75, 25, "Her gün") },
                { BitkiTuru.Patates, (70, 18, "Haftada 1 kez") },
                { BitkiTuru.Cilek, (80, 20, "2 günde bir") }
            };

        public static Bitki OlusturVarsayilan(BitkiTuru tur, string ad, int id)
        {
            var (nem, sicaklik, sulama) = Degerler[tur];
            return new Bitki
            {
                Id = id,
                Ad = ad,
                Tur = tur,
                NemOrani = nem,
                Sicaklik = sicaklik,
                SulamaSikligi = sulama,
                Durum = "AI Analizi Bekliyor", // Başlangıç durumu
                Hastalik = "Bilinmiyor"
            };
        }
    }
}