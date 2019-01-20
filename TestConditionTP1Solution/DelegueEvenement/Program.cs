using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegueEvenement
{
    class Program
    {
        static void Main(string[] args)
        {
            Statisticien stat = new Statisticien();
            stat.Simulation();
            stat.AfficherStatistiques();
        }
    }
}
