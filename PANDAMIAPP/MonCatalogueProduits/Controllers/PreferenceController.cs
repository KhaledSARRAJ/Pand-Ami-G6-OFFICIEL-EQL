using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionProduits.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonCatalogueProduit.Service;

namespace GestionProduits.Controllers
{
    public class PreferenceController : Controller
    {
        public CatalogueDbContext dbContext { get; set; }
        public PreferenceController(CatalogueDbContext db)
        {
            this.dbContext = db;
        }
        public IActionResult SavePreferenceJourHoraire()
        {
            PreferenceJourHoraire p = new PreferenceJourHoraire();
            IEnumerable<PreferenceJourHoraire> cats = dbContext.ListePreferenceJourHoraires;
            ViewBag.preferenceJourHoraire = cats;
            return View("SavePreferenceJourHoraire", p);

        }
        [HttpPost]
        public IActionResult SavePreferenceJourHoraire(PreferenceJourHoraire p)
        {
            IEnumerable<PreferenceJourHoraire> cats = dbContext.ListePreferenceJourHoraires;
            ViewBag.preferenceJourHoraire = cats;

            if (ModelState.IsValid)
            {
                dbContext.ListePreferenceJourHoraires.Add(p);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("", p);

        }


   
    public IActionResult SavePreferenceDomaine()
    {
        PreferenceDomaine p = new PreferenceDomaine();
        IEnumerable<PreferenceDomaine> cats = dbContext.ListePreferenceDomaine;
        ViewBag.preferenceDomaine = cats;
        return View("SavePreferenceDomaine", p);

    }
    [HttpPost]
    public IActionResult SavePreferenceDomaine(PreferenceDomaine p)
    {
        IEnumerable<PreferenceDomaine> cats = dbContext.ListePreferenceDomaine;
        ViewBag.preferenceDomaine = cats;

        if (ModelState.IsValid)
        {
            dbContext.ListePreferenceDomaine.Add(p);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        return View("", p);

    }

    
    public IActionResult SavePreferenceRayonAction()
    {
        PreferenceRayonAction p = new PreferenceRayonAction();
        IEnumerable<PreferenceRayonAction> cats = dbContext.ListePreferenceRayonAction;
        ViewBag.preferenceRayonAction = cats;
        return View("SavePreferenceRayonAction", p);

    }
    [HttpPost]
    public IActionResult SavePreferenceRayonAction(PreferenceRayonAction p)
    {
        IEnumerable<PreferenceRayonAction> cats = dbContext.ListePreferenceRayonAction;
        ViewBag.preferenceRayonAction = cats;

        if (ModelState.IsValid)
        {
            dbContext.ListePreferenceRayonAction.Add(p);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        return View("", p);

    }



    }
}
