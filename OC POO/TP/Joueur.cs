using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP
{
    class Joueur
    {
        private De de;
        public int Vie { get; private set; }
        public bool EstVivant {
            get
            {
                return Vie > 0;
            }
        }
        
        private int monstrefaciletue = 0;
        private int monstredificiletue = 0;

        public Joueur()
        {
            Vie = 150;
            de = new De();
        }

        public int LanceLeDe()
        {
            return de.LanceLeDe();
        }

        public void Attaque(MonstreFacile monstre)
        {
            int lanceJoueur = LanceLeDe();
            int lanceMonstre = monstre.LanceLeDe();
            if (lanceJoueur >= lanceMonstre)
                monstre.SubitDegats();
        }

        public void SubitDegats(int degat)
        {
            if (de.LanceLeDe() > 2)
                Vie -= degat;
        }
    }
}
