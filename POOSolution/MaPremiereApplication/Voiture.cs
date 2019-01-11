using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaPremiereApplication
{
    class Voiture
    {
        private int _vitessePrivee;

        public int VitessePrivee { get => _vitessePrivee; set => _vitessePrivee = value; }

        public void Klaxonner()
        {
            Console.WriteLine("Pouet");
        }
        public bool VitesseAutorisee(int vitesse)
        {
            if (vitesse > 90)
                return false;
            else
                return true;
        }
    }
}
