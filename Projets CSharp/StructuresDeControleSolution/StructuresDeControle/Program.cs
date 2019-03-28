using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuresDeControle
{
    class Program
    {
        

        static void Main(string[] args)
        {
            var mavariable = 51;

            if (mavariable == 42)
                Console.WriteLine("Test reussi");
            else if(mavariable==51)
                Console.WriteLine("2eme test Réussi");
            else
                Console.WriteLine("Echoué");

            Console.WriteLine(mavariable);

            Console.ReadLine();
        }
        
    }
}
