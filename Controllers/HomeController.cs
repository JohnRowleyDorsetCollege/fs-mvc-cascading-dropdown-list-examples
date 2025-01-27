using System.Diagnostics;
using CascadingDropDownList.Models;
using Microsoft.AspNetCore.Mvc;

namespace CascadingDropDownList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private static readonly Dictionary<string, List<string>> CountryStateData = new()
    {
        { "USA", new List<string> { "California", "Texas", "Florida" } },
        { "Canada", new List<string> { "Ontario", "Quebec", "British Columbia" } },
        { "India", new List<string> { "Maharashtra", "Karnataka", "Delhi" } }
    };
        public IActionResult Index()
        {
            ViewBag.Countries = CountryStateData.Keys;
            return View();
        }


        [HttpGet]
        public JsonResult GetStates(string country)
        {
            if (CountryStateData.TryGetValue(country, out var states))
            {
                return Json(states);
            }
            return Json(new List<string>());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
