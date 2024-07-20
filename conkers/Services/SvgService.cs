using System.Text;

namespace conkers.Services
{
    public class SvgService(HttpClient httpClient)
    {
        public async Task<string> GetSvgAsync(string customSvgUrl)
        {
            try
            {
                var response = await httpClient.GetAsync(customSvgUrl);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var resultBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(result));
                    return $"data:image/svg+xml;base64,{resultBase64}";
                }
            }
            catch
            {
            }

            return await GetDefaultSvgAsync();
        }

        public async Task<string> GetDefaultSvgAsync()
        {
            var result = await httpClient.GetStringAsync("../wwwroot.default.svg");
            var resultBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(result));
            return $"data:image/svg+xml;base64,{resultBase64}";

        }
    }
}
