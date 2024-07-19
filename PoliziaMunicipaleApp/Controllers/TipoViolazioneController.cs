using Microsoft.AspNetCore.Mvc;
using PoliziaMunicipaleApp.Models;
using PoliziaMunicipaleApp.Services;

namespace PoliziaMunicipaleApp.Controllers
{
    public class TipoViolazioneController : Controller
    {
        private readonly TipoViolazioneService _tipoViolazioneService;

        public TipoViolazioneController(IConfiguration configuration)
        {
            _tipoViolazioneService = new TipoViolazioneService(configuration);
        }

        public IActionResult Index()
        {
            var tipoViolazioni = _tipoViolazioneService.GetAllTipoViolazioni();
            return View(tipoViolazioni);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TipoViolazione tipoViolazione)
        {
            if (ModelState.IsValid)
            {
                _tipoViolazioneService.AddTipoViolazione(tipoViolazione);
                return RedirectToAction("Index");
            }
            return View(tipoViolazione);
        }
    }
}

