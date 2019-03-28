using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class A
{
    int entier = 42;

    public int Entier
    {
        get
        {
            return entier;
        }
        set
        {
            entier = value >= 0 ? value : 0;
        }
    }

    void MaMethodePrivee()
    {
        Console.WriteLine("Je suis dans ma methode privée!");

    }

    public void MaMethode()
    {
        MaMethodePrivee();
        Console.WriteLine("Je suis dans ma methode !");
    }
}

namespace POO
{
    class Program
    {
        static void Modification(A a)
        {
            a.Entier = 10;
        }

        static void Main(string[] args)
        {
            var a = new A();

            Modification(a);

            Console.WriteLine(a.Entier);

            Console.ReadLine();
        }
    }
}
