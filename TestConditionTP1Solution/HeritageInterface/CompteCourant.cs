using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeritageInterface
{
    public class CompteCourant : IBankAccount
    {
        public decimal Balance { get; set; }

        public void PayIn(decimal amount)
        {
            this.Balance += amount; 
        }

        public bool Withdraw(decimal amount)
        {
            this.Balance -= amount;
            return true;
        }
    }
}
