using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using RecipeBrowser.Core.Entities.Recipes;
using RecipeBrowser.Repos.Recipes;
using RecipeBrowser.Repos.Users;
using RecipeBrowser.WebUI.Helpers;

namespace RecipeBrowser.WebUI.Controllers
{
    public class RecipesController:Controller
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IUserRepository _userRepository;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public RecipesController(
            IRecipeRepository recipeRepository,
            IUserRepository userRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            _recipeRepository = recipeRepository;
            _userRepository = userRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index(string viewType = ViewType.Table)
        {
            var data = await _recipeRepository.GetAllAsync();
            return View($"{viewType.ApplyCase(LetterCasing.Sentence)}View", data);
        }

        // GET: RecipesController/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            return View(await _recipeRepository.GetAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Users = (await _userRepository
                .GetAllAsync())
                .Select(x => new SelectListItem { Text = x.FullName, Value = x.Id.ToString() }).ToList();

            return View(new Recipe());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Recipe model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile is not null)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;

                    var fileExt = Path.GetExtension(model.ImageFile.FileName);
                    var filePath = Path.Combine("/img/recipes/", $"{model.Id}{fileExt}");
                    string path = Path.Combine(wwwRootPath, "img\\recipes\\", $"{model.Id}{fileExt}");

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        model.ImageFile.CopyTo(fileStream);
                    }

                    model.ImagePath = filePath;
                }

                await _recipeRepository.CreateAsync(model);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: RecipesController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            return View(await _recipeRepository.GetAsync(id));
        }

        // POST: RecipesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RecipesController/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            return View(await _recipeRepository.GetAsync(id));
        }

        // POST: RecipesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, IFormCollection form)
        {
            try
            {
                await _recipeRepository.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Delete", new { id = id });
            }
        }
    }
}
