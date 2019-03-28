using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TP_Test_Iris
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ListePersonne listePersonne = new ListePersonne();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Etudiant_Checked(object sender, RoutedEventArgs e)
        {
            ClasseMatiereLabel.Content = "Classe : ";
        }

        private void Professeur_Checked(object sender, RoutedEventArgs e)
        {
            ClasseMatiereLabel.Content = "Matière : ";
        }

        private void Chronologique_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void Enregistrement_CLicked(object sender, RoutedEventArgs e)
        {
            int age;
            string nom, prenom, classe,matiere;
            age = int.Parse(Age.Text);
            nom = Nom.Text;
            prenom = Prenom.Text;
            listePersonne.indexAge.Add(age);
            listePersonne.indexNom.Add(nom + " " + prenom);
            //listePersonne.indexPrenom.Add(prenom);
            if(Etudiant.IsChecked==true)
            {
                classe = ClasseMatiere.Text;
                Etudiant etudiant = new Etudiant(nom, prenom, age);
                etudiant.setClasse(classe);
                if (nom != "" && prenom != "" && classe != "")
                {
                    listePersonne.ajouter(etudiant);
                    MessageBox.Show("Enregistrement Ok!");
                }
                else
                    MessageBox.Show("Erreur d'enregistrement");
                
            }
            else
            {
                matiere = ClasseMatiere.Text;
                Professeur prof = new Professeur(nom, prenom, age);
                prof.setMatiere(matiere);
                if (nom != "" && prenom != "" && matiere != "")
                {
                    listePersonne.ajouter(prof);
                    MessageBox.Show("Enregistrement Ok!");
                }
                else
                    MessageBox.Show("Erreur d'enregistrement");
            }
        }
    }
}
