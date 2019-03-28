using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPWeekEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Environment.UserName);
            //Console.WriteLine(DateTime.Now);
            //Console.WriteLine(DateTime.Now.DayOfWeek);
            //Console.WriteLine(DateTime.Now.Hour);
            if(DateTime.Now.DayOfWeek==DayOfWeek.Monday || DateTime.Now.DayOfWeek==DayOfWeek.Tuesday || DateTime.Now.DayOfWeek==DayOfWeek.Wednesday
                || DateTime.Now.DayOfWeek==DayOfWeek.Thursday || DateTime.Now.DayOfWeek==DayOfWeek.Saturday)
            {
                if (DateTime.Now.Hour >= 9 && DateTime.Now.Hour <= 18)
                    Console.WriteLine("Bonjour " + Environment.UserName);
                else
                    Console.WriteLine("Bonsoir " + Environment.UserName);
            }
            else
            {
                Console.WriteLine("Bon week-end " + Environment.UserName);
            }
            
            Console.ReadLine();
        }
    }
}
