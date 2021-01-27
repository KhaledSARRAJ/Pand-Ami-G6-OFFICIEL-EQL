using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MonCatalogueProduit.Service;

namespace GestionProduits.Service.Interfaces
{
   public  interface IDemandeRepository
    {
        IEnumerable<Demande> Demandes { get; }
        IEnumerable<Demande> PreferredDemandes { get; }
        Demande GetDemandeById(int demande);
    }
}
