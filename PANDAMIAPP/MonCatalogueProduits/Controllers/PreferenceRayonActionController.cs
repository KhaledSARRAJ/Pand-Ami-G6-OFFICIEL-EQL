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
    public class PreferenceRayonActionController : Controller
    {
        public IActionResult PreferenceRayonAction()
        {
            return View();
        }


        //on appel notre catalogue pour avoir accees a la base à l'aide d'une instance
        //à dbcontext et il faut l'ajouter dans les services dans startup
        public CatalogueDbContext dbContext { get; set; }
        //un constructeur pour l'utiliser ensuite
        public PreferenceRayonActionController(CatalogueDbContext db)
        {
            this.dbContext = db;
        }

        public IActionResult FormPreferenceRayonAction()
        {
            PreferenceRayonAction p = new PreferenceRayonAction();
            //liste de categorie = IEnumerable 
            IEnumerable<PreferenceRayonAction> cats = dbContext.ListePreferenceRayonAction.ToList();
            //stocker dans le viewbag la liste de categorie
            ViewBag.categories = cats;
            return View("FormPreferenceRayonAction", p);
        }

        [HttpPost]
        public IActionResult SavePreferenceRayonAction(PreferenceRayonAction p)
        {
            IEnumerable<PreferenceRayonAction> cats = dbContext.ListePreferenceRayonAction.ToList();
            ViewBag.categories = cats;

            if (ModelState.IsValid)
            {
                dbContext.ListePreferenceRayonAction.Add(p);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("FormPreferenceRayonAction", p);

        }

    }
}
