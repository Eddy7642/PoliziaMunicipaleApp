using Microsoft.AspNetCore.Mvc;
using PoliziaMunicipaleApp.Models;

namespace PoliziaMunicipaleApp.Controllers
{
    public class TipoViolazioneController : Controller
    {
        private readonly YourDbContext _context = new YourDbContext();

        public ActionResult Index()
        {
            return View(_context.TipoViolazioni.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TipoViolazione tipoViolazione)
        {
            if (ModelState.IsValid)
            {
                _context.TipoViolazioni.Add(tipoViolazione);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoViolazione);
        }
    }

}
