using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecipeBrowser.Core.Entities;
using RecipeBrowser.Repos.Common;

namespace RecipeBrowser.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepository<ProductType, Guid> _productTypeRepository;
        private readonly IRepository<Product, Guid> _productRepository;
        public ProductController(IRepository<ProductType, Guid> productTypeRepository, IRepository<Product, Guid> productRepository)
        {
            _productTypeRepository = productTypeRepository;
            _productRepository = productRepository;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAllAsync();
            var productsDictionary = new Dictionary<ProductType, List<Product>>();
            foreach (var product in products)
            {
                if (productsDictionary.ContainsKey(product.Type))
                {
                    productsDictionary[product.Type].Add(product);
                }
                else
                {
                    productsDictionary.Add(product.Type, new List<Product>());
                }
            }
            return View(productsDictionary);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Types = (await _productTypeRepository.GetAllAsync())
                .Select(p => new SelectListItem() { Text = p.Title, Value = p.Id.ToString() })
                .ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product model)
        {
            if (ModelState.IsValid)
            {
                await _productRepository.CreateAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            ViewBag.Types = (await _productTypeRepository.GetAllAsync())
                .Select(p => new SelectListItem() { Text = p.Title, Value = p.Id.ToString() })
                .ToList();
            return View(await _productRepository.GetAsync(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Product updatedModel)
        {
            try
            {
                await _productRepository.UpdateAsync(updatedModel);
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
                await _productRepository.DeleteAsync(id);
                return Json(new { success = true, message = "Запис успішно видалено" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Помилка при видаленні запису: {ex.Message}" });
            }
        }
    }
}
