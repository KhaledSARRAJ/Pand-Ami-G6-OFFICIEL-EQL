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
    public class PreferenceJourHoraireController : Controller
    {
        public IActionResult PreferenceJourHoraire()
        {
            return View();
        }

            
        //on appel notre catalogue pour avoir accees a la base à l'aide d'une instance
        //à dbcontext et il faut l'ajouter dans les services dans startup
        public CatalogueDbContext dbContext { get; set; }
        //un constructeur pour l'utiliser ensuite
         public PreferenceJourHoraireController(CatalogueDbContext db)
            {
                this.dbContext = db;
            }

        public IActionResult FormPreferenceJourHoraire()
        {
            PreferenceJourHoraire p = new PreferenceJourHoraire();
            //liste de categorie = IEnumerable 
            IEnumerable<PreferenceJourHoraire> cats = dbContext.ListePreferenceJourHoraires.ToList();
            //stocker dans le viewbag la liste de categorie
            ViewBag.categories = cats;
            return View("FormPreferenceJourHoraire", p);
        }

        [HttpPost]
        public IActionResult SavePreferenceJourHoraire(PreferenceJourHoraire p)
        {
            IEnumerable<PreferenceJourHoraire> cats = dbContext.ListePreferenceJourHoraires.ToList();
            ViewBag.categories = cats;

            if (ModelState.IsValid)
            {
                dbContext.ListePreferenceJourHoraires.Add(p);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("FormPreferenceJourHoraire", p);

        }

    }
}
