using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GestionProduits.Models;
using MonCatalogueProduit.Service;

namespace GestionProduits.Controllers
{
    public class HomeController : Controller
    {
        private readonly CatalogueDbContext _dbContext;
        public HomeController(CatalogueDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Compte()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult Volontaire()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult Reglement()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
