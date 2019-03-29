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

        public void enregistrer()
        {
            enregistrerXML();
            Console.WriteLine("Fichier " + @"C:\Users\" + Environment.UserName + @"\Documents\ContactManager.db' enregistré");
            crypter();
            Console.WriteLine("Fichier " + @"C:\Users\" + Environment.UserName + @"\Documents\ContactManagerCrypter.db' enregistré");
            decrypter();
        }

        private void enregistrerXML()
        {
            //Sauvegarde
            StreamWriter stream = new StreamWriter(@"C:\Users\" + Environment.UserName + @"\Documents\ContactManager.db");

            /*****************************************************************************************/
            /*                                          Cryptage                                     */
            /*****************************************************************************************/

            XmlSerializer serializer = new XmlSerializer(typeof(Dossier));
            serializer.Serialize(stream, this);
            stream.Close();
            
        }

        public static Dossier recuperer()
        {
            //Chargement
            XmlSerializer deserializer = new XmlSerializer(typeof(Dossier));

            StreamReader stream = new StreamReader(@"C:\Users\" + Environment.UserName + @"\Documents\ContactManager.db");
            Dossier _rootDeserializer = (Dossier) deserializer.Deserialize(stream);
            stream.Close();

            return _rootDeserializer;
        }

        private static void crypter()
        {
            string fichierCrypte = @"C:\Users\" + Environment.UserName + @"\Documents\ContactManagerCrypter.db";
            FileStream stream = new FileStream(fichierCrypte, FileMode.OpenOrCreate, FileAccess.Write);

            DESCryptoServiceProvider cryptic = new DESCryptoServiceProvider();

            string cle = "";
            do
            {
                Console.WriteLine("Saisir la clé de cryptage (8 caractères) : ");
                cle = Console.ReadLine();
            } while (cle.Length != 8);
            CLE = cle;

            cryptic.Key = ASCIIEncoding.ASCII.GetBytes(CLE);
            cryptic.IV = ASCIIEncoding.ASCII.GetBytes(WindowsIdentity.GetCurrent().User.ToString().Substring(0, 8));

            CryptoStream crStream = new CryptoStream(stream, cryptic.CreateEncryptor(), CryptoStreamMode.Write);

            string text = System.IO.File.ReadAllText(@"C:\Users\" + Environment.UserName + @"\Documents\ContactManager.db");
            // Display the file contents to the console. Variable text is a string.
            //System.Console.WriteLine("Contents of WriteText.txt = {0}", text);

           
            byte[] data = ASCIIEncoding.ASCII.GetBytes(text);

            crStream.Write(data, 0, data.Length);

            crStream.Close();
            stream.Close();
        }

        private static void decrypter()
        {
            string fichierCrypte = @"C:\Users\" + Environment.UserName + @"\Documents\ContactManagerCrypter.db";
            FileStream stream = new FileStream(fichierCrypte, FileMode.Open, FileAccess.Read);

            DESCryptoServiceProvider cryptic = new DESCryptoServiceProvider();

            string cle = "";
            int tentative = 3;
            do
            {
                Console.WriteLine("Saisir la clé de décryptage : ");
                cle = Console.ReadLine();

                if (!cle.Equals(CLE))
                {
                    Console.WriteLine("Clé erronnée, veuillez saisir une clé correcte!");
                    Console.WriteLine("Il vous reste " + --tentative + " tentatives");
                    if (tentative == 0)
                    {
                        Console.WriteLine("Vous avez épuisé le nombre de tentatives, vous n'avez pas l'autorisation d'accéder au fichier!");
                        break;
                    }
                }
            } while (!cle.Equals(CLE) && tentative != 0);

            if (!cle.Equals(CLE))
            {
                Console.WriteLine("Vous n'avez pas saisi la bonne clé de decryptage, nous n'avez pas le droit d'accéder au fichier");
                return;
            }
            cryptic.Key = ASCIIEncoding.ASCII.GetBytes(CLE);
            cryptic.IV = ASCIIEncoding.ASCII.GetBytes(WindowsIdentity.GetCurrent().User.ToString().Substring(0, 8));

            CryptoStream crStream = new CryptoStream(stream, cryptic.CreateDecryptor(), CryptoStreamMode.Read);

            StreamReader reader = new StreamReader(crStream);

            string data = reader.ReadToEnd();

            //Affichage 
            Console.WriteLine("La chaine decryptée est : " + data);
            
            //Déserialisation
            XmlSerializer deserializer = new XmlSerializer(typeof(Dossier));
            StreamReader stream2 = new StreamReader(@"C:\Users\" + Environment.UserName + @"\Documents\ContactManager.db");
            Dossier _rootDeserializer = (Dossier)deserializer.Deserialize(stream2);
            stream2.Close();
            _rootDeserializer.afficher(0);

            reader.Close();
            stream.Close();
        }

    }
}
