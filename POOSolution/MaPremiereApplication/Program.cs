using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaPremiereApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Voiture voitureBane = new Voiture();
            voitureBane.Klaxonner();
            //itureBane.VitessePrivee = 50;
            Console.WriteLine(voitureBane.VitessePrivee);
            Console.ReadLine();
        }
    }
}
