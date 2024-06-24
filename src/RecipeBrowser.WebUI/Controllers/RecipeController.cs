using Humanizer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecipeBrowser.Core.Entities;
using RecipeBrowser.Repos.Common;
using RecipeBrowser.WebUI.Helpers;

namespace RecipeBrowser.WebUI.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IRepository<Product, Guid> _productRepository;
        private readonly IRepository<CookingDifficulty, Guid> _cookingDifficultyRepository;
        private readonly IRepository<CookingType, Guid> _cookingTypeRepository;
        private readonly IRepository<Measure, Guid> _measureRepository;
        private readonly IRepository<Recipe, Guid> _recipeRepository;
        private readonly IRepository<User, Guid> _userRepository;
        private readonly IRepository<Ingredient, Guid> _ingredientRepository;
        private readonly IRepository<ProductType, Guid> _productTypeRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public RecipeController(IRepository<Product, Guid> productRepository, 
            IRepository<CookingDifficulty, Guid> cookingDifficultyRepository, 
            IRepository<CookingType, Guid> cookingTypeRepository,
            IRepository<Measure, Guid> measureRepository,
            IRepository<Recipe, Guid> recipeRepository,
            IRepository<User, Guid> userRepository,
            IRepository<Ingredient, Guid> ingredientRepository,
            IRepository<ProductType, Guid> productTypeRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            _productRepository = productRepository;
            _cookingDifficultyRepository = cookingDifficultyRepository;
            _cookingTypeRepository = cookingTypeRepository;
            _measureRepository = measureRepository;
            _recipeRepository = recipeRepository;
            _userRepository = userRepository;
            _ingredientRepository = ingredientRepository;
            _productTypeRepository = productTypeRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index(string viewType = ViewType.Table)
        {
            var data = await _recipeRepository.GetAllAsync();
            return View($"{viewType.ApplyCase(LetterCasing.Sentence)}View", data);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Types = (await _cookingTypeRepository.GetAllAsync())
                .Select(p => new SelectListItem() { Text = p.Title, Value = p.Id.ToString() })
                .ToList();
            ViewBag.Difficulties = (await _cookingDifficultyRepository.GetAllAsync())
                .Select(p => new SelectListItem() { Text = p.Title, Value = p.Id.ToString() })
                .ToList();
            ViewBag.Products = (await _productRepository.GetAllAsync())
                .Select(p => new SelectListItem() { Text = p.Title, Value = p.Id.ToString() })
                .ToList();
            ViewBag.Measures = (await _measureRepository.GetAllAsync())
                .Select(p => new SelectListItem() { Text = p.Title, Value = p.Id.ToString() })
                .ToList();
            ViewBag.Users = (await _userRepository.GetAllAsync())
                .Select(p => new SelectListItem() { Text = p.Email, Value = p.Id.ToString() })
                .ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Recipe model, List<Ingredient> ingredients)
        {
            if (model.ImagePath == null)
            {
                model.ImagePath = "/img/recipes/no_photo.jpg";
            }
            if (model.CreatorId == Guid.Empty)
            {
                model.CreatorId = (await _userRepository.GetAllAsync()).First(u => u.Email == User.Identity.Name).Id;
            }
            if (ModelState.IsValid)
            {
                if (model.ImageFile is not null)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;

                    var currentPhotoId = Guid.NewGuid();
                    var fileExt = Path.GetExtension(model.ImageFile.FileName);
                    var filePath = Path.Combine("/img/recipes/", $"{currentPhotoId}{fileExt}");
                    string path = Path.Combine(wwwRootPath, "img\\recipes\\", $"{currentPhotoId}{fileExt}");

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        model.ImageFile.CopyTo(fileStream);
                    }

                    model.ImagePath = filePath;
                }

                var existingIngredients = await _ingredientRepository.GetAllAsync();
                for (int i = 0; i < ingredients.Count(); i++)
                {
                    if (existingIngredients.Any(ing => ing.Amount == ingredients[i].Amount
                        && ing.MeasureId == ingredients[i].MeasureId
                        && ing.ProductId == ingredients[i].ProductId))
                    {
                        ingredients[i] = existingIngredients.First(ing => ing.Amount == ingredients[i].Amount
                            && ing.MeasureId == ingredients[i].MeasureId
                            && ing.ProductId == ingredients[i].ProductId);
                    }
                }

                model.Ingredients = ingredients;

                await _recipeRepository.CreateAsync(model);
                if(User.IsInRole("Admin"))
                {
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(UserView));
            }
            ViewBag.Types = (await _cookingTypeRepository.GetAllAsync())
                .Select(p => new SelectListItem() { Text = p.Title, Value = p.Id.ToString() })
                .ToList();
            ViewBag.Difficulties = (await _cookingDifficultyRepository.GetAllAsync())
                .Select(p => new SelectListItem() { Text = p.Title, Value = p.Id.ToString() })
                .ToList();
            ViewBag.Products = (await _productRepository.GetAllAsync())
                .Select(p => new SelectListItem() { Text = p.Title, Value = p.Id.ToString() })
                .ToList();
            ViewBag.Measures = (await _measureRepository.GetAllAsync())
                .Select(p => new SelectListItem() { Text = p.Title, Value = p.Id.ToString() })
                .ToList();
            ViewBag.Users = (await _userRepository.GetAllAsync())
                .Select(p => new SelectListItem() { Text = p.Email, Value = p.Id.ToString() })
                .ToList();

            return View(model);
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            var recipe = await _recipeRepository.GetAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }

            ViewBag.Types = (await _cookingTypeRepository.GetAllAsync())
                .Select(p => new SelectListItem() { Text = p.Title, Value = p.Id.ToString() })
                .ToList();
            ViewBag.Difficulties = (await _cookingDifficultyRepository.GetAllAsync())
                .Select(p => new SelectListItem() { Text = p.Title, Value = p.Id.ToString() })
                .ToList();
            ViewBag.Products = (await _productRepository.GetAllAsync())
                .Select(p => new SelectListItem() { Text = p.Title, Value = p.Id.ToString() })
                .ToList();
            ViewBag.Measures = (await _measureRepository.GetAllAsync())
                .Select(p => new SelectListItem() { Text = p.Title, Value = p.Id.ToString() })
                .ToList();
            ViewBag.Users = (await _userRepository.GetAllAsync())
                .Select(p => new SelectListItem() { Text = p.Email, Value = p.Id.ToString() })
                .ToList();

            return View(recipe);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Recipe updatedModel, List<Ingredient> ingredients)
        {
            if (updatedModel.ImagePath == null)
            {
                updatedModel.ImagePath = "/img/recipes/no_photo.jpg";
            }
            if (ModelState.IsValid)
            {
                if (updatedModel.ImageFile is not null)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;

                    var currentPhotoId = Guid.NewGuid();
                    var fileExt = Path.GetExtension(updatedModel.ImageFile.FileName);
                    var filePath = Path.Combine("/img/recipes/", $"{currentPhotoId}{fileExt}");
                    string path = Path.Combine(wwwRootPath, "img\\recipes\\", $"{currentPhotoId}{fileExt}");

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        updatedModel.ImageFile.CopyTo(fileStream);
                    }

                    updatedModel.ImagePath = filePath;
                }

                var existingIngredients = await _ingredientRepository.GetAllAsync();
                var currentRecipe = await _recipeRepository.GetAsync(updatedModel.Id);

                // Remove existing ingredients relationships
                currentRecipe.Ingredients.Clear();

                foreach (var ingredient in ingredients)
                {
                    var existingIngredient = existingIngredients.FirstOrDefault(ei =>
                        ei.ProductId == ingredient.ProductId &&
                        ei.MeasureId == ingredient.MeasureId &&
                        ei.Amount == ingredient.Amount);

                    if (existingIngredient != null)
                    {
                        currentRecipe.Ingredients.Add(existingIngredient);
                    }
                    else
                    {
                        await _ingredientRepository.CreateAsync(ingredient);
                        currentRecipe.Ingredients.Add(ingredient);
                    }
                }

                if (currentRecipe != null)
                {
                    currentRecipe.Title = updatedModel.Title;
                    currentRecipe.Description = updatedModel.Description;
                    currentRecipe.DifficultyId = updatedModel.DifficultyId;
                    currentRecipe.TypeId = updatedModel.TypeId;
                    currentRecipe.CreatorId = updatedModel.CreatorId;
                    currentRecipe.Description = updatedModel.Description;
                    currentRecipe.ImagePath = updatedModel.ImagePath;
                    currentRecipe.CookDuration = updatedModel.CookDuration;
                }

                await _recipeRepository.UpdateAsync(currentRecipe);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Types = (await _cookingTypeRepository.GetAllAsync())
                .Select(p => new SelectListItem() { Text = p.Title, Value = p.Id.ToString() })
                .ToList();
            ViewBag.Difficulties = (await _cookingDifficultyRepository.GetAllAsync())
                .Select(p => new SelectListItem() { Text = p.Title, Value = p.Id.ToString() })
                .ToList();
            ViewBag.Products = (await _productRepository.GetAllAsync())
                .Select(p => new SelectListItem() { Text = p.Title, Value = p.Id.ToString() })
                .ToList();
            ViewBag.Measures = (await _measureRepository.GetAllAsync())
                .Select(p => new SelectListItem() { Text = p.Title, Value = p.Id.ToString() })
                .ToList();
            ViewBag.Users = (await _userRepository.GetAllAsync())
                .Select(p => new SelectListItem() { Text = p.Email, Value = p.Id.ToString() })
                .ToList();

            return View(updatedModel);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _recipeRepository.DeleteAsync(id);
                return Json(new { success = true, message = "Запис успішно видалено" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Помилка при видаленні запису: {ex.Message}" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var user = (await _userRepository.GetAllAsync()).First(u => u.Email == User.Identity.Name);
            var collections = user.RecipeCollecitons.ToList();
            ViewBag.Collections = collections.Select(rc => new SelectListItem() { Text = rc.Title, Value = rc.Id.ToString()}).ToList();
            return View(await _recipeRepository.GetAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> UserView(List<Guid> difficultyIds, List<Guid> typeIds, List<Guid> bannedProductTypes)
        {
            ViewBag.CookingTypes = (await _cookingTypeRepository.GetAllAsync())
               .Select(p => new SelectListItem() { Text = p.Title, Value = p.Id.ToString() })
               .ToList();
            ViewBag.Difficulties = (await _cookingDifficultyRepository.GetAllAsync())
                .Select(p => new SelectListItem() { Text = p.Title, Value = p.Id.ToString() })
                .ToList();
            ViewBag.ProductTypes = (await _productTypeRepository.GetAllAsync())
                .Select(p => new SelectListItem() { Text = p.Title, Value = p.Id.ToString() })
                .ToList();
            var data = await _recipeRepository.GetAllAsync();
            
            if (difficultyIds.Count() != 0)
            {
                data = data.Where(r => difficultyIds.Contains(r.DifficultyId));
            }
            if (typeIds.Count() != 0)
            {
                data = data.Where(r => typeIds.Contains(r.TypeId));
            }
            if (bannedProductTypes.Count() != 0)
            {
                data = data.Where(r => !r.Ingredients.Any(ing => bannedProductTypes.Contains(ing.Product.TypeId)));
            }
            
            data = data.ToList();
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> UserRecipes(Guid id, List<Guid> difficultyIds, List<Guid> typeIds, List<Guid> bannedProductTypes)
        {
            var data = (await _recipeRepository.GetAllAsync()).Where(r => r.CreatorId == id);
            ViewBag.CookingTypes = (await _cookingTypeRepository.GetAllAsync())
               .Select(p => new SelectListItem() { Text = p.Title, Value = p.Id.ToString() })
               .ToList();
            ViewBag.Difficulties = (await _cookingDifficultyRepository.GetAllAsync())
                .Select(p => new SelectListItem() { Text = p.Title, Value = p.Id.ToString() })
                .ToList();
            ViewBag.ProductTypes = (await _productTypeRepository.GetAllAsync())
                .Select(p => new SelectListItem() { Text = p.Title, Value = p.Id.ToString() })
                .ToList();

            if (difficultyIds.Count() != 0)
            {
                data = data.Where(r => difficultyIds.Contains(r.DifficultyId));
            }
            if (typeIds.Count() != 0)
            {
                data = data.Where(r => typeIds.Contains(r.TypeId));
            }
            if (bannedProductTypes.Count() != 0)
            {
                data = data.Where(r => !r.Ingredients.Any(ing => bannedProductTypes.Contains(ing.Product.TypeId)));
            }

            data = data.ToList();
            return View(data);
        }
    }
}
