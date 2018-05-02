using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Tatar.Services.Settings;

namespace Tatar.Services
{
    public class YandexTranslator : ITranslator
    {
        public YandexTranslator(IOptions<YandexApiSettings> settings)
        {
            Settings = settings;
        }

        public IOptions<YandexApiSettings> Settings { get; }

        public async Task<string> Translate(string words)
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"https://translate.yandex.net/api/v1.5/tr.json/translate?key={Settings.Value.Key}&lang=tt&text={WebUtility.UrlEncode(words)}");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var jsonStr = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<YandexApiResponse>(jsonStr);
                return apiResponse.Text.Length > 0 ? apiResponse.Text[0] : null;
            }
            else
            {
                throw new Exception($"Cannot translate. Status code {(int)response.StatusCode}.");
            }
        }


    }
}
