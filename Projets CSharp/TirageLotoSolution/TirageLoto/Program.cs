using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TirageLoto
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] t = new int[7];
            Random aleatoire = new Random();
            int n, i=0;
            bool ajout = true;
            while(i<7)
            {
                n = aleatoire.Next(1, 49);
                for (int j = 0; j < i; j++)
                {
                    if (t[j] == n)
                    {
                        ajout = false;
                        //Console.WriteLine("Egalite");
                    }
                }
                if (ajout)
                {
                    t[i] = n;
                    i++;
                }
                else
                    ajout = true;

            }
            AffichageTableau(t);
            Console.ReadLine();
        }

        static void AffichageTableau(int[] t)
        {
            foreach (int elmt in t)
                Console.Write(elmt + " ");
        }
    }
}
