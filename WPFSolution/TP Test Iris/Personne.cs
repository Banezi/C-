using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Test_Iris
{
    public class Personne
    {
        protected string nom;
        protected string prenom;
        protected int age;

        public Personne(string nom, string prenom, int age)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.age = age;
        }

        public int getAge()
        {
            return age;
        }

        public string getNom()
        {
            return nom;
        }

        public string getPrenom()
        {
            return prenom;
        }

        public override string ToString()
        {
            return "Prénom : " + prenom + " Nom : " + nom + " Age : " + age + " ans";
        }
    }
}
