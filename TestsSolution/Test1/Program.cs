using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Principal;
namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bonjour {0} !", WindowsIdentity.GetCurrent().Name);
        }
    }
}
