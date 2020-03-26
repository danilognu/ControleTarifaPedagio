using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pedagio.Data.Entities
{
    public class RodoviaTarifasOperadoras
    {
        [Key]
        public int RodoviaTarifasOperadorasId { get; set; }
        public int AssociateId { get; set; }
        public string AssociateCompKnownName { get; set; }
        public int EntryId { get; set; }
        public string RoadCode { get; set; }
        public string RoadEntryKm { get; set; }
        public string Descricao { get; set; }
        public int CategoryArtespId { get; set; }
        public string Nome { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Tarifa { get; set; } 
        public string PAssagem90Dias { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Rodovia { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Km { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Cidade { get; set; }
        public int Eixo { get; set; }

    }
}
