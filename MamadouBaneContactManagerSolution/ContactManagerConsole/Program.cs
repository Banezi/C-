using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerConsole
{
    class Program
    {
        static Dossier Root;
        static ContactManager manager;
        static void Main(string[] args)
        {
            //Création ou Récupération de Root 
            if(File.Exists(@"C:\Users\" + Environment.UserName + @"\Documents\ContactManager.db"))
            {
                Root = Dossier.recuperer();
            }
            else
            {
                Root = new Dossier("Root");
            }

            manager = new ContactManager(Root);

            char continuer = 'O';
            do
            {
                Console.WriteLine("Saisissez votre choix : ");

                Console.WriteLine("Choix possibles : ");
                Console.WriteLine("\t 1 - sortir");
                Console.WriteLine("\t 2 - afficher");
                Console.WriteLine("\t 3 - changer");
                Console.WriteLine("\t 4 - enregistrer");
                Console.WriteLine("\t 5 - ajouterdossier");
                Console.WriteLine("\t 6 - ajoutercontact");

                string choix;
                bool choixOk = false;
                do
                {
                    Console.Write("choix = ");
                    choix = Console.ReadLine();
                    switch (choix)
                    {
                        case "1":
                            choixOk = true;
                            return;
                        case "2":
                            afficher();
                            choixOk = true;
                            break;
                        case "3":
                            changer();
                            choixOk = true;
                            break;
                        case "4":
                            enregistrer();
                            choixOk = true;
                            break;
                        case "5":
                            ajouterdossier();
                            choixOk = true;
                            break;
                        case "6":
                            ajoutercontact();
                            choixOk = true;
                            break;
                        default:
                            Console.WriteLine("Instruction inconnue. Veuillez choisir parmi les choix possible.");
                            choixOk = false;
                            break;
                    }
                } while (!choixOk);
                Console.WriteLine("\nVoulez-vous continuer ? (O/N)");
                continuer = Console.ReadLine().ElementAt(0);
                Console.WriteLine("\n\n");
            } while (continuer=='O');
            
            Console.WriteLine("\n\nAppuyez sur entrée pour quitter!");
            Console.ReadLine();
        }

        private static void ajoutercontact()
        {
            string prenom, nom, email, societe;
            Lien lien = Lien.collegue;
            Console.Write("Saisir le prénom : ");
            prenom = Console.ReadLine();
            Console.Write("Saisir le nom : ");
            nom = Console.ReadLine();
            Console.Write("Saisir l'email : ");
            email = Console.ReadLine();
            Console.Write("Saisir le nom de la société : ");
            societe = Console.ReadLine();
            bool lienOk = true;
            do
            {
                Console.Write("Saisir le lien (lien possible : ami, collegue, relation reseau) : ");
                string liensaisi = Console.ReadLine();
                switch (liensaisi)
                {
                    case "ami":
                        lien = Lien.ami;
                        break;
                    case "collegue":
                        lien = Lien.collegue;
                        break;
                    case "relation":
                        lien = Lien.relation;
                        break;
                    case "reseau":
                        lien = Lien.reseau;
                        break;
                    default:
                        lienOk = false;
                        break;
                }
            } while (!lienOk);

            Contact nvoContact = new Contact(prenom, nom, email, societe, lien);
            manager.ajoutercontact(nvoContact);
        }

        private static void ajouterdossier()
        {
            string nomDossier;
            Console.Write("Saisir le nom du dossier : ");
            nomDossier = Console.ReadLine();
            manager.ajouterdossier(nomDossier);
        }

        private static void enregistrer()
        {
            Console.WriteLine("Enregistrement du fichier '" + @"C:\Users\" + Environment.UserName + @"\Documents\ContactManager.db' ..........." );
            Root.enregistrer();
        }

        private static void changer()
        {
            throw new NotImplementedException();
        }

        private static void afficher()
        {
            manager.afficher();
        }
    }
}
