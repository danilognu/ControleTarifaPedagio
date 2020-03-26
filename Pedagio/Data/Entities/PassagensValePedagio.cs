using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pedagio.Data.Entities
{
    public class PassagensValePedagio
    {
        [Key]
        public int PassagemValePedagioId { get; set; }
        public string Placa { get; set; }
        public string Tag { get; set; }
        public string Prefixo { get; set; }
        public string Marca { get; set; }
        public string Categ { get; set; }
        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }
        public string Rodovia { get; set; }
        public string Praca { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Valor { get; set; }
        public string Viagem { get; set; }
        public string Embarcador { get; set; }
        public string Cnpj { get; set; }
        public int ArquivoImportadoId { get; set; }
        public int PessoaIdCad { get; set; }
        public int PessoaIdEmp { get; set; }
        public int EixoAbaixado { get; set; }
        public int EixoSuspenso { get; set; }
        public string EixoAbaixadoComparacao { get; set; }
        public string EixoSuspensoComparacao { get; set; }
    }
}
