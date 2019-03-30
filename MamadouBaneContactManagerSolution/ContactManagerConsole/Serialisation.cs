using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerConsole
{
    public class Serialisation
    {
        public Serialisation TypeSerialisation { get; set; }
        public static string CLE { get; set; }



        public virtual void Serialiser(Dossier dossier)
        {
           
        }

        public virtual Dossier DecrypterDeserialiser()
        {
            return TypeSerialisation.DecrypterDeserialiser();
        }

        public virtual void Crypter()
        {

        }

        public virtual void Decrypter()
        {

        }
    }
}
