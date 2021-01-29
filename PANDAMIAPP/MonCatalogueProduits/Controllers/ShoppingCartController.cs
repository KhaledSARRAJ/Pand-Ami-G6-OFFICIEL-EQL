using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionProduits.Service;

using GestionProduits.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;
using MonCatalogueProduit.Service;

namespace GestionProduits.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly CatalogueDbContext _demandeRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(CatalogueDbContext demandeRepository, ShoppingCart shoppingCart)
        {
            _demandeRepository = demandeRepository;
            _shoppingCart = shoppingCart;
        }
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(shoppingCartViewModel);
        }
        public RedirectToActionResult AddToShoppingCart(int demandeId)
        {
            var selectedDemande = _demandeRepository.ListeDemandes.FirstOrDefault(p => p.DemandeID == demandeId);
            if (selectedDemande != null)
            {
                _shoppingCart.AddToCart(selectedDemande, 1);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveFromShoppingCart(int demandeId)
        {
            var selectedDemande = _demandeRepository.ListeDemandes.FirstOrDefault(p => p.DemandeID == demandeId);
            if (selectedDemande != null)
            {
                _shoppingCart.RemoveFromCart(selectedDemande);
            }
            return RedirectToAction("Index");
        }
    }
}
