using System;
using System.Collections.Generic;
using System.Linq;
using LocaMat.Metier;
using LocaMat.UI.Framework;
using LocaMat.Dal;

namespace LocaMat.UI
{
    public class ModuleGestionAgences
    {
        private Menu menu;

        private void InitialiserMenu()
        {
            this.menu = new Menu("Gestion des agences");
            this.menu.AjouterElement(new ElementMenu("1", "Afficher les agences")
            {
                FonctionAExecuter = this.AfficherAgences
            });
            this.menu.AjouterElement(new ElementMenu("2", "Ajouter une agence")
            {
                FonctionAExecuter = this.AjouterAgence
            });
            this.menu.AjouterElement(new ElementMenu("3", "Supprimer une agence")
            {
                FonctionAExecuter = this.SupprimerAgence
            });
            this.menu.AjouterElement(new ElementMenu("4", "Rechercher une agence")
            {
                FonctionAExecuter = this.RechercherAgence
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

        private void AfficherAgences()
        {
            ConsoleHelper.AfficherEntete("Agences");

            var liste = AgenceDal.RecupererListeAgences();
            ConsoleHelper.AfficherListe(liste);
        }

        private void AjouterAgence()
        {
            ConsoleHelper.AfficherEntete("Nouvelle agence");

            var agence = new Agence
            {
                Ville = ConsoleSaisie.SaisirChaine("Ville : ", false),
                Adresse = ConsoleSaisie.SaisirChaine("Adresse : ", false)
            };
            //AgenceDal.Ajouter(agence);
            agence.Ajouter();
        }

        private void SupprimerAgence()
        {
            ConsoleHelper.AfficherEntete("Supprimer une agence");

            var liste = Application.GetBaseDonnees().Agences.ToList();
            ConsoleHelper.AfficherListe(liste);

            var id = ConsoleSaisie.SaisirEntierObligatoire("Id à supprimer : ");
            AgenceDal.Supprimer(id);
        }
        private void RechercherAgence()
        {
            ConsoleHelper.AfficherEntete("Rechercher un Produit");

            var ville = ConsoleSaisie.SaisirChaine("Saisir un nom de ville (ou en partie) : ", true);
            var adresse = ConsoleSaisie.SaisirChaine("Saisir une adresse (ou en partie) : ", true);

            var liste = AgenceDal.Rechercher(ville, adresse);
            ConsoleHelper.AfficherListe(liste);
        }
    }
}
