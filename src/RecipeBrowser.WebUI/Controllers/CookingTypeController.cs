using Microsoft.AspNetCore.Mvc;
using RecipeBrowser.Core.Entities;
using RecipeBrowser.Repos.Common;

namespace RecipeBrowser.WebUI.Controllers
{
    public class CookingTypeController : Controller
    {
        private readonly IRepository<CookingType, Guid> _cookingTypeRepository;
        public CookingTypeController(IRepository<CookingType, Guid> cookingTypeRepository)
        {
            _cookingTypeRepository = cookingTypeRepository;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _cookingTypeRepository.GetAllAsync());
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CookingType model)
        {
            if (ModelState.IsValid)
            {
                await _cookingTypeRepository.CreateAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            return View(await _cookingTypeRepository.GetAsync(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, CookingType updatedModel)
        {
            try
            {
                await _cookingTypeRepository.UpdateAsync(updatedModel);
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
                await _cookingTypeRepository.DeleteAsync(id);
                return Json(new { success = true, message = "Запис успішно видалено" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Помилка при видаленні запису: {ex.Message}" });
            }
        }
    }
}
