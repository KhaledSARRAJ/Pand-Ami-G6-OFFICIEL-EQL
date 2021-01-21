﻿using System;
using GestionProduits.Service;
using MonCatalogueProduit.Service;

namespace TestBaseDeDonner
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new CatalogueDbContext())//using son but est de creer l'objet dbContext mais quant on arrive à la fin de crochet il le ferme 
            {//var : variable dynamique
             //Creation de la base de données           
                 
                  db.Database.EnsureDeleted(); // supprime moi tout 
                  db.Database.EnsureCreated(); // creer moi tout au exécution (attention juste pour la premiere exécution) aprés il faut les mettres en commentaire
           

                /*Ajouter quelques categorie */
                db.CategoriesDomaines.Add(new CategorieDomaine { libelleCategorie ="Medical"});
                db.CategoriesDomaines.Add(new CategorieDomaine { libelleCategorie = "Agricole" });
                db.CategoriesDomaines.Add(new CategorieDomaine { libelleCategorie = "Construction" });
                //Ajouter quelques Materiels 
                db.ListMateriel.Add(new Materiel { LibelleMateriel = "Voiture" });
                db.ListMateriel.Add(new Materiel { LibelleMateriel = "Marteau" });
                db.ListMateriel.Add(new Materiel { LibelleMateriel = "Ponsseuce" });
                //Ajouter quelques Domaine d'activiter
                db.ListeDomaineActiviter.Add(
                    new DomaineActivite { LibelleDomaine = "Bricolage", CategorieDomaineID=1, MaterielID = 3}
                    );
                db.ListeDomaineActiviter.Add(
                    new DomaineActivite { LibelleDomaine = "Courses", CategorieDomaineID = 1, MaterielID = 3 }
                    );
                db.ListeDomaineActiviter.Add(
                    new DomaineActivite { LibelleDomaine = "Menages", CategorieDomaineID = 2, MaterielID = 2 }
                    );
                db.ListeDomaineActiviter.Add(
                    new DomaineActivite { LibelleDomaine = "Achat", CategorieDomaineID = 3, MaterielID = 1 }
                    );
                //Ajouter quelques Demande  
                //En deuxiéme lancement garder que les produits pour ajouter
                db.ListeDemandes.Add(new Demande { DateEnregistrementDemande= DateTime.Now, DatedeRealisation = DateTime.Now,
                   heureSouhaitee = DateTime.Now,
                   Description = "J'ai besoin d'une voiture rouge type Hondai budget 3000 milles euros",
                   DateClotureDemande = DateTime.Now,
                   DateModification = DateTime.Now,
                   DateAnnulationDemande = DateTime.Now,
                   adressesecondaire ="Caen",
                   IdentifiantDomaine = 1,
                   IdentifiantMateriel = 3,
                   IdentifiantMAnnulation = 1,
                   IdentifiantUtilisateur=1
                });
                db.ListeDemandes.Add(new Demande
                {
                    DateEnregistrementDemande = DateTime.Now,
                    DatedeRealisation = DateTime.Now,
                    heureSouhaitee = DateTime.Now,
                    Description = "J'ai besoin d'une voiture rouge type Hondai budget 3000 milles euros",
                    DateClotureDemande = DateTime.Now,
                    DateModification = DateTime.Now,
                    DateAnnulationDemande = DateTime.Now,
                    adressesecondaire = "Caen",
                    IdentifiantDomaine = 2,
                    IdentifiantMateriel = 2,
                    IdentifiantMAnnulation = 1,
                    IdentifiantUtilisateur = 1
                });
                db.ListeDemandes.Add(new Demande
                {
                    DateEnregistrementDemande = DateTime.Now,
                    DatedeRealisation = DateTime.Now,
                    heureSouhaitee = DateTime.Now,
                    Description = "J'ai besoin d'une voiture rouge type Hondai budget 3000 milles euros",
                    DateClotureDemande = DateTime.Now,
                    DateModification = DateTime.Now,
                    DateAnnulationDemande = DateTime.Now,
                    adressesecondaire = "Caen",
                    IdentifiantDomaine = 3,
                    IdentifiantMateriel = 1,
                    IdentifiantMAnnulation = 1,
                    IdentifiantUtilisateur = 1
                });

                //Ajouter quelques Reponses
                db.ListReponse.Add(new Reponse {  DateReponse = DateTime.Now,
                    DateRenonciation = DateTime.Now,
                    DatePriseCompte = DateTime.Now,
                    DemandeID=1,
                    IdentifiantUtilisateur=1
                });
                //Ajouter quelques Satisfactions
                db.ListSatisfaction.Add(new Satisfaction{
                    DateEvaluation = DateTime.Now,
                    NoteConformite = 1,
                    NoteRelation = 5,
                    NoteContact = 7,
                    Message = "Je ne suis pas satisfaite",
                    DemandeID=1,
                    IdentifiantUtilisateur=1
                });
                db.ListConcertation.Add(new Concertation { 
                    DateConcertation = DateTime.Now,
                    HoraireProposer = "17:50",
                    DateProposer = DateTime.Now,
                    ComplementAdresse ="je serai disponible l'aprés midi",
                    DateAcceptation= DateTime.Now,
                    DateRejetDefinitif = DateTime.Now  ,
                    identifiantDemandeID=1,
                    IdentifiantUtilisateur=1
                });
                //Ajouter un motif d'annulation
                db.ListMotifAnnulation.Add(new MotifAnnulation {
                   LibelleMotifAnnul = "Absence"
                });
                //Creer un utilisateur
                db.ListUtilisateurs.Add(new Utilisateur
                {
                    Nom = "Khaled",
                    Prenom = "SARRAJ",
                    DateDeNaissance = DateTime.Now,
                    NomUtilisateur = "KOUKI",
                    AdresseMail = "Khaledinat@gmail.com",
                    DateInscription = DateTime.Now,
                    NumTel = 0605810246,
                    NomDeRue  ="allee du pere jamet",
                    NumeroRue = 4,
                    MotDePasse = "ORANEMIKhALED",
                    DateDeDesinscription = DateTime.Now,
                    identifiantSexeUser=1,
                    identifiantMotifDesinscription=1,
                    IdentifiantReferentielVille=1
                });
                //Creer un domaine de préférence
                db.ListePreferenceDomaine.Add(new PreferenceDomaine
                {
                    dateDebutPref = DateTime.Now,
                    dateFinPref = DateTime.Now,
                    IdentifiantUtilisateur =1,
                    IdentifiantDomaineActiviter=1

                }); ;
                //Creer une preference jour/horraire
                db.ListePreferenceJourHoraires.Add(
                new PreferenceJourHoraire
                {
                    heureDebut = "17H",
                    heurefin = "20H",
                    DateDebutValidite = DateTime.Now,
                    DateDeFinValidite = DateTime.Now,
                    IdentifiantUtilisateur = 1,
                    IdentifiantJourSemaine=1
                }) ;
                //Creer une ref jour semaine
                db.ListRrefJourSemaine.Add(new RefJourSemaine{
                   LibelleJourSemaine = "lundi"
                
                });
                //Ajouter une liste de preference de rayon d'action
                db.ListPreferenceRayonAction.Add(new PreferenceRayonAction { 
                   ValeurRayon = 50,
                   DateDebutChRay = DateTime.Now,
                   DateFinChRay = DateTime.Now,
                    IdentifiantUtilisateur=1
                });
                //Creer une liste de reference sexe (static)
                db.ListSexe.Add(new ReferenctielSexe{LibelleSexe = " M "});
                db.ListSexe.Add(new ReferenctielSexe { LibelleSexe = " F " });
                db.ListSexe.Add(new ReferenctielSexe { LibelleSexe = " N "});
                //Ajouter un motif de désinscription
                db.ListMotifDesinscription.Add(new MotifDesinscription { 
                   LibelleMotifDesinscr = "je veux m'isoler et plus être en contact avec les êtres humains SALUTTT!!"               
                });
                //Ajouter une indisponibilitée
                db.ListIndisponiblite.Add(new Indisponibilite {                 
                   dateDebutIndispo = DateTime.Now,
                   dateFinIndispo = DateTime.Now,
                   CommentaireIndispo = "Je serai hospitalisé bientot :( désolé",
                   IdentifiantUtilisateur=1
                });
                //Ajouter quelques régions
                db.ListRegion.Add(new ReferentielRegion {LibelleRegion= "Calvados"});
                db.ListRegion.Add(new ReferentielRegion {LibelleRegion = "Ile de France"});
                db.ListRegion.Add(new ReferentielRegion{LibelleRegion = "Bretagne"});

                db.ListVille.Add(new ReferentielVille { LibelleVille = "Caen", CodePostal = 14000, IdentifiantRegion =1});
                db.ListVille.Add(new ReferentielVille{ LibelleVille = "Rennes", CodePostal = 35000, IdentifiantRegion =1});

                
                db.SaveChanges();//Sauvgarder ce qu'on a creer quant même !!
            }
        }
    }
}