using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace TP_Test_Iris
{
    public class ListePersonne
    {
        public List<int> indexAge;
        public List<string> indexNom;
        //public List<string> indexPrenom;
        public List<Personne> liste;
        public ListePersonne()
        {
            indexAge = new List<int>();
            indexNom = new List<string>();
            //indexPrenom = new List<string>();
            liste = new List<Personne>();
        }

        public void afficher(TextBox debug, int ordre)
        {

        }

        public void ajouter(Personne nouvelle)
        {
            liste.Add(nouvelle);
        }
    }
}