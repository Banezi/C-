using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP_Test_Iris
{
    public class Etudiant : Personne
    {
        private string classe;

        public Etudiant(string nom, string prenom, int age) : base(nom,prenom,age)
        {
            
        }

        public string getClasse()
        {
            return classe;
        }
        public void setClasse(string classe)
        {
            this.classe = classe;
        }
        public override string ToString()
        {
            return base.ToString() + " Classe : " + classe;
        }
    }
}