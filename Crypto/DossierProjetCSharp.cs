using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    class DossierProjetCSharp
    {
        /*
        public void enregistrer()
        {
            enregistrerXML();
            Console.WriteLine("Fichier " + @"C:\Users\" + Environment.UserName + @"\Documents\ContactManagerXML.db' enregistré");
            crypter();   
        }
        */
        /*
        private void enregistrerXML()
        {
            //Sauvegarde
            StreamWriter stream = new StreamWriter(@"C:\Users\" + Environment.UserName + @"\Documents\ContactManagerXML.db");
            XmlSerializer serializer = new XmlSerializer(typeof(Dossier));
            serializer.Serialize(stream, this);
            stream.Close();
        }
        */
        /*
        private static void crypter()
        {
            string fichierCrypte = @"C:\Users\" + Environment.UserName + @"\Documents\ContactManagerXMLCrypter.db";
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

            string text = System.IO.File.ReadAllText(@"C:\Users\" + Environment.UserName + @"\Documents\ContactManagerXML.db");
            
            byte[] data = ASCIIEncoding.ASCII.GetBytes(text);

            crStream.Write(data, 0, data.Length);

            crStream.Close();
            stream.Close();
        }
        */
        /*
        private static Dossier decrypter()
        {
            string fichierCrypte = @"C:\Users\" + Environment.UserName + @"\Documents\ContactManagerXMLCrypter.db";
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
                return null;
            }
            cryptic.Key = ASCIIEncoding.ASCII.GetBytes(CLE);
            cryptic.IV = ASCIIEncoding.ASCII.GetBytes(WindowsIdentity.GetCurrent().User.ToString().Substring(0, 8));

            CryptoStream crStream = new CryptoStream(stream, cryptic.CreateDecryptor(), CryptoStreamMode.Read);

            StreamReader reader = new StreamReader(crStream);

            string data = reader.ReadToEnd();

            //Affichage 
            //Console.WriteLine("La chaine decryptée est : " + data);
            
            //Déserialisation
            XmlSerializer deserializer = new XmlSerializer(typeof(Dossier));
            StreamReader stream2 = new StreamReader(@"C:\Users\" + Environment.UserName + @"\Documents\ContactManager.db");
            Dossier _rootDeserializer = (Dossier)deserializer.Deserialize(stream2);
            stream2.Close();
            //_rootDeserializer.afficher(0);

            reader.Close();
            stream.Close();

            return _rootDeserializer;
        }
        */
    }
}
