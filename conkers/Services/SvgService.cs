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
                    return EncodeAsBase64(result);
                }
            }
            catch
            {
            }
            return await GetDefaultSvgAsync();
        }

        public static async Task<string> GetDefaultSvgAsync()
        {
            using (var stream = typeof(SvgService).Assembly.GetManifestResourceStream("conkers.Resources.default.svg"))
            {
                if (stream != null)
                {
                    using (var reader = new StreamReader(stream))
                    {
                        var result = await reader.ReadToEndAsync();
                        return EncodeAsBase64(result);
                    }
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public static async Task<string> GetHiSvgAsync()
        {
            using (var stream = typeof(SvgService).Assembly.GetManifestResourceStream("conkers.Resources.hi.svg"))
            {
                if (stream != null)
                {
                    using (var reader = new StreamReader(stream))
                    {
                        var result = await reader.ReadToEndAsync();
                        return EncodeAsBase64(result);
                    }
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        private static string EncodeAsBase64(string content)
        {
            var result = Convert.ToBase64String(Encoding.UTF8.GetBytes(content));
            return $"data:image/svg+xml;base64,{result}";
        }
    }
}
