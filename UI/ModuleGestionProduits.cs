using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using LocaMat.Metier;
using LocaMat.UI.Framework;

namespace LocaMat.UI
{
    public class ModuleGestionProduits
    {
        private Menu menu;
        private static readonly List<InformationAffichage> strategieAffichageProduits
            = new List<InformationAffichage>();

        static ModuleGestionProduits()
        {
            // On définit ici les propriétés qu'on veut afficher
            //  et la manière de les afficher
            strategieAffichageProduits = new List<InformationAffichage>
            {
                InformationAffichage.Creer<Produit>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<Produit>(x=>x.Nom, "Nom", 20),
                InformationAffichage.Creer<Produit>(x=>x.Description, "Description", 50),
                InformationAffichage.Creer<Produit>(x=>x.PrixJourHT, "Prix jour (HT)", 15),
                InformationAffichage.Creer<Produit>(x=>x.Categorie, "Catégorie", 20),
            };
        }

        private void InitialiserMenu()
        {
            this.menu = new Menu("Gestion des produits");
            this.menu.AjouterElement(new ElementMenu("1", "Afficher les produits")
            {
                FonctionAExecuter = this.AfficherProduits
            });
            this.menu.AjouterElement(new ElementMenu("2", "Ajouter un produit")
            {
                FonctionAExecuter = this.AjouterProduit
            });
            this.menu.AjouterElement(new ElementMenu("3", "Supprimer un produit")
            {
                FonctionAExecuter = this.SupprimerProduit
            });
            this.menu.AjouterElement(new ElementMenu("4", "Rechercher un produit")
            {
                FonctionAExecuter = this.RechercherProduit
            });
            this.menu.AjouterElement(new ElementMenuQuitterMenu("R", "Revenir au menu principal..."));
        }

        public void Demarrer()
        {
            if (this.menu == null)
            {
                this.InitialiserMenu();
            }

            this.menu.Afficher();
        }

        private void AfficherProduits()
        {
            ConsoleHelper.AfficherEntete("Produits");

            var liste = Application.GetBaseDonnees().Produits.ToList();
            ConsoleHelper.AfficherListe(liste, strategieAffichageProduits);
        }

        private void AjouterProduit()
        {
            ConsoleHelper.AfficherEntete("Nouveau produit");

            var produit = new Produit
            {
                Nom = ConsoleSaisie.SaisirChaine("Nom : ", false),
                Description = ConsoleSaisie.SaisirChaine("Description : ", false),
                PrixJourHT = ConsoleSaisie.SaisirDecimalObligatoire("Prix du Jour HT : "),
                IdCategorie = ConsoleSaisie.SaisirEntierObligatoire("Id Catégorie : ")
            };

            using (var bd = Application.GetBaseDonnees())
            {
                bd.Produits.Add(produit);
                bd.SaveChanges();
            }
        }

        private void SupprimerProduit()
        {
            ConsoleHelper.AfficherEntete("Supprimer un produit");

            var liste = Application.GetBaseDonnees().Produits.ToList();
            ConsoleHelper.AfficherListe(liste, strategieAffichageProduits);

            var id = ConsoleSaisie.SaisirEntierObligatoire("Id à Supprimer : ");


            using (var bd = Application.GetBaseDonnees())
            {
                var produit = bd.Produits.Single(x => x.Id == id);
                bd.Produits.Remove(produit);
                bd.SaveChanges();
            }

        }

        private void RechercherProduit()
        {
            ConsoleHelper.AfficherEntete("Rechercher un Produit");

            var saisi = ConsoleSaisie.SaisirChaine("Texte contenu dans le produit : ", false);

            using (var bd = Application.GetBaseDonnees())
            {
                var liste = bd.Produits.Where(x => x.Nom.Contains(saisi)).ToList();
                ConsoleHelper.AfficherListe(liste, strategieAffichageProduits);
            }
        }
    }
}
