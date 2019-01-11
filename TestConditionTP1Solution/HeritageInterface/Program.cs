using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeritageInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            CompteCourant cc = new CompteCourant();
            CompteEpargne ce = new CompteEpargne();
            cc.PayIn(500);
            ce.PayIn(500);
            Console.WriteLine(cc.Balance);
            Console.WriteLine(ce.Balance);
            cc.Withdraw(600);
            ce.Withdraw(600);
            Console.WriteLine(cc.Balance);
            Console.WriteLine(ce.Balance);
        }
    }
}
