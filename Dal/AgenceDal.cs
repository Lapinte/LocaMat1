using LocaMat.Metier;
using LocaMat.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocaMat.Dal
{
    public static class AgenceDal
    {
        public static void Supprimer(int id)
        {
            using (var bd = Application.GetBaseDonnees())
            {
                var agence = bd.Agences.Single(x => x.Id == id);
                bd.Agences.Remove(agence);
                bd.SaveChanges();
            }
        }

        public static void Ajouter(this Agence agence)
        {
            using (var bd = Application.GetBaseDonnees())
            {
                bd.Agences.Add(agence);
                bd.SaveChanges();
            }
        }

        public static List<Agence> RecupererListeAgences()
        {
            using (var bd = Application.GetBaseDonnees())
            {
                var liste = Application.GetBaseDonnees().Agences.ToList();
                return liste;
            }

        }

        public static List<Agence> Rechercher(string ville, string adresse)
        {
            using (var bd = Application.GetBaseDonnees())
            {
                var resultat = bd.Agences;

                if (!string.IsNullOrWhiteSpace(ville) && string.IsNullOrWhiteSpace(adresse))
                    return resultat.Where(x => x.Ville.Contains(ville)).ToList();

                if (string.IsNullOrWhiteSpace(ville) && !string.IsNullOrWhiteSpace(adresse))
                    return resultat.Where(x => x.Adresse.Contains(adresse)).ToList();

                if (!string.IsNullOrWhiteSpace(ville) && !string.IsNullOrWhiteSpace(adresse))
                    return resultat.Where(x => x.Ville.Contains(ville) && x.Adresse.Contains(adresse)).ToList();

                return resultat.ToList();

            }
        }
    }
}
