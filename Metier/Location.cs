using System;
using System.ComponentModel.DataAnnotations.Schema;
using LocaMat.UI.Framework;

namespace LocaMat.Metier
{
    public class Location
    {
        [InformationAffichage(Entete = "Id", NombreCaracteres = 3)]
        public int Id { get; set; }

        [InformationAffichage(Entete = "Produit", NombreCaracteres = 30)]
        [ForeignKey("IdProduit")]
        public virtual Produit Produit { get; set; }
        public int IdProduit { get; set; }

        [InformationAffichage(Entete = "Client", NombreCaracteres = 40)]
        [ForeignKey("IdClient")]
        public virtual Client Client { get; set; }
        public int IdClient { get; set; }

        [InformationAffichage(Entete = "Agence", NombreCaracteres = 15)]
        [ForeignKey("IdAgence")]
        public virtual Agence Agence { get; set; }
        public int IdAgence { get; set; }

        [InformationAffichage(Entete = "Du", NombreCaracteres = 10)]
        public DateTime DateDebut { get; set; }

        [InformationAffichage(Entete = "Au", NombreCaracteres = 10)]
        public DateTime DateFin { get; set; }

        [InformationAffichage(Entete = "Qté", NombreCaracteres = 3)]
        public int Quantite { get; set; }

        [InformationAffichage(Entete = "Total", NombreCaracteres = 7)]
        public decimal TotalFacture { get; set; }
    }
}
