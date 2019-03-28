using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bases_du_CSharp
{
    class Program
    {
        //static int age = 20; // Pas de conflit avec int age=0; dans le Main
        static void Main(string[] args)
        {
            /*
            var entier = 0;
            int age=0;
            for(int i = 0; i <5; i++)
            {
                int age = 2; // En conflit avec int age=0;
                Console.WriteLine(age);
            }
            Console.WriteLine(age);
            Type entierType = entier.GetType();
            Console.WriteLine(entierType.ToString());
            */

            bool pair;
            for(int i=0; i<10; i++)
            {
                if (i % 2 == 0)
                    pair = true;
                else
                    pair = false;
                Console.WriteLine("{0} est {1}", i, pair? "pair" : "impair");
            }

          

            //Test sur une classe sans constructeur
            ClasseSansConstructeur c = new ClasseSansConstructeur();

        }
    }
}
