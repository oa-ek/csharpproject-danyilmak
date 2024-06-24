using Microsoft.AspNetCore.Mvc;
using RecipeBrowser.Core.Entities;
using RecipeBrowser.Repos.Common;

namespace RecipeBrowser.WebUI.Controllers
{
    public class RecipeCollectionController : Controller
    {
        private readonly IRepository<User, Guid> _userRepository;
        private readonly IRepository<RecipeCollection, Guid> _recipeCollectionRepository;
        private readonly IRepository<Recipe, Guid> _recipeRepository;

        public RecipeCollectionController(IRepository<User, Guid> userRepository, IRepository<RecipeCollection, Guid> recipeCollectionRepository, IRepository<Recipe, Guid> recipeRepository)
        {
            _userRepository = userRepository;
            _recipeCollectionRepository = recipeCollectionRepository;
            _recipeRepository = recipeRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _recipeCollectionRepository.GetAllAsync());
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RecipeCollection model)
        {
            model.UserId = (await _userRepository.GetAllAsync()).First(u => u.Email == User.Identity.Name).Id;
            if (ModelState.IsValid)
            {
                await _recipeCollectionRepository.CreateAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _recipeCollectionRepository.DeleteAsync(id);
                return Json(new { success = true, message = "Запис успішно видалено" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Помилка при видаленні запису: {ex.Message}" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRecipeToCollection(Guid recipeId, Guid collectionId)
        {
            var collection = await _recipeCollectionRepository.GetAsync(collectionId);
            var recipe = await _recipeRepository.GetAsync(recipeId);
            if (collection == null || recipe == null)
            {
                return Json(new { success = false, message = "Колекція або рецепт не знайдено." });
            }

            if (!collection.Recipes.Any(r => r.Id == recipeId))
            {
                collection.Recipes.Add(recipe);
                await _recipeCollectionRepository.UpdateAsync(collection);
                return Json(new { success = true, message = "Рецепт додано до колекції." });
            }
            return Json(new { success = false, message = "Рецепт вже є у цій колекції." });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRecipeFromCollection(Guid recipeId, Guid collectionId)
        {
            var collection = await _recipeCollectionRepository.GetAsync(collectionId);
            var recipe = await _recipeRepository.GetAsync(recipeId);
            if (collection == null || recipe == null)
            {
                return Json(new { success = false, message = "Колекція або рецепт не знайдено." });
            }

            if (collection.Recipes.Any(r => r.Id == recipeId))
            {
                collection.Recipes.Remove(recipe);
                await _recipeCollectionRepository.SaveAsync();
                return Json(new { success = true, message = "Рецепт видалено з колекції." });
            }
            return Json(new { success = false, message = "Рецепта і не було у цій колекції." });
        }
    }
}
