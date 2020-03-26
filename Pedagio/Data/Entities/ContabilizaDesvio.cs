using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pedagio.Data.Entities
{
    public class ContabilizaDesvio
    {
        [Key]
        public int ContabilizaDesvioId { get; set; }
        public string Placa { get; set; }
        public string Viagem { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal ValorCredito { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal ValorPassagemValePedagio { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Desvio { get; set; }
        public int ArquivoImportadoId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataCad { get; set; }
        public int PessoaIdCad { get; set; }
        public int PessoaIdEmp { get; set; }

    }
}
