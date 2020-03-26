using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pedagio.Data.Entities
{
    public class Creditos
    {
        [Key]
        public int CreditoId { get; set; }
        public string Placa { get; set; }
        public string Tag { get; set; }
        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }
        public string Descricao { get; set; }
        public string Viagem { get; set; }
        public string Praca { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Valor { get; set; }
        public string Embarcador { get; set; }
        public string Cnpj { get; set; }
        public int ArquivoImportadoId { get; set; }
        public int PessoaIdCad { get; set; }
        public int PessoaIdEmp { get; set; }
    }
}
