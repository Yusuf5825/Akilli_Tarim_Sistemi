using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace akilli_tarim_sistemi
{
    public class BahceYonetici
    {
        private List<Bitki> _bitkiler;
        private readonly AIAnalizServisi _ai = new AIAnalizServisi();
        private readonly DosyaIslemleri _dosya = new DosyaIslemleri();

        public BahceYonetici() => _bitkiler = _dosya.VerileriYukle();

        public async Task OtonomBitkiEkle(string yol)
        {
            string hamCevap = await _ai.ResimAnalizEt(yol);
            hamCevap = hamCevap.Replace("\"", "").Trim(); // JSON tırnaklarını temizle

            string[] parcalar = hamCevap.Split("___");
            if (parcalar.Length < 2) return;

            Bitki yeni = parcalar[0].ToLower() switch
            {
                "elma" => new Elma(),
                "misir" => new Misir(),
                "patates" => new Patates(),
                "cilek" => new Cilek(),
                "kiraz" => new Kiraz(),
                _ => null
            };

            if (yeni != null)
            {
                if (parcalar[1].Contains("Saglikli")) yeni.SaglikDurumu = "Sağlıklı";
                else yeni.TedaviEt(parcalar[1]);

                _bitkiler.Add(yeni);
                _dosya.VerileriKaydet(_bitkiler);
                Console.WriteLine($"[SİSTEM] {yeni.Ad} eklendi. ID: {yeni.Id}");
            }
        }

        public void Guncelle()
        {
            _bitkiler.ForEach(b => { b.ZamanGecir(); b.DurumGoster(); });
            _dosya.VerileriKaydet(_bitkiler);
        }

        public void Sula(string id)
        {
            var b = _bitkiler.FirstOrDefault(x => x.Id == id);
            if (b != null) { b.NemOrani = 100; _dosya.VerileriKaydet(_bitkiler); }
        }
    }
}