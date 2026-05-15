using System.Collections.Generic;
using System.Linq;

namespace BahceYonetim.Models
{
    public class BahceServisi
    {
        // Bahçemizdeki bitkilerin tutulduğu ana liste
        public List<Bitki> Bitkiler { get; set; } = new();

        public BahceServisi()
        {
            // Başlangıçta bahçe BOMBOS! 
            // Sen fotoğraf okuttukça dolacak.
        }

        public void BitkiEkle(Bitki yeniBitki)
        {
            // Yeni bitkiye otomatik ID ver ve listeye ekle
            yeniBitki.Id = Bitkiler.Count > 0 ? Bitkiler.Max(b => b.Id) + 1 : 1;
            Bitkiler.Add(yeniBitki);
        }
    }
}
