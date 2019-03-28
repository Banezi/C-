using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP
{
    class MonstreDifficile : MonstreFacile
    {
        private const int degatSort = 5;
        public override void Attaque(Joueur joueur)
        {
            base.Attaque(joueur);
            joueur.SubitDegats(SortMagique());
        }

        private int SortMagique()
        {
            int lancee = de.LanceLeDe();
            if (lancee == 6)
                return 0;
            return degatSort * lancee;
        }
    }
}
