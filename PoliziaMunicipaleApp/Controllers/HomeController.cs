using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PoliziaMunicipaleApp.Models;

namespace PoliziaMunicipaleApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            
            ViewData["Message"] = "Benvenuto all'applicazione Polizia Municipale";

            return View();
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
