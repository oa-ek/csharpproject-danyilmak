using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
namespace RecipeBrowser.WebUI.Services
{

    public class NutritionService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "48acd27b5c22deacc0a641aaabe4e330";
        private readonly string _appId = "87691a0f";

        public NutritionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://trackapi.nutritionix.com/v2/");
            _httpClient.DefaultRequestHeaders.Add("x-app-id", _appId);
            _httpClient.DefaultRequestHeaders.Add("x-app-key", _apiKey);
        }

        public async Task<JObject> GetNutritionFactsAsync(string productName)
        {
            var content = new StringContent(
                $"{{\"query\":\"{productName}\"}}",
                System.Text.Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync("natural/nutrients", content);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JObject.Parse(responseContent);
        }

    }
}
