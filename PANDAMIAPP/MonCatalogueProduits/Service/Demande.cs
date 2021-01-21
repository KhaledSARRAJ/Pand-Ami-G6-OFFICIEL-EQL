using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using GestionProduits.Service;

namespace MonCatalogueProduit.Service
{
    [Table("DEMANDES")]  //Nom de table à manipuler
    public class Demande
    {
        [Key]
        public int DemandeID { get; set; }
        [Required, MinLength(6), MaxLength(70)] //
                                                // [StringLength(70)] // taille 
        public DateTime DateEnregistrementDemande { get; set; }
        // [Required,Range(10,500000)]
        public DateTime DatedeRealisation { get; set; }
        public DateTime heureSouhaitee { get; set; }
        public string Description { get; set; }
        public DateTime DateClotureDemande { get; set; }
        public DateTime DateModification { get; set; }
        public DateTime DateAnnulationDemande { get; set; }
        public string adressesecondaire { get; set; }
        public int IdentifiantDomaine { get; set; }
        [ForeignKey("DomaineActID")]  // clè etranger
        public int IdentifiantMateriel{ get; set; }
        [ForeignKey("MaterielID")]
        public int IdentifiantMAnnulation { get; set; }
        [ForeignKey("MotifAnnulationID")]
        public int IdentifiantUtilisateur { get; set; }
        [ForeignKey("UtilisateurID")]
        public Utilisateur DemandeUtilisateur { get; set; }

        //lazy loading : eviter de charger les entités lièes en mèmoire sans en avoir besoin
        //include aprés pour l'appeler
        public virtual DomaineActivite Domactiviter { get; set; }
        public virtual Materiel materiels { get; set; }
        public virtual ICollection<Reponse> DemandeReponse {get; set;}
        public virtual ICollection<Satisfaction> DemandeSatisfaction { get; set; }
        public virtual ICollection<Concertation> DemandeConcertation { get; set; }
        public virtual ICollection<Demande> RecurrenceDemande { get; set; }
    }
}
