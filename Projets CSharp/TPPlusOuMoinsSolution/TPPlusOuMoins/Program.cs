using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPPlusOuMoins
{
    class Program
    {
        static void Main(string[] args)
        {
            int valeurAtrouver = new Random().Next(1, 21); //generation d'un nombre aleatoire entre [1,20]
            //Console.WriteLine(valeurAtrouver);
            bool trouve = false;
            int nbCoups = 0;
            do
            {
                nbCoups++;
                Console.WriteLine("Saisir un nombre entre 1 et 20 : ");
                string saisie = Console.ReadLine();
                int valeur;
                if (int.TryParse(saisie, out valeur))
                {
                    if (valeur == valeurAtrouver)
                    {
                        //Console.WriteLine("Bravo vous avez trouve le nombre en " + nbCoups + " coups");
                        Console.WriteLine("Bravo !! tu as gagné.");
                        trouve = true;
                    }
                    else if (valeur > valeurAtrouver)
                        Console.WriteLine("C'est moins");
                    else
                        Console.WriteLine("C'est plus");
                }
                else
                    Console.WriteLine("Vous n'avez pas saisi de nombre");
            } while (!trouve);
            Console.ReadLine();
        }
    }
}
