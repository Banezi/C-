using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerConsole
{
    public class FabriqueSerialisation
    {
        public Serialisation TypeSerialisation { get; set; }

        public void CreerSerialisation(string typeSerialisation)
        {
            if (typeSerialisation.Equals("XML"))
            {
                TypeSerialisation = new SerialisationXML();
            }
            else if (typeSerialisation.Equals("Binaire"))
            {
                TypeSerialisation = new SerialisationBinaire();
            }
            else
            {
                Console.WriteLine("Impossible de faire une Serialisation" + typeSerialisation);
            }
            
        }
    }
}
