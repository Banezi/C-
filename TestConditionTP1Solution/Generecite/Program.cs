using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generecite
{
    class Program
    {
        static void Main(string[] args)
        {
            ClasseGenerique c = new ClasseGenerique();
            c.Foo(2);
            c.Foo("Salut");
            c.Foo(c);
        }
    }
}
