using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerConsole
{
    public enum Lien { ami, collegue, relation, reseau}

    public class Contact
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Societe { get; set; }
        public Lien Lien { get; set; }
        public DateTime DateDeCreation { get; set; }
        public DateTime DateDeModification { get; set; }

        public Contact()
        {

        }

        public Contact(string prenom, string nom, string email, string societe, Lien lien)
        {
            Prenom = prenom;
            Nom = nom;
            Email = email;
            Societe = societe;
            Lien = lien;
            DateDeCreation = DateTime.Now;
            DateDeModification = DateTime.Now;
        }

        public void afficher()
        {
            Console.WriteLine("| [C] " + this.Prenom + ", " + this.Nom + " (" + this.Societe + "), Email : " + this.Email + ", Link : " + this.Lien);
        }
    }
}
