using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonCatalogueProduit.Service;
using MonCatalogueProduit.Service.interfaces;

namespace GestionProduits.Controllers
{
    public class DemandeController : Controller
    {
        public IDemandeService metier { get; set; }


        public DemandeController(IDemandeService metier)
        {
            this.metier = metier;
        }


        // GET: /<controller>/
        public ActionResult Index()
        {
            IEnumerable<Demande> prods = metier.FindAll();


            return View("Demandes", prods);
        }


        public ActionResult Chercher(string motCle)
        {
            if (motCle == null)
            {
                ModelState.AddModelError("motCle", "il faut saisir un mot clé");
            }

            if (ModelState.IsValid)
            {

                IEnumerable<Demande> prodsParMC = metier.DemandeParMC(motCle);

                ViewBag.motCle = motCle;
                return View("Demandes", prodsParMC);
            }
            else
            {
                return View("Demandes", metier.FindAll());
            }
        }


        public ActionResult DemandeForm()
        {

            Demande demande = new Demande();

            return View("DemandeForm", demande);
        }


        [HttpPost]
        public ActionResult SaveDemande(Demande demande)
        {

            if (ModelState.IsValid)
            {
                metier.Save(demande);
                return RedirectToAction("Index");
            }
            else
            {
                return View("DemandeForm");
            }

        }


        [HttpGet]  //optionnelle
        public ActionResult Delete(int ID)
        {
            metier.Delete(ID);
            return RedirectToAction("Index");
        }


        public ActionResult Editer(int ID)
        {
            Demande p = metier.GetOne(ID);
            return View("DemandeFormEdit", p);
        }

        public ActionResult Update(Demande p)
        {
            if (ModelState.IsValid)
            {
                metier.Update(p);
                return RedirectToAction("Index");
            }
            else
            {
                return View("DemandeFormEdit");
            }
        }

    }
}