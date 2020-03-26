using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pedagio.Data.Entities
{
    public class ViagemSm
    {
        [Key]
        public int ViagemSmId {get; set;}

        public int NumeroSm { get; set; }

        [Column(TypeName = "varchar(8)")]
        public string Placa { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string Motorista { get; set; }

        public DateTime DataInicioViagem { get; set; }
        public DateTime DataFimViagem { get; set; }

    }
}
