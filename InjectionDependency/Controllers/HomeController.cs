using System.Diagnostics;
using InjectionDependency.Models;
using Microsoft.AspNetCore.Mvc;

namespace InjectionDependency.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbContextShoopDb _context;

        public HomeController(ILogger<HomeController> logger, DbContextShoopDb context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var lst = _context.DtProducts.ToList();
            return View(lst);
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
