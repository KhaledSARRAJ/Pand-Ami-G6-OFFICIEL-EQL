using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionProduits.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<Demande> Demandes => _appDbContext.ListeDemandes.Include(c => c.categorieDemande)
                .ToList();

        public IEnumerable<Demande> PreferredDemandes => _appDbContext.ListeDemandes.Where(p => p.IsPreferredDemande).Include(c => c.categorieDemande);

        public Demande GetDemandeById(int demandeId) => _appDbContext.ListeDemandes.FirstOrDefault(p => p.DemandeID == demandeId);
    }

}
