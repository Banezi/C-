using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionnaireDocument
{
    public interface IDocument
    {
        string titre { get; set; }
        string contenu { get; set; }
    }
}
