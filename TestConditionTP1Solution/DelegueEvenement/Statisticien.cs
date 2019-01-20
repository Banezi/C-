using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegueEvenement
{
    class Statisticien
    {
        public int NbSoleil { get; set; }
        public int NbChangementTemps { get; set; }
        public Temps DernierTemps { get; set; }
        int nbSimulation = 0; 

        public Statisticien()
        {
            NbSoleil = 0;
            NbChangementTemps = -1;
            DernierTemps = Temps.Inconnu;
        }

        public void Simulation()
        {
            Console.WriteLine("Saisir le nombre d'itération : ");
            string saisi = Console.ReadLine();
            if(!int.TryParse(saisi, out nbSimulation))
                Console.WriteLine("Vous n'avez pas saisi le bon nombre d'itération!");

            SimulateurMeteo simulateurMeteo = new SimulateurMeteo();
            simulateurMeteo.ChangementTemperature += SimulateurMeteo_ChangementTemperature;
            simulateurMeteo.demarrer(nbSimulation);
        }

        private void SimulateurMeteo_ChangementTemperature(Temps temps)
        {
            if (!DernierTemps.Equals(temps))
                NbChangementTemps++;
            if (temps == Temps.Soleil)
                NbSoleil++;
            DernierTemps = temps;
            Console.WriteLine("Le nouveau temps est : " + temps);
        }

        public void AfficherStatistiques()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("========================================================");
            Console.WriteLine("                      Statistique                       ");
            Console.WriteLine("========================================================");
            Console.WriteLine("\n");
            Console.WriteLine("Le nombre de fois où il a fait Soleil : " + NbSoleil + " fois");
            Console.WriteLine("Le nombre de fois où le temps à changé : " + NbChangementTemps + " fois");
            int pourcentage = (int) (NbSoleil*100/nbSimulation);
            Console.WriteLine("Le pourcentage de fois où il a fait Soleil : " + pourcentage + "%");
        }
    }
}
