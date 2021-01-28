﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MonCatalogueProduit.Service;

namespace GestionProduits.Service
{
    [Table("CATEGORIEACTIVITE")]
    public class Categorie
    {
        [Key]
        public int CategoriesID { get; set; }
        public string LibelleDomaine { get; set; }
        [StringLength(80)]
        public int CategorieDomainesID { get; set; }
        [ForeignKey("DomaineID")]
        //public int MaterielID { get; set; }
       // [ForeignKey("MaterielID")]
        //public virtual Materiel DomaineActiviteMateriel { get; set; }
       public virtual Domaine domaine { get ;set ;}
        public virtual ICollection<Demande> Domaineactivtedemande { get; set; }
        public virtual ICollection<PreferenceDomaine> DomaineActivitePreferenceDomaine { get; set; }
    }
}
