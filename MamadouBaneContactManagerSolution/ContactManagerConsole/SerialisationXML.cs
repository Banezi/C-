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
    class SerialisationXML : Serialisation
    {
        public override void Serialiser(Dossier dossier)
        {
            //Sauvegarde
            StreamWriter stream = new StreamWriter(@"C:\Users\" + Environment.UserName + @"\Documents\ContactManagerSerialiserXML.db");
            XmlSerializer serializer = new XmlSerializer(typeof(Dossier));
            serializer.Serialize(stream, dossier);
            stream.Close();
            Console.WriteLine(dossier.Nom + " est serialiser dans le fichier " + @"C:\Users\" + Environment.UserName + @"\Documents\ContactManagerSerialiserXML.db");
            Crypter();
            //DecrypterDeserialiser();
        }

        public override void Crypter()
        {
            string fichierCrypte = @"C:\Users\" + Environment.UserName + @"\Documents\ContactManagerSerialiserXMLCrypter.db";
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

            string text = System.IO.File.ReadAllText(@"C:\Users\" + Environment.UserName + @"\Documents\ContactManagerSerialiserXML.db");

            byte[] data = ASCIIEncoding.ASCII.GetBytes(text);

            crStream.Write(data, 0, data.Length);

            crStream.Close();
            stream.Close();
            Console.WriteLine("Cryptage du fichier " + @"C:\Users\" + Environment.UserName + @"\Documents\ContactManagerSerialiserXML.db dans " + @"C:\Users\" + Environment.UserName + @"\Documents\ContactManagerSerialiserXMLCrypter.db");
        }

        public override Dossier DecrypterDeserialiser()
        {
            Console.WriteLine("La clé de décryptage est : " + CLE);
            string fichierCrypte = @"C:\Users\" + Environment.UserName + @"\Documents\ContactManagerSerialiserXMLCrypter.db";
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
            Console.WriteLine("Le fichier " + @"C:\Users\" + Environment.UserName + @"\Documents\ContactManagerSerialiserXMLCrypter.db a bien été décrypter !");
            Console.WriteLine("La chaine decryptée est : " + data);

            //Déserialisation
            XmlSerializer deserializer = new XmlSerializer(typeof(Dossier));
            StreamReader stream2 = new StreamReader(@"C:\Users\" + Environment.UserName + @"\Documents\ContactManagerSerialiserXML.db");
            Dossier _rootDeserializer = (Dossier)deserializer.Deserialize(stream2);
            stream2.Close();
            Console.WriteLine("Le fichier " + @"C:\Users\" + Environment.UserName + @"\Documents\ContactManagerSerialiserXMLCrypter.db a bien été déserialiser !");
            _rootDeserializer.afficher(0);

            reader.Close();
            stream.Close();

            return _rootDeserializer;
        }
    }
}
