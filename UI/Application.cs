using System;
using System.Configuration;
using System.Data.SqlClient;
using LocaMat.Dal;
using LocaMat.UI.Framework;

namespace LocaMat.UI
{
    public class Application
    {
        private Menu menuPrincipal;
        private ModuleGestionAgences moduleGestionAgences;
        private ModuleGestionProduits moduleGestionProduits;
        private ModuleGestionClients moduleGestionClients;
        private ModuleGestionLocations moduleGestionLocations;

        private void InitialiserModules()
        {
            this.moduleGestionAgences = new ModuleGestionAgences();
            this.moduleGestionProduits = new ModuleGestionProduits();
            this.moduleGestionClients = new ModuleGestionClients();
            this.moduleGestionLocations = new ModuleGestionLocations();

        }

        private void InitialiserMenuPrincipal()
        {
            this.menuPrincipal = new Menu("Menu principal");
            this.menuPrincipal.AjouterElement(new ElementMenu("1", "Gestion des produits")
            {
                AfficherLigneRetourMenuApresExecution = false,
                FonctionAExecuter = this.moduleGestionProduits.Demarrer
            });
            this.menuPrincipal.AjouterElement(new ElementMenu("2", "Gestion des agences")
            {
                AfficherLigneRetourMenuApresExecution = false,
                FonctionAExecuter = this.moduleGestionAgences.Demarrer
            });
            this.menuPrincipal.AjouterElement(new ElementMenu("3", "Gestion des clients")
            {
                AfficherLigneRetourMenuApresExecution = false,
                FonctionAExecuter = this.moduleGestionClients.Demarrer
            });
            this.menuPrincipal.AjouterElement(new ElementMenu("4", "Gestion des locations")
            {
                AfficherLigneRetourMenuApresExecution = false,
                FonctionAExecuter = this.moduleGestionLocations.Demarrer
            });
            this.menuPrincipal.AjouterElement(new ElementMenuQuitterMenu("Q", "Quitter")
            {
                FonctionAExecuter = () => Environment.Exit(1)
            });
        }

        public void Demarrer()
        {
            this.InitialiserModules();
            this.InitialiserMenuPrincipal();

            this.menuPrincipal.Afficher();
        }

        public static SqlConnection GetConnexion()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Connexion"].ConnectionString;
            return new SqlConnection(connectionString);
        }

        public static BaseDonnees GetBaseDonnees()
        {
            return new BaseDonnees();
        }
    }
}
