using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generecite
{
    public class ClasseGenerique
    {
        public void Foo(int a)
        {
            Console.WriteLine("Un entier a été passé en paramètre et sa valeur est : " + a);
        }
        public void Foo<T>(T obj)
        {
            Console.WriteLine("Un " + obj.GetType() + " a été passé en parametre");
        }
        public T Bar<T>(T obj)
        {
            return obj;
        }
    }
}
