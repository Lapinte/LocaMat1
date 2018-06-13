using System;
using System.Linq.Expressions;
using System.Reflection;

namespace LocaMat.UI.Framework
{
    /// <summary>
    /// Cette classe permet de gérer comment afficher une propriété.
    /// </summary>
    public class InformationAffichage
    {
        private InformationAffichage(PropertyInfo propriete,string entete, int nombreCaracteres)
        {
            Propriete = propriete;
            Entete = entete;
            NombreCaracteres = nombreCaracteres;
        }

        private PropertyInfo Propriete { get; }

        public string Entete { get; }

        public int NombreCaracteres { get; }

        public string GetEntete()
        {
            return Entete.ToUpper().PadRight(NombreCaracteres);
        }

        public string GetValeur(object element)
        {
            string renduValeur = string.Empty;
            var valeur = Propriete.GetValue(element);
            if (valeur != null)
            {
                if (valeur is DateTime date)
                {
                    renduValeur = date.ToShortDateString();
                }
                else
                {
                    renduValeur = valeur.ToString().Replace(Environment.NewLine, " ").Tronquer(NombreCaracteres);
                }
            }

            return renduValeur.PadRight(NombreCaracteres);
        }

        public static InformationAffichage Creer<T>(
            Expression<Func<T, object>> propriete, 
            string entete, 
            int nombreCaracteres)
        {
            var informationPropriete = OutilsReflection.GetInformationPropriete(propriete);
            return new InformationAffichage(informationPropriete, entete, nombreCaracteres);
        }
    }
}

