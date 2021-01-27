
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MonCatalogueProduit.Service;

namespace GestionProduits.Service.ViewModels
{
    public class DemandesListViewModel
    {



        public IEnumerable<Demande> Demandes { get; set; }
        public string CurrentCategory { get; set; }
    }
}
