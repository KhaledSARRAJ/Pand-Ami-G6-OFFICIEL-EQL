using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionProduits.Service.Interfaces;
using MonCatalogueProduit.Service;

namespace GestionProduits.Service.Repositorie
{
    public class DemandeRepository : IDemandeRepository
    {
        private readonly CatalogueDbContext _appDbContext;
        public DemandeRepository(CatalogueDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Demande> Demandes => _appDbContext.ListeDemandes.Include(c => c.Catego);

        public IEnumerable<Demande> PreferredDrinks => _appDbContext.ListeDemandes.Where(p => p.IsPreferredDemande).Include(c => c.Category);

        public Demande GetDrinkById(int demandeId) => _appDbContext.ListeDemandes.FirstOrDefault(p => p.DrinkId == drinkId);
    }

}
