
using Microsoft.AspNetCore.Mvc;
using MonCatalogueProduit.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProduits.Components
{
    public class CategoryMenu:ViewComponent
    {
        private readonly CatalogueDbContext _categoryRepository;
        public CategoryMenu(CatalogueDbContext categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepository.ListeCategories.OrderBy(p => p.LibelleDomaine);
            return View(categories);
        }
    }
}
