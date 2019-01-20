using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionnaireDocument
{
    class DocumentManager <TDocument> where TDocument : IDocument
    {
        Queue<TDocument> gestionnaire = new Queue<TDocument>();
        void ajoutDocument(TDocument doc)
        {
            gestionnaire.Enqueue(doc);
        }
        void supprimer()
        {
            gestionnaire.Dequeue();
        }
        bool consulter(TDocument doc)
        {
             return gestionnaire.Contains(doc);
        }
    }
}
