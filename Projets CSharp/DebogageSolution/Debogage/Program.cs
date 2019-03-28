using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debogage
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write("Hello ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("les couleurs");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(" dans la console\n");

            Console.ResetColor();//Reinitialisation
            Console.ReadKey();
            Console.Clear(); //Efface la console

            foreach (string parametre in Environment.GetCommandLineArgs()) //args
                Console.WriteLine(parametre);
            Console.WriteLine(CalculSommeIntersection());
        }

        static int CalculSommeIntersection()
        {
            List<int> multiplesDe3 = new List<int>();
            List<int> multiplesDe5 = new List<int>();

            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0)
                    multiplesDe3.Add(i);
                if (i % 5 == 0)
                    multiplesDe5.Add(i);
            }

            int somme = 0;
            foreach (int m3 in multiplesDe3)
            {
                foreach (int m5 in multiplesDe5)
                {
                    if (m3 == m5)
                        somme += m3;
                }
            }
            return somme;
        }
    }
}
