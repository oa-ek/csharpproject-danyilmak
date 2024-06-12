using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using RecipeBrowser.Core.Entities;
using RecipeBrowser.Core.Entities.Recipes;
using RecipeBrowser.Repos.Recipes;
using RecipeBrowser.Repos.Reviews;
using RecipeBrowser.Repos.Users;
using RecipeBrowser.WebUI.Helpers;
using System.Linq;

namespace RecipeBrowser.WebUI.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IUserRepository _userRepository;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public ReviewController(
            IReviewRepository reviewRepository,
            IRecipeRepository recipeRepository,
            IUserRepository userRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            _reviewRepository = reviewRepository;
            _recipeRepository = recipeRepository;
            _userRepository = userRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index(string viewType = ViewType.Table)
        {
            var data = await _reviewRepository.GetAllAsync();
            return View($"{viewType.ApplyCase(LetterCasing.Sentence)}View", data);
        }

        // GET: ReviewController/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            return View(await _reviewRepository.GetAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Recipes = (await _recipeRepository
                .GetAllAsync())
                .Select(x => new SelectListItem { Text = x.Title, Value = x.Id.ToString() }).ToList();
            ViewBag.Users = (await _userRepository
                .GetAllAsync())
                .Select(x => new SelectListItem { Text = x.FullName, Value = x.Id.ToString() }).ToList();

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

            return View(model);
        }

        // GET: ReviewController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            ViewBag.Recipes = (await _recipeRepository
                .GetAllAsync())
                .Select(x => new SelectListItem { Text = x.Title, Value = x.Id.ToString() }).ToList();
            ViewBag.Users = (await _userRepository
                .GetAllAsync())
                .Select(x => new SelectListItem { Text = x.FullName, Value = x.Id.ToString() }).ToList();

            return View(await _reviewRepository.GetAsync(id));
        }

        // POST: ReviewController/Edit/5
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

        // GET: ReviewController/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            return View(await _reviewRepository.GetAsync(id));
        }

        // POST: ReviewController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, IFormCollection form)
        {
            try
            {
                await _reviewRepository.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Delete", new { id = id });
            }
        }
    }
}