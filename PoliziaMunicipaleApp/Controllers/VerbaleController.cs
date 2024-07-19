using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PoliziaMunicipaleApp.Models;

namespace PoliziaMunicipaleApp.Controllers
{
    public class VerbaleController : Controller
    {
        private readonly YourDbContext _context = new YourDbContext();

        public ActionResult Index()
        {
            var verbali = _context.Verbali.Include(v => v.Anagrafica).Include(v => v.TipoViolazione).ToList();
            return View(verbali);
        }

        public ActionResult Create()
        {
            ViewBag.Idanagrafica = new SelectList(_context.Anagrafiche, "Idanagrafica", "Cognome");
            ViewBag.Idviolazione = new SelectList(_context.TipoViolazioni, "Idviolazione", "Descrizione");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Verbale verbale)
        {
            if (ModelState.IsValid)
            {
                _context.Verbali.Add(verbale);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Idanagrafica = new SelectList(_context.Anagrafiche, "Idanagrafica", "Cognome", verbale.Idanagrafica);
            ViewBag.Idviolazione = new SelectList(_context.TipoViolazioni, "Idviolazione", "Descrizione", verbale.Idviolazione);
            return View(verbale);
        }
    }

}
