using System;
using System.Threading.Tasks;

namespace akilli_tarim_sistemi
{
    class Program
    {
        static async Task Main(string[] args)
        {
            BahceYonetici yonetici = new BahceYonetici();

            while (true)
            {
                Console.WriteLine("\n1. Zamanı İlerlet (Nem Azalır)");
                Console.WriteLine("2. Yeni Fotoğraf Yükle (AI Bitki Tanımlama & Ekleme)");
                Console.WriteLine("3. Manuel Sula (ID ile)");
                Console.Write("Seçiminiz: ");

                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        yonetici.Guncelle();
                        break;
                    case "2":
                        Console.Write("Fotoğraf dosya yolunu girin: ");
                        string yol = Console.ReadLine();
                        await yonetici.OtonomBitkiEkle(yol);
                        break;
                    case "3":
                        Console.Write("Sulanacak Bitki ID: ");
                        string id = Console.ReadLine();
                        yonetici.Sula(id);
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçim.");
                        break;
                }
            }
        }
    }
}