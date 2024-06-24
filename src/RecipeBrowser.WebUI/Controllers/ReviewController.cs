using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using RecipeBrowser.Core.Entities;
using RecipeBrowser.Repos.Common;

namespace RecipeBrowser.WebUI.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IRepository<Review, Guid> _reviewRepository;
        private readonly IRepository<Recipe, Guid> _recipeRepository;
        private readonly IRepository<User, Guid> _userRepository;
        public ReviewController(
            IRepository<Review, Guid> reviewRepository,
            IRepository<Recipe, Guid> recipeRepository,
            IRepository<User, Guid> userRepository)
        {
            _reviewRepository = reviewRepository;
            _recipeRepository = recipeRepository;
            _userRepository = userRepository;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _reviewRepository.GetAllAsync();
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Users = (await _userRepository
                .GetAllAsync())
                .Select(x => new SelectListItem { Text = x.Email, Value = x.Id.ToString() }).ToList();
            ViewBag.Recipes = (await _recipeRepository
                .GetAllAsync())
                .Select(x => new SelectListItem { Text = x.Title, Value = x.Id.ToString() }).ToList();

            return View(new Review());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Review model)
        {
            if (ModelState.IsValid)
            {
                await _reviewRepository.CreateAsync(model);

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Users = (await _userRepository
                .GetAllAsync())
                .Select(x => new SelectListItem { Text = x.Email, Value = x.Id.ToString() }).ToList();
            ViewBag.Recipes = (await _recipeRepository
                .GetAllAsync())
                .Select(x => new SelectListItem { Text = x.Title, Value = x.Id.ToString() }).ToList();

            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            ViewBag.Users = (await _userRepository
                .GetAllAsync())
                .Select(x => new SelectListItem { Text = x.Email, Value = x.Id.ToString() }).ToList();
            ViewBag.Recipes = (await _recipeRepository
                .GetAllAsync())
                .Select(x => new SelectListItem { Text = x.Title, Value = x.Id.ToString() }).ToList();

            return View(await _reviewRepository.GetAsync(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Review updatedModel)
        {
            try
            {
                await _reviewRepository.UpdateAsync(updatedModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Users = (await _userRepository
                .GetAllAsync())
                .Select(x => new SelectListItem { Text = x.Email, Value = x.Id.ToString() }).ToList();
                ViewBag.Recipes = (await _recipeRepository
                    .GetAllAsync())
                    .Select(x => new SelectListItem { Text = x.Title, Value = x.Id.ToString() }).ToList();
                return View();
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _reviewRepository.DeleteAsync(id);
                return Json(new { success = true, message = "Запис успішно видалено" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Помилка при видаленні запису: {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserReview(Guid recipeId, string comment, string rating)
        {
            rating = rating.Replace('.', ',');
            var reviews = await _reviewRepository.GetAllAsync();
            var currentUserId = (await _userRepository.GetAllAsync()).First(u => u.Email == User.Identity.Name).Id;

            if (reviews.Any(r => r.RecipeId == recipeId && r.UserId == currentUserId))
            {
                return Json(new { success = false, message = $"Подібний запис вже існує" });

            }

            Review model = new Review()
            {
                Comment = comment,
                RecipeId = recipeId,
                UserId = currentUserId,
                Rating = float.Parse(rating),
                CreationTime = DateTime.Now
            };

            try
            {
                await _reviewRepository.CreateAsync(model);
                return Json(new { success = true, message = "Запис успішно створено" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Помилка при створенні запису: {ex.Message}" });
            }
        }
    }
}
