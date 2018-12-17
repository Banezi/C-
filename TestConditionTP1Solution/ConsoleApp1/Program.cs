using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CalculSommeEntiers(1, 100));
            List<double> liste = new List<double> { 1.0, 5.5, 9.9, 2.8, 9.6 };
            Console.WriteLine(CalculMoyenne(liste));
            Console.WriteLine(NombreMultiple());
        }

        static int CalculSommeEntiers(int a, int b)
        {
            int somme = 0;
            for (int i = a; i <= b; i++)
                somme += i;
            return somme;
        }

        static double CalculMoyenne(List<double> liste)
        {
            double somme = 0, moyenne = 0;
            for(int i=0; i<liste.Count; i++)
                somme += liste[i];
            moyenne = somme / liste.Count;
            return moyenne;
        }

        static int NombreMultiple()
        {
            int n=0, i = 0, j = 0;
            List<int> multipe3 = new List<int>();
            for (i = 0; i < 100; i = i + 3)
                multipe3.Add(i);
            List<int> multipe5 = new List<int>();
            for ( i = 0; i < 100; i = i + 5)
                multipe5.Add(i);
            i = 0;
            j = 0;
            while (i < multipe3.Count && j < multipe5.Count)
            {
                if (multipe3[i] == multipe5[j])
                {
                    n+=multipe3[i];
                    i++;
                    j++;
                }
                else if (multipe3[i] < multipe5[j])
                {
                    i++;
                }
                else
                    j++;
            }
            return n;
        }
        
    }
}
