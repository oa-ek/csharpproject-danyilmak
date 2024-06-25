using RecipeBrowser.Core.Entities;

namespace RecipeBrowser.WebUI.Models
{
    public class IngredientModel
    {
        public string Amount { get; set; }
        public Guid ProductId { get; set; }
        public Guid MeasureId { get; set; }
    }
}
