using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelegueEvenement
{
    class SimulateurMeteo
    {
        public delegate void DelegateChangementTemperature(Temps temps);
        public event DelegateChangementTemperature ChangementTemperature;
        public int temp;
        public Temps _Temps { get; set; }

        public SimulateurMeteo()
        {
           
        }
        public void demarrer(int n)
        {
            for(int i=0; i< n; i++)
            {
                Thread.Sleep(100);
                temp = new Random().Next(0,100);
                if (temp < 5)
                {
                    Console.WriteLine("Le temps est au soleil : temperature = " + temp + "°C");
                    _Temps = Temps.Soleil;
                    notifier();
                }
                else if (temp >= 5 && temp < 50)
                {
                    Console.WriteLine("Nous avons des nuages : temperature = " + temp + "°C");
                    _Temps = Temps.Nuage;
                    notifier();
                }
                else if (temp >= 50 && temp < 90)
                {
                    Console.WriteLine("Nous avons de la pluie : temperature = " + temp + "°C");
                    _Temps = Temps.Pluie;
                    notifier();
                }
                else
                {
                    Console.WriteLine("Nous avons de l'orage : temperature = " + temp + "°C");
                    _Temps = Temps.Orage;
                    notifier();
                }
            }
        }
        void notifier()
        {
            if (ChangementTemperature != null)
                ChangementTemperature(_Temps);
        }
    }
}
