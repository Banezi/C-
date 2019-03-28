using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP_Test_Iris
{
    public class Professeur : Personne
    {
        private string matiere;


        public Professeur(string nom, string prenom, int age) : base(nom, prenom, age)
        {
            
        }

        public string getMatiere()
        {
            return matiere;
        }

        public void setMatiere(string matiere)
        {
            this.matiere = matiere;
        }

        public override string ToString()
        {
            return base.ToString() + " Matière : " + matiere;
        }
    }
}