using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonCatalogueProduit.Service;
/*

namespace MonCatalogueProduit.Controllers
{
    //heritage
    public class ProduitController : Controller
    {
        //on appel notre catalogue pour avoir accees a la base à l'aide d'une instance
        //à dbcontext et il faut l'ajouter dans les services dans startup
        public CatalogueDbContext dbContext { get; set; }
        //un constructeur pour l'utiliser ensuite
        public ProduitController(CatalogueDbContext db) 
        {
            this.dbContext = db;
        }


        // GET: Produit/Index/
        //page par defaut égal 0
        // size: nombre de produit 5 par page (un choix)
         public IActionResult Index(int page=0,int size=5,string motCle="")
        {
            //pour définir la pagination exp: (1/5)
            int position = page * size;
            //pour recuperer tout les produits
            IEnumerable<Demande> produits = 
          dbContext.Demandes.Where(p=>p.Description.Contains(motCle)).Skip(position).Take(size).Include(p=>p.domainesactiviterDemande).ToList();//c'est  la methode syntax link (on peut utiliser le query syntax): select form where
            //stocker dans le controleur la page courrante
            ViewBag.currentPage = page;
            int totalPages;
            int nbreProduit = dbContext.Demandes.Where(p => p.Description.Contains(motCle)).ToList().Count;
            if(nbreProduit % size ==0 ) { 
                 totalPages = nbreProduit/size;
            }else{
                totalPages = 1+ nbreProduit / size ;
            }
            ViewBag.totalPages = totalPages;
            ViewBag.motCle = motCle;
            return View("Demandes",produits);//afficher tout les produits
        }

        public IActionResult FormProduit()
        {
            Demande p = new Demande();
            //liste de categorie = IEnumerable 
            IEnumerable<DomaineActivite> cats = dbContext.ListeDomaineActiviter.ToList();
           //stocker dans le viewbag la liste de categorie
            ViewBag.categories = cats;
            return View("FormProduit",p);
        }

        [HttpPost]
        public IActionResult SaveProduit(Demande p)
        {
            IEnumerable<DomaineActivite> cats = dbContext.ListeDomaineActiviter.ToList();
            ViewBag.categories = cats;

            if (ModelState.IsValid)
            {
                dbContext.Demandes.Add(p);
                dbContext.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View("FormProduit", p);

        }
        //Ici on doit ajouter pour la demande  les methodes restantes: Update, Delete (ajouter, FindAll c fait)

    }
}
*/