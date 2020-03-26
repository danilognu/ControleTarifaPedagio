using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pedagio.Data.Entities
{
    public class Rodovia
    {
        [Key]
        public int RodoviaId { get; set; }
        public string NomeRodovia { get; set; }
        public DateTime DataCad { get; set; }
        public DateTime DataAlt { get; set; }
    }
}
