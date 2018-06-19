using LocaMat.Metier;
using LocaMat.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocaMat.Dal
{
    public static class ProduitDal
    {
        public static void Ajouter(this Produit produit)
        {
            using (var bd = Application.GetBaseDonnees())
            {
                bd.Produits.Add(produit);
                bd.SaveChanges();
            }
        }
    }
}
