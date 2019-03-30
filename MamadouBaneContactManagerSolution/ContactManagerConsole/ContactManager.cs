using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerConsole
{
    [Serializable]
    public class ContactManager
    {
        public Dossier DossierRoot { get; set; }
        public Dossier Current { get; set; }
        public Dossier Parent { get; set; }
        public FabriqueSerialisation FabriqueSerialisation { get; set; }
        public ContactManager()
        {
            DossierRoot = new Dossier();
            Current = DossierRoot;
            Parent = DossierRoot;
            FabriqueSerialisation = new FabriqueSerialisation();
        }

        public ContactManager(Dossier dossierRoot)
        {
            DossierRoot = dossierRoot;
            Current = DossierRoot;
            Parent = DossierRoot;
            FabriqueSerialisation = new FabriqueSerialisation();
        }

        public void ajouterdossier(string nomDossier)
        {
            Dossier nvoDossier = new Dossier(nomDossier);
            Current.ListeDossier.Add(nvoDossier);
            Parent = Current;
            Current = Current.ListeDossier.ElementAt(Current.ListeDossier.Count - 1);
            Console.WriteLine("\nDossier '" + nvoDossier.Nom + "' ajouté sous " + Parent.Nom + " en position " + Parent.ListeDossier.Count + ".");
        }

        public void afficher()
        {
            DossierRoot.afficher(0);
        }

        public void ajoutercontact(Contact nvoContact)
        {
            Current.ListeContact.Add(nvoContact);
            Console.WriteLine("\nContact '" + nvoContact.Nom + "' ajouté sous " + Current.Nom + " en position " + Current.ListeContact.Count + ".");
        }
    }
}
