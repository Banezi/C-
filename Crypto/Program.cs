using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    class Program
    {
        private static string CLE { get; set; }
        public static void Main()
        {
            
            Console.WriteLine(WindowsIdentity.GetCurrent().User.ToString().Substring(0, 8));
            crypter();
            decrypter();
        }

        private static void crypter()
        {
            FileStream stream = new FileStream("test.txt",
            FileMode.OpenOrCreate, FileAccess.Write);

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


            byte[] data = ASCIIEncoding.ASCII.GetBytes("Hello World!");

            crStream.Write(data, 0, data.Length);

            crStream.Close();
            stream.Close();
        }

        private static void decrypter()
        {
            FileStream stream = new FileStream("test.txt",
                              FileMode.Open, FileAccess.Read);

            DESCryptoServiceProvider cryptic = new DESCryptoServiceProvider();

            string cle = "";
            int tentative = 3;
            do
            {
                Console.WriteLine("Saisir la clé de décryptage : ");
                cle = Console.ReadLine();
                
                if(!cle.Equals(CLE))
                {
                    Console.WriteLine("Clé erronnée, veuillez saisir une clé correcte!");
                    Console.WriteLine("Il vous reste " + --tentative + " tentatives");
                    if (tentative == 0)
                    {
                        Console.WriteLine("Vous avez épuisé le nombre de tentatives, vous n'avez pas l'autorisation d'accéder au fichier!");
                        break;
                    }
                }
            } while (!cle.Equals(CLE) && tentative!=0);
            
            if(!cle.Equals(CLE))
            {
                Console.WriteLine("Vous n'avez pas saisi la bonne clé de decryptage, nous n'avez pas le droit d'accéder au fichier");
                return;
            }
            cryptic.Key = ASCIIEncoding.ASCII.GetBytes(CLE);
            cryptic.IV = ASCIIEncoding.ASCII.GetBytes(WindowsIdentity.GetCurrent().User.ToString().Substring(0,8));

            CryptoStream crStream = new CryptoStream(stream, cryptic.CreateDecryptor(), CryptoStreamMode.Read);

            StreamReader reader = new StreamReader(crStream);

            string data = reader.ReadToEnd();

            //Affichage 
            Console.WriteLine("La chaine decryptée est : " + data);

            reader.Close();
            stream.Close();
        }

        
    }
}
