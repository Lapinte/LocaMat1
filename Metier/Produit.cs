using System.ComponentModel.DataAnnotations.Schema;

namespace LocaMat.Metier
{
    public class Produit
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public string Description { get; set; }

        public decimal PrixJourHT { get; set; }

        [ForeignKey("IdCategorie")]
        public virtual CategorieProduit Categorie { get; set; }
        public int IdCategorie { get; set; }

        public override string ToString()
        {
            return $"{this.Nom} ({this.Id})";
        }
    }
}
