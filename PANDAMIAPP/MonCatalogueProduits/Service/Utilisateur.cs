using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MonCatalogueProduit.Service;

namespace GestionProduits.Service
{  
   
    [Table("UTILISATEUR")]
    public class Utilisateur
    {
        [Key]
        public int UtilisateurID { get; set; }
        public string Nom { get; set; }
       // [Required StringLength(40)]
        public string Prenom { get; set; }
        //[StringLength(40)]
        public DateTime DateDeNaissance { get; set; }
       [Required(ErrorMessage ="Ce Champs est obligatoire !!")]
        public string NomUtilisateur { get; set; }
      //  [Required(ErrorMessage = "Ce Champs est obligatoire !!")]
      
        public string AdresseMail { get; set; }
        
        public DateTime DateInscription { get; set; }
        public int NumTel { get; set; }
        
        public string NomDeRue { get; set; }
        public int AutreTel { get; set; }
       
        public int NumeroRue { get; set; }
        public double CodePostal { get; set; }

        public string Ville { get; set; }
        //[DataType(DataType.Password)]
        public string Password { get; set; }
      //  [DataType(DataType.Password)]
        //[DisplayName("Confirm Password")]
       // [Compare("Password")]
        public string ConfirmerMotDePasse { get; set; }
       
        public DateTime DateDeDesinscription  { get; set; }
        public int identifiantSexeUser { get; set; }
        [ForeignKey("SexeID")]
        public ReferenctielSexe UtilisateurSexe { get; set; }
        public int identifiantMotifDesinscription { get; set; }
        [ForeignKey("MotifDesinscriptionID")]
        public MotifDesinscription UtilisateurMotifDesinscription { get; set; }
        public int IdentifiantReferentielVille { get; set; }
        [ForeignKey("VilleID")]
        public ReferentielVille UtilisateurReferentielVille { get; set; }

        public bool IsAdmin { get; set; }
        public bool IsEmailVerified { get; set; }
        
        public System.Guid ActivationCode { get; set; }

        public virtual ICollection<Demande> UtilisateurDemande { get; set; }
        public virtual ICollection<Reponse> UtilisateurReponse { get; set; }
        public virtual ICollection<Satisfaction>UtilisateurSatisfaction { get; set; }
        public virtual ICollection<Concertation> UtilisateurConcertation { get; set; }
        public virtual ICollection<Indisponibilite> UtilisateurIndisponibilite { get; set; }
        public virtual ICollection<PreferenceDomaine> UtilisateurPreferenceDomaine { get; set; }
        public virtual ICollection<PreferenceJourHoraire> UtilisateurPreferenceJourHoraire { get; set; }
        public virtual ICollection<PreferenceRayonAction> UtilisateurPreferenceRayonAction { get; set; }





           
    }
}
