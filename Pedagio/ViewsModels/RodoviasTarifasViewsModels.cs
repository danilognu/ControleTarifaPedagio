using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pedagio.ViewsModels
{
    public class RodoviasTarifasViewsModels
    {
        public int RodoviaTarifaId { get; set; }
        public string Rodovia { get; set; }
        public string Km { get; set; }
        public string Cidade { get; set; }
        public int RodoviaTarifasOperadorasId { get; set; }
    }
}
