using Microsoft.AspNetCore.Mvc;
using PoliziaMunicipaleApp.Models;

namespace PoliziaMunicipaleApp.Controllers
{
    public class AnagraficaController : Controller
    {
        private readonly YourDbContext _context = new YourDbContext();

        public ActionResult Index()
        {
            return View(_context.Anagrafiche.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Anagrafica anagrafica)
        {
            if (ModelState.IsValid)
            {
                _context.Anagrafiche.Add(anagrafica);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(anagrafica);
        }
    }

}
