using Microsoft.AspNetCore.Mvc;
using RecipeBrowser.Core.Entities;
using RecipeBrowser.Repos.Common;

namespace RecipeBrowser.WebUI.Controllers
{
    public class MeasureController : Controller
    {
        private readonly IRepository<Measure, Guid> _measureRepository;
        public MeasureController(IRepository<Measure, Guid> measureRepository)
        {
            _measureRepository = measureRepository;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _measureRepository.GetAllAsync());
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Measure model)
        {
            if (ModelState.IsValid)
            {
                await _measureRepository.CreateAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            return View(await _measureRepository.GetAsync(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Measure updatedModel)
        {
            try
            {
                await _measureRepository.UpdateAsync(updatedModel);
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
                await _measureRepository.DeleteAsync(id);
                return Json(new { success = true, message = "Запис успішно видалено" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Помилка при видаленні запису: {ex.Message}" });
            }
        }
    }
}
