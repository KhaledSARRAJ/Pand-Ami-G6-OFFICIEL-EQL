﻿using System;
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
        public IActionResult Save()
        {
            Utilisateur p = new Utilisateur();
            IEnumerable<Utilisateur> cats = dbContext.ListUtilisateurs;
            ViewBag.utilisateurs = cats;
            return View("Save", p);

        }
        [HttpPost]
        public IActionResult Save(Utilisateur p)
        {
            IEnumerable<Utilisateur> cats = dbContext.ListUtilisateurs; 
            ViewBag.utilisateurs = cats;

            if (ModelState.IsValid)
            {
                dbContext.ListUtilisateurs.Add(p);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("", p);

        }

    }
}
