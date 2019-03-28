using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP
{
    class MonstreFacile
    {
        private const int degat = 10;
        protected De de;
        public bool EstVivant{ get; private set; }
        public MonstreFacile()
        {
            de = new De();
            EstVivant = true;
        }
        public virtual void Attaque(Joueur joueur)
        {
            int lanceMonstre = LanceLeDe();
            int lanceJoueur = joueur.LanceLeDe();
            if(lanceMonstre>lanceJoueur)
                joueur.SubitDegats(degat);
        }
        public void SubitDegats()
        {
            EstVivant = false;
        }
        public int LanceLeDe()
        {
            return de.LanceLeDe();
        }
    }
}
