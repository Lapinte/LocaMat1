using System;
using System.Collections.Generic;
using System.Linq;
using LocaMat.Metier;
using LocaMat.UI.Framework;

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

            var liste = Application.GetBaseDonnees().Agences.ToList();
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

            using (var bd = Application.GetBaseDonnees())
            {
                bd.Agences.Add(agence);
                bd.SaveChanges();
            }
        }

        private void SupprimerAgence()
        {
            ConsoleHelper.AfficherEntete("Supprimer une agence");

            var liste = Application.GetBaseDonnees().Agences.ToList();
            ConsoleHelper.AfficherListe(liste);

            var id = ConsoleSaisie.SaisirEntierObligatoire("Id à supprimer : ");
            using (var bd = Application.GetBaseDonnees())
            {
                var agence = bd.Agences.Single(x => x.Id == id);
                bd.Agences.Remove(agence);
                bd.SaveChanges();
            }
        }
    }
}
