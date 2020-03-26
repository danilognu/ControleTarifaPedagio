using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pedagio.ViewsModels
{
    public class RodoviaTarifasOperadorasViewsModels
    {
        public int RodoviaTarifasOperadorasId { get; set; }
        public int AssociateId { get; set; }
        public string AssociateCompKnownName { get; set; }
        public int EntryId { get; set; }
        public string RoadCode { get; set; }
        public string RoadEntryKm { get; set; }
        public string Descricao { get; set; }
        public int CategoryArtespId { get; set; }
        public string Nome { get; set; }
        public decimal Tarifa { get; set; }
        public string PAssagem90Dias { get; set; }
        public string Rodovia { get; set; }
        public string Km { get; set; }
        public string Cidade { get; set; }
        public int Eixo { get; set; }
    }
}
