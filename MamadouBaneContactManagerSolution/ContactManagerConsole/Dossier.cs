using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ContactManagerConsole
{
    [Serializable]
    public class Dossier
    {
        public string Nom { get; set; }
        public DateTime DateDeCreation { get; set; } 
        public DateTime DateDeModification { get; set; }
        public List<Dossier> ListeDossier { get; set; }
        public List<Contact> ListeContact { get; set; }
        private static string CLE { get; set; }

        public Dossier()
        {
            
        }

        public Dossier(string nom)
        {
            Nom = nom;
            DateDeCreation = DateTime.Now;
            DateDeModification = DateTime.Now;
            ListeDossier = new List<Dossier>();
            ListeContact = new List<Contact>();
        }

        public void afficher(int decallage)
        {
            for(int i=0; i< decallage; i++)
            {
                Console.Write("    ");
            }
            Console.WriteLine("[D] " + this.Nom + " (création " + this.DateDeCreation + ")");
            for (int nbc = 0; nbc < this.ListeContact.Count; nbc++)
            {
                for (int i = 0; i < decallage; i++)
                {
                    Console.Write("    ");
                }
                this.ListeContact[nbc].afficher();
            }
            for (int nbd=0; nbd<this.ListeDossier.Count;nbd++)
            {
                this.ListeDossier[nbd].afficher(decallage + 1);
            }
            
        }
        
        public static Dossier recuperer()
        {
            //Chargement
            XmlSerializer deserializer = new XmlSerializer(typeof(Dossier));

            StreamReader stream = new StreamReader(@"C:\Users\" + Environment.UserName + @"\Documents\ContactManagerSerialiserXML.db");
            Dossier _rootDeserializer = (Dossier) deserializer.Deserialize(stream);
            stream.Close();

            return _rootDeserializer;
        }
        
    }
}
