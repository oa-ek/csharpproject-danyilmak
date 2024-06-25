using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RecipeBrowser.WebUI.Services;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class NutritionController : Controller
{
    private readonly NutritionService _nutritionService;
    private readonly TranslationService _translationService;

    public NutritionController(NutritionService nutritionService, TranslationService translationService)
    {
        _nutritionService = nutritionService;
        _translationService = translationService;
    }

    [HttpGet("{productName}")]
    public async Task<IActionResult> GetNutrition(string productName)
    {
        var translatedProductName = await _translationService.TranslateToEnglish(productName);

        try
        {
            var nutritionData = await _nutritionService.GetNutritionFactsAsync(translatedProductName);
            var protein = (double)nutritionData["foods"][0]["nf_protein"];
            var totalFats = (double)nutritionData["foods"][0]["nf_total_fat"];
            var carbohydrates = (double)nutritionData["foods"][0]["nf_total_carbohydrate"];
            var calories = (double)nutritionData["foods"][0]["nf_calories"];

            var result = new
            {
                protein,
                total_fats = totalFats,
                carbohydrates,
                calories
            };

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest("Failed to retrieve nutrition information.");
        }
    }
}
