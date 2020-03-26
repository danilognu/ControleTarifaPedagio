using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pedagio.ViewsModels
{
    public class ChaveBuscaViewsModels
    {
        public string Operadora { get; set; }
        public string Rodovia { get; set; }
        public string Km { get; set; }
        public string Sentido { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public bool Valida { get; set; }
    }
}
