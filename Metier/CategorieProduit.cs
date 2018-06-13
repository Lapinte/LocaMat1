using LocaMat.UI.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocaMat.Metier
{
    [Table("CategoriesProduits")]
    public class CategorieProduit
    {
        [InformationAffichage(Entete = "Id", NombreCaracteres = 2)]
        public int Id { get; set; }

        [InformationAffichage(Entete = "Libelle", NombreCaracteres = 20)]
        [Column("Nom")]
        public string Libelle { get; set; }

        public override string ToString()
        {
            return this.Libelle;
        }
    }
}
