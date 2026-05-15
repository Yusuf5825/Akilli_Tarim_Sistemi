using System.Net.Http;
using System.Threading.Tasks;

namespace BahceYonetim.Models
{
    public class AIAnalizServisi
    {
        private readonly HttpClient _client;

        // HttpClient'ı sistemden (Program.cs) alıyoruz
        public AIAnalizServisi(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> ResimAnalizEt(byte[] dosyaBytes, string dosyaAdi)
        {
            try
            {
                using var content = new MultipartFormDataContent();

                // Diske dokunmadan doğrudan RAM üzerinden gönderim
                var fileContent = new ByteArrayContent(dosyaBytes);
                content.Add(fileContent, "file", dosyaAdi);

                // FastAPI adresinin doğruluğundan emin ol (Port 8000)
                var res = await _client.PostAsync("http://127.0.0.1:8000/tespit-et", content);
                return await res.Content.ReadAsStringAsync();
            }
            catch (System.Exception ex)
            {
                return $"HATA___{ex.Message}";
            }
        }
    }
}