using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace RecipeBrowser.WebUI.Services
{
    public class TranslationService
    {
        private readonly HttpClient _httpClient;
        private readonly string _authKey = "0962df95-a95e-455b-a246-232627ffdffc:fx"; // Ваш ключ автентифікації для DeepL API

        public TranslationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://api-free.deepl.com/v2/");
        }

        public async Task<string> TranslateToEnglish(string text)
        {
            try
            {
                var queryString = $"?text={text}&target_lang=EN&source_lang=UK"; // Підготовка параметрів для GET запиту

                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"DeepL-Auth-Key {_authKey}");

                var response = await _httpClient.GetAsync($"translate{queryString}");
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var translatedText = JObject.Parse(responseContent)["translations"][0]["text"].ToString();

                return translatedText;
            }
            catch (Exception ex)
            {
                // Обробка помилок
                Console.WriteLine($"Помилка при перекладі: {ex.Message}");
                throw;
            }
        }
    }
}
