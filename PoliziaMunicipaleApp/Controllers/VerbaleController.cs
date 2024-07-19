using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PoliziaMunicipaleApp.Models;
using PoliziaMunicipaleApp.Services;

namespace PoliziaMunicipaleApp.Controllers
{
    public class VerbaleController : Controller
    {
        private readonly VerbaleService _verbaleService;
        private readonly AnagraficaService _anagraficaService;
        private readonly TipoViolazioneService _tipoViolazioneService;

        public VerbaleController(IConfiguration configuration)
        {
            _verbaleService = new VerbaleService(configuration);
            _anagraficaService = new AnagraficaService(configuration);
            _tipoViolazioneService = new TipoViolazioneService(configuration);
        }

        public IActionResult Index()
        {
            var verbali = _verbaleService.GetAllVerbali();
            return View(verbali);
        }

        public IActionResult Create()
        {
            ViewBag.Idanagrafica = new SelectList(_anagraficaService.GetAllAnagrafiche(), "Idanagrafica", "Cognome");
            ViewBag.Idviolazione = new SelectList(_tipoViolazioneService.GetAllTipoViolazioni(), "Idviolazione", "Descrizione");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Verbale verbale)
        {
            if (ModelState.IsValid)
            {
                _verbaleService.AddVerbale(verbale);
                return RedirectToAction("Index");
            }
            ViewBag.Idanagrafica = new SelectList(_anagraficaService.GetAllAnagrafiche(), "Idanagrafica", "Cognome", verbale.Idanagrafica);
            ViewBag.Idviolazione = new SelectList(_tipoViolazioneService.GetAllTipoViolazioni(), "Idviolazione", "Descrizione", verbale.Idviolazione);
            return View(verbale);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var success = _verbaleService.DeleteVerbale(id);
            if (success)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false, message = "Error deleting record." });
            }
        }
    }
}

