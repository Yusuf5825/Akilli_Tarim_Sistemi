using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace akilli_tarim_sistemi
{
    public class AIAnalizServisi
    {
        private readonly HttpClient _client = new HttpClient();
        public async Task<string> ResimAnalizEt(string path)
        {
            try
            {
                using var content = new MultipartFormDataContent();
                using var fs = File.OpenRead(path);
                content.Add(new StreamContent(fs), "file", Path.GetFileName(path));
                var res = await _client.PostAsync("http://127.0.0.1:8000/tespit-et", content);
                return await res.Content.ReadAsStringAsync();
            }
            catch (Exception ex) { return $"HATA___{ex.Message}"; }
        }
    }
}
