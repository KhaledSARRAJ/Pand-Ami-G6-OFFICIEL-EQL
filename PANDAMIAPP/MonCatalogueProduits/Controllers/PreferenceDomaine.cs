using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MonCatalogueProduit.Service;
using GestionProduits.Service;

namespace GestionProduits.Controllers
{
    public class PreferenceDomaineController : Controller
    {
        public IActionResult PreferenceDomaine()
        {
            return View();
        }


        //on appel notre catalogue pour avoir accees a la base à l'aide d'une instance
        //à dbcontext et il faut l'ajouter dans les services dans startup
        public CatalogueDbContext dbContext { get; set; }
        //un constructeur pour l'utiliser ensuite
        public PreferenceDomaineController(CatalogueDbContext db)
        {
            this.dbContext = db;
        }

        public IActionResult FormPreferenceDomaine()
        {
            PreferenceDomaine p = new PreferenceDomaine();
            //liste de categorie = IEnumerable 
            IEnumerable<PreferenceDomaine> cats = dbContext.ListePreferenceDomaine.ToList();
            //stocker dans le viewbag la liste de categorie
            ViewBag.categories = cats;
            return View("FormPreferenceDomaine", p);
        }

        [HttpPost]
        public IActionResult SavePreferenceDomaine(PreferenceDomaine p)
        {
            IEnumerable<PreferenceDomaine> cats = dbContext.ListePreferenceDomaine.ToList();
            ViewBag.categories = cats;

            if (ModelState.IsValid)
            {
                dbContext.ListePreferenceDomaine.Add(p);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("FormPreferenceDomaine", p);

        }

    }
}
