using Microsoft.AspNetCore.Mvc;
using RecipeBrowser.Core.Entities;
using RecipeBrowser.Repos.Common;

namespace RecipeBrowser.WebUI.Controllers
{
    public class ProductTypeController : Controller
    {
        private readonly IRepository<ProductType, Guid> _productTypeRepository;
        public ProductTypeController(IRepository<ProductType, Guid> productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _productTypeRepository.GetAllAsync());
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductType model)
        {
            if (ModelState.IsValid)
            {
                await _productTypeRepository.CreateAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            return View(await _productTypeRepository.GetAsync(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProductType updatedModel)
        {
            try
            {
                await _productTypeRepository.UpdateAsync(updatedModel);
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
                await _productTypeRepository.DeleteAsync(id);
                return Json(new { success = true, message = "Запис успішно видалено" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Помилка при видаленні запису: {ex.Message}" });
            }
        }
    }
}
