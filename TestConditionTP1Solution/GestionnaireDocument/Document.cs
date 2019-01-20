using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionnaireDocument
{
    class Document : IDocument
    {
        public Document(string titre, string contenu)
        {
            this.titre = titre;
            this.contenu = contenu;
        }

        public string titre { get; set; }
        public string contenu { get ; set; }
    }
}
