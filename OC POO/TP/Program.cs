using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TP
{
    class Program
    {
        private static Random random = new Random();

        static void Main(string[] args)
        {
            Jeu1();
        }

        private static void Jeu1()
        {
            Joueur j = new Joueur();
            int cptFacile = 0;
            int cptDificile = 0;
            while(j.EstVivant)
            {
                Console.WriteLine("...");
                Thread.Sleep(1000);
                MonstreFacile monstre = FabriqueDeMonstre();
                while(monstre.EstVivant && j.EstVivant)
                {
                    j.Attaque(monstre);
                    if (monstre.EstVivant)
                        monstre.Attaque(j);
                }
                
                if(j.EstVivant)
                {
                    if (monstre is MonstreDifficile)
                        cptDificile++;
                    else
                        cptFacile++;
                }
                else
                {
                    Console.WriteLine("Snif, vous êtes mort...");
                    //break;
                }
            }
            Console.WriteLine("Bravo !!! Vous avez tué {0} monstres faciles et {1} monstres difficiles. Vous avez {2} points.", cptFacile, cptDificile, cptFacile + cptDificile * 2);
        }

        private static MonstreFacile FabriqueDeMonstre()
        {
            if (random.Next(2) == 0)
                return new MonstreFacile();
            else
                return new MonstreDifficile();
        }
    }
}
