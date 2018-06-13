using LocaMat.Metier;
using LocaMat.UI.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocaMat.UI
{
    class ModuleGestionLocations
    {
        private Menu menu;

        private void InitialiserMenu()
        {
            this.menu = new Menu("Gestion des Location");
            this.menu.AjouterElement(new ElementMenu("1", "Afficher les Locations")
            {
                FonctionAExecuter = this.AfficherLocations
            });
            this.menu.AjouterElement(new ElementMenu("2", "Ajouter une Location")
            {
                FonctionAExecuter = this.AjouterLocation
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

        private void AfficherLocations()
        {
            ConsoleHelper.AfficherEntete("Locations");

            var liste = Application.GetBaseDonnees().Locations.ToList();
            ConsoleHelper.AfficherListe(liste);
        }

        private void AjouterLocation()
        {
            ConsoleHelper.AfficherEntete("Nouvelle location");

            using (var bd = Application.GetBaseDonnees())
            {
                var liste = bd.Agences.ToList();
                ConsoleHelper.AfficherListe(liste);

                var idAgence = ConsoleSaisie.SaisirEntierObligatoire("Choisissez votre agence : ");

                var listeOffres = bd.OffresProduits.Where(x => x.IdAgence == idAgence);
                ConsoleHelper.AfficherListe(listeOffres);

                var idOffre = ConsoleSaisie.SaisirEntierObligatoire("Choisissez l'id de l'offre : ");

                var offre = listeOffres.Single(x => x.Id == idOffre);
                var offreAffichage = listeOffres.Where(x => x.Id == idOffre).ToList();
                var idProduit = offre.IdProduit;
                ConsoleHelper.AfficherListe(offreAffichage);

                var qte = ConsoleSaisie.SaisirEntierObligatoire("Choisissez la quantité : ");



                int qtePossible = offre.Quantite;

                if (qte > qtePossible)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Quantité non disponible");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                var dateDebut = ConsoleSaisie.SaisirDateObligatoire("Choisissez la date de début de location : ");
                var dateFin = ConsoleSaisie.SaisirDateObligatoire("Choisissez la date de fin de location : ");

                //var locationsDispo = bd.Locations.Where(x => x.IdProduit == idProduit && x.DateDebut);
            }

        }
    }
}
