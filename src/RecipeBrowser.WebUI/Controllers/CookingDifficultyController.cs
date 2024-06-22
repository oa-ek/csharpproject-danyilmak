using Microsoft.AspNetCore.Mvc;
using RecipeBrowser.Core.Entities;
using RecipeBrowser.Repos.Common;

namespace RecipeBrowser.WebUI.Controllers
{
    public class CookingDifficultyController : Controller
    {
        private readonly IRepository<CookingDifficulty, Guid> _cookingDifficultyRepository;
        public CookingDifficultyController(IRepository<CookingDifficulty, Guid> cookingDifficultyRepository)
        {
            _cookingDifficultyRepository = cookingDifficultyRepository;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _cookingDifficultyRepository.GetAllAsync());
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CookingDifficulty model)
        {
            if (ModelState.IsValid)
            {
                await _cookingDifficultyRepository.CreateAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            return View(await _cookingDifficultyRepository.GetAsync(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, CookingDifficulty updatedModel)
        {
            try
            {
                await _cookingDifficultyRepository.UpdateAsync(updatedModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _cookingDifficultyRepository.DeleteAsync(id);
                return Json(new { success = true, message = "Запис успішно видалено" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Помилка при видаленні запису: {ex.Message}" });
            }
        }
    }
}
