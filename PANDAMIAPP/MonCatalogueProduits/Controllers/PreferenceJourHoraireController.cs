using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MonCatalogueProduit.Service;
using GestionProduits.Service;
using System.Web.Mvc;

namespace GestionProduits.Controllers
{
    public class PreferenceJourHoraireController : System.Web.Mvc.Controller
    {


        //on appel notre catalogue pour avoir accees a la base à l'aide d'une instance
        //à dbcontext et il faut l'ajouter dans les services dans startup
        public CatalogueDbContext dbContext { get; set; }
        //un constructeur pour l'utiliser ensuite
        public PreferenceJourHoraireController(CatalogueDbContext db)
        {
            this.dbContext = db;
        }



        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetPreferenceJourHoraire()
        {
            using (CatalogueDbContext db = new CatalogueDbContext())
            {
                var PreferenceJourHoraire = db.ListePreferenceJourHoraires.ToList();
                return new JsonResult { Data = PreferenceJourHoraire, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

    }

}
