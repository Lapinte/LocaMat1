using LocaMat.Metier;
using System.Data.Entity;

namespace LocaMat.Dal
{
    public class BaseDonnees : DbContext
    {
        public BaseDonnees(string connectionString = "Connexion")
            : base(connectionString)
        {
        }

        public DbSet<Agence> Agences { get; set; }

        public DbSet<CategorieProduit> CategoriesProduits { get; set; }

        public DbSet<Produit> Produits { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<OffreProduit> OffresProduits { get; set; }

        public DbSet<Client> Clients { get; set; }
    }
}
