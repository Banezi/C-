using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerConsole
{
    class SerialisationBinaire : Serialisation
    {
        string fichierBinaireSerialiser = @"C:\Users\" + Environment.UserName + @"\Documents\ContactManagerSerialiserBinaire.db";
        string fichierBinaireSerialiserCrypter = @"C:\Users\" + Environment.UserName + @"\Documents\ContactManagerSerialiserBinaireCrypter.db";
        public override void Serialiser(Dossier dossier)
        {
            //Sauvegarde
            FileStream mFile = new FileStream(fichierBinaireSerialiser, FileMode.Create);
            BinaryFormatter mS = new BinaryFormatter();
            mS.Serialize(mFile, dossier);
            mFile.Close();
            
            Console.WriteLine(dossier.Nom + " est serialiser dans le fichier " + fichierBinaireSerialiser);
            Crypter();
            DecrypterDeserialiser();
        }
        
        public override void Crypter()
        {
            FileStream stream = new FileStream(fichierBinaireSerialiserCrypter, FileMode.OpenOrCreate, FileAccess.Write);

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

            string text = System.IO.File.ReadAllText(fichierBinaireSerialiser);

            byte[] data = ASCIIEncoding.ASCII.GetBytes(text);

            crStream.Write(data, 0, data.Length);

            crStream.Close();
            stream.Close();
            Console.WriteLine("Cryptage du fichier " + fichierBinaireSerialiser + " dans " + fichierBinaireSerialiserCrypter);
        }
        
        public override Dossier DecrypterDeserialiser()
        {
            Console.WriteLine("La clé de décryptage est : " + CLE);
            
            FileStream stream = new FileStream(fichierBinaireSerialiserCrypter, FileMode.Open, FileAccess.Read);

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
            Console.WriteLine("Le fichier " + fichierBinaireSerialiserCrypter + " a bien été décrypter !");
            //Console.WriteLine("La chaine decryptée est : " + data);

            //Déserialisation
            FileStream mFile = new FileStream(fichierBinaireSerialiser, FileMode.Open);
            BinaryFormatter mS = new BinaryFormatter();
            Dossier _rootDeserializer = (Dossier)mS.Deserialize(mFile);
            mFile.Close();

            Console.WriteLine("Le fichier " + fichierBinaireSerialiserCrypter +" a bien été déserialiser !");
            _rootDeserializer.afficher(0);

            reader.Close();
            stream.Close();

            return _rootDeserializer;
        }
        
        }
    }
