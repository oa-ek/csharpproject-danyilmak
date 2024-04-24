using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using RecipeBrowser.Core.Entities.Recipes;
using RecipeBrowser.Repos.Common;
using RecipeBrowser.WebUI.Models;
using System.Diagnostics;

namespace RecipeBrowser.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Recipe, Guid> repository;
        public HomeController(ILogger<HomeController> logger,
            IRepository<Recipe, Guid> repository)
        {
            _logger = logger;
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View(repository.GetAllAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
