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
    }
}
