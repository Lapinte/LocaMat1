using System;
using System.Linq;
using LocaMat.Metier;
using LocaMat.UI.Framework;

namespace LocaMat.UI
{
    public class ModuleGestionClients
    {
        private Menu menu;

        private void InitialiserMenu()
        {
            this.menu = new Menu("Gestion des clients");
            this.menu.AjouterElement(new ElementMenu("1", "Afficher les clients")
            {
                FonctionAExecuter = this.AfficherClients
            });
            this.menu.AjouterElement(new ElementMenu("2", "Ajouter un client")
            {
                FonctionAExecuter = this.AjouterClient
            });
            this.menu.AjouterElement(new ElementMenu("3", "Supprimer un client")
            {
                FonctionAExecuter = this.SupprimerClient
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

        private void AfficherClients()
        {
            ConsoleHelper.AfficherEntete("Clients");

            var liste = Application.GetBaseDonnees().Clients.ToList();
            ConsoleHelper.AfficherListe(liste);
        }

        private void AjouterClient()
        {
            ConsoleHelper.AfficherEntete("Nouveau client");

            var client = new Client
            {
                Nom = ConsoleSaisie.SaisirChaine("Nom : ", false),
                Prenom = ConsoleSaisie.SaisirChaine("Prénom : ", false),
                Adresse = ConsoleSaisie.SaisirChaine("Adresse : ", false)
            };

            using (var bd = Application.GetBaseDonnees())
            {
                bd.Clients.Add(client);
                bd.SaveChanges();
            }
        }

        private void SupprimerClient()
        {
            ConsoleHelper.AfficherEntete("Supprimer un client");

            var liste = Application.GetBaseDonnees().Clients.ToList();
            ConsoleHelper.AfficherListe(liste);

            var id = ConsoleSaisie.SaisirEntierObligatoire("Id à supprimer : ");
            using (var bd = Application.GetBaseDonnees())
            {
                var client = bd.Clients.Single(x => x.Id == id);
                bd.Clients.Remove(client);
                bd.SaveChanges();
            }
        }
    }
}
