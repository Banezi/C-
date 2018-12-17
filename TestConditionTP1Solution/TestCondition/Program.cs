using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Principal;

namespace TestCondition
{
    class Program
    {
        static void Main(string[] args)
        {
            if(DateTime.Now.DayOfWeek == DayOfWeek.Monday || DateTime.Now.DayOfWeek == DayOfWeek.Tuesday || DateTime.Now.DayOfWeek == DayOfWeek.Wednesday || DateTime.Now.DayOfWeek == DayOfWeek.Thursday || DateTime.Now.DayOfWeek == DayOfWeek.Friday)
            {
                if (DateTime.Now.Hour >= 9 && DateTime.Now.Hour <=18)
                    Console.WriteLine("Bonjour {0} !", WindowsIdentity.GetCurrent().Name);
                else
                    Console.WriteLine("Bonsoir {0} !", WindowsIdentity.GetCurrent().Name); 
            }
            else if(DateTime.Now.DayOfWeek == DayOfWeek.Friday && DateTime.Now.Hour >=18 )
            {
                Console.WriteLine("Bon week-end {0} !", WindowsIdentity.GetCurrent().Name);
            }
        }
    }
}
