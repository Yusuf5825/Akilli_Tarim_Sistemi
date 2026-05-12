using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace akilli_tarim_sistemi
{
    public class DosyaIslemleri
    {
        private const string DosyaYolu = "bahce_verileri.json";

        public void VerileriKaydet(List<Bitki> bitkiler)
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(bitkiler, options);
                File.WriteAllText(DosyaYolu, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[HATA] Kayıt yapılamadı: {ex.Message}");
            }
        }

        public List<Bitki> VerileriYukle()
        {
            if (!File.Exists(DosyaYolu)) return new List<Bitki>();

            try
            {
                string jsonString = File.ReadAllText(DosyaYolu);
                return JsonSerializer.Deserialize<List<Bitki>>(jsonString) ?? new List<Bitki>();
            }
            catch
            {
                return new List<Bitki>();
            }
        }
    }
}