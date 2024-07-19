using Microsoft.AspNetCore.Mvc;
using PoliziaMunicipaleApp.Models;
using PoliziaMunicipaleApp.Services;

namespace PoliziaMunicipaleApp.Controllers
{
    public class AnagraficaController : Controller
    {
        private readonly AnagraficaService _anagraficaService;

        public AnagraficaController(IConfiguration configuration)
        {
            _anagraficaService = new AnagraficaService(configuration);
        }

        public IActionResult Index()
        {
            var anagrafiche = _anagraficaService.GetAllAnagrafiche();
            return View(anagrafiche);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Anagrafica anagrafica)
        {
            if (ModelState.IsValid)
            {
                _anagraficaService.AddAnagrafica(anagrafica);
                return RedirectToAction("Index");
            }
            return View(anagrafica);
        }
    }

}
