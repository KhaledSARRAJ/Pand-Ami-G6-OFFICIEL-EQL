using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionProduits.Service
{
    [Table("DOMAINESTAB")]
    public class Domaine
    {
        [Key]
        public int DomaineID { get; set; }
        
        public string NomDomaine { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Categorie> DomaineCategorie { get; set; }
        public int CategoriesID { get; set; }
    }
}
