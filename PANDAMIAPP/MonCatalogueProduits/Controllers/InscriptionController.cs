using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionProduits.Service;
using Microsoft.AspNetCore.Mvc;
using MonCatalogueProduit.Service;

namespace GestionProduits.Controllers
{
    public class InscriptionController : Controller
    {
        public CatalogueDbContext dbContext { get; set; }
        public InscriptionController(CatalogueDbContext db)
        {
            this.dbContext = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            Utilisateur userModel = new Utilisateur();
            return View(userModel);
        }
        [HttpPost]
        public ActionResult AddOrEdit(Utilisateur userModel)
        {
            using (dbContext)
            {
                dbContext.ListUtilisateurs.Add(userModel);
                dbContext.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Vous êtes bien enregistrer";
            return View("AddOrEdit", new Utilisateur());

        }
    }
}
