using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
            bool fichierExist = false;
            string fichierSerialiserXML = @"C:\Users\" + Environment.UserName + @"\Documents\ContactManagerSerialiserXML.db";
            string fichierSerialiserBinaire = @"C:\Users\" + Environment.UserName + @"\Documents\ContactManagerSerialiserBinaire.db";
            string typeSerialisation = "";
            if (File.Exists(fichierSerialiserXML) || File.Exists(fichierSerialiserBinaire))
            {
                if((File.Exists(fichierSerialiserXML) && !File.Exists(fichierSerialiserBinaire)) || (File.Exists(fichierSerialiserXML) && File.Exists(fichierSerialiserBinaire)))
                {
                    typeSerialisation = "XML";
                }
                else if (!File.Exists(fichierSerialiserXML) && File.Exists(fichierSerialiserBinaire))
                {
                    typeSerialisation = "Binaire";
                }
                //Console.WriteLine("typeSerialisation : " + typeSerialisation);
                ContactManager m = new ContactManager();
                m.FabriqueSerialisation.CreerSerialisation(typeSerialisation);
                Root = m.FabriqueSerialisation.TypeSerialisation.DecrypterDeserialiser();
                fichierExist = true;
                if (Root == null)
                    return;
            }
            else
            {
                Root = new Dossier("Root");
            }

            manager = new ContactManager(Root);
            if(fichierExist)
            {
                Dossier current = manager.DossierRoot;
                while(current.ListeDossier.Count>0)
                {
                    manager.Parent = current;
                    current = current.ListeDossier[current.ListeDossier.Count - 1];
                }
                manager.Current = current;
            }
            //Console.WriteLine("Parent : " + manager.Parent.Nom);
            //Console.WriteLine("Current : " + manager.Current.Nom);

            //Affichage menu
            afficherMenu2();
            
            //Console.WriteLine("\n\nAppuyez sur entrée pour quitter!");
            //Console.ReadLine();
        }

        private static void afficherMenu2()
        {
            Console.WriteLine("\nInstruction : Dans ce menu vous allez interagir avec le programme en ligne de commande !\n");
            Console.WriteLine("Pour afficher le contenu du dossier racine taper : afficher\n");
            Console.WriteLine("Pour enregistrer le contenu du dossier racine taper : enregistrer\n");
            Console.WriteLine("Pour ajouter un dossier taper : ajouterdossier nomdossier\n");
            Console.WriteLine("Pour ajouter un contact taper : ajoutercontact nom prenom société email lien\n");
            Console.WriteLine("Attention les valeurs possibles pour lien sont : ami, collegue, relation, reseau\n");
            Console.WriteLine("Pour quitter taper : quitter\n");
            string[] commande;
            do
            {
                bool choixOk = false;
                do
                {
                    string lignecommande = "";
                    Console.Write(">");
                    lignecommande = Console.ReadLine();
                    commande = lignecommande.Split(' ');

                    string choix = commande[0];
                
                    switch (choix)
                    {
                        case "quitter":
                            choixOk = true;
                            return;
                        case "afficher":
                            afficher();
                            choixOk = true;
                            break;
                        case "enregistrer":
                            enregistrer();
                            choixOk = true;
                            break;
                        case "ajouterdossier":
                            string nomDossier ="";
                            for (int i = 1; i < commande.Length; i++)
                            {
                                nomDossier += commande[i];
                                if (i != commande.Length)
                                    nomDossier += " ";
                            }
                            
                            ajouterdossier(nomDossier);
                            afficher();
                            choixOk = true;
                            break;
                        case "ajoutercontact":
                            if (commande.Length != 6)
                            {
                                Console.WriteLine("Commande incorrecte! Veuillez taper une commande correcte !");
                                choixOk = false;
                            }
                            else
                            {
                                ajoutercontact(commande[1], commande[2], commande[3], commande[4], commande[5]);
                                choixOk = true;
                            }
           
                            break;
                        default:
                            Console.WriteLine("Instruction inconnue. Veuillez taper une commande valide !");
                            choixOk = false;
                            break;
                    }
                } while (!choixOk);

                //Console.WriteLine("\nVoulez-vous continuer ? (O/N)");
                //continuer = Console.ReadLine().ElementAt(0);
                Console.WriteLine("\n\n");
            } while (!commande[0].Equals("quitter"));

        }

        private static void ajoutercontact(string nom, string prenom, string societe, string email, string lienSaisi)
        {
            Lien lien;
            switch (lienSaisi)
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
                    lien = Lien.ami;
                    break;
            }
            Contact nvoContact = new Contact(prenom, nom, email, societe, lien);
            manager.ajoutercontact(nvoContact);
        }

        private static void ajouterdossier(string nomDossier)
        {
            manager.ajouterdossier(nomDossier);
        }

        private static void afficherMenu1()
        {
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
            } while (continuer == 'O');
        }

        private static void ajoutercontact()
        {
            string prenom, nom, email, societe;
            Lien lien = Lien.collegue;
            Console.Write("Saisir le prénom : ");
            prenom = Console.ReadLine();
            Console.Write("Saisir le nom : ");
            nom = Console.ReadLine();
            Console.Write("Saisir le nom de la société : ");
            societe = Console.ReadLine();
            Console.Write("Saisir l'email : ");
            email = Console.ReadLine();
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
            string typeSerialisation = "";
            do
            {
                Console.Write("Choisir le type de sérialisation (XML ou Binaire) : ");
                typeSerialisation = Console.ReadLine();

            } while (!typeSerialisation.Equals("XML") && !typeSerialisation.Equals("Binaire"));
            
            Console.WriteLine("Enregistrement du fichier '" + @"C:\Users\" + Environment.UserName + @"\Documents\ContactManagerSerialiser" + typeSerialisation +".db' ...........");
            manager.FabriqueSerialisation.CreerSerialisation(typeSerialisation);
            manager.FabriqueSerialisation.TypeSerialisation.Serialiser(manager.DossierRoot);
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
