using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionProduits.Service;

namespace GestionProduits.ViewModels
{
    public class UtilisateursListViewModel
    {
        public IEnumerable<Utilisateur> Utilisateurs { get; set; }

    }
}
