using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPCalculeEnBoucle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CalculSommeEntiers(1, 10));
            Console.WriteLine(CalculSommeEntiers(1, 100));
            List<double> liste = new List<double> { 1.0, 5.5, 9.9, 2.8, 9.6 };
            Console.WriteLine(MoyenneListe(liste));
            Console.WriteLine(CalculSommeEntiersCommuns());
            Console.ReadLine();
        }


        static int CalculSommeEntiers(int a, int b)
        {
            int somme = 0;
            for (int i = a; i <= b; i++)
                somme += i;
            return somme;
        }

        static double MoyenneListe(List<double> liste)
        {
            double moy, somme = 0;
            foreach (double d in liste)
                somme += d;
            moy = somme / liste.Count;
            return moy;
        }

        static int CalculSommeEntiersCommuns()
        {
            int somme = 0;
            List<int> listeMultiple3 = new List<int>();
            List<int> listeMultiple5 = new List<int>();
            for(int i=1; i<=100; i++)
            {
                if (i % 3 == 0)
                    listeMultiple3.Add(i);
                if (i % 5 == 0)
                    listeMultiple5.Add(i);
            }
            /* Affichage des listes
            foreach (int i in listeMultiple3)
                Console.Write(i + " ");
            Console.WriteLine("");
            foreach (int i in listeMultiple5)
                Console.Write(i + " ");
            */
            foreach (int i in listeMultiple3)
                foreach (int j in listeMultiple5)
                    if (i == j)
                        somme += i;
            return somme;
        }
    }
}
