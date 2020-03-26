using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pedagio.Data.Entities
{
    public class PassagensPedagio
    {
        [Key]
        public int PassagemPedagioId { get; set; }
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
        public int ArquivoImportadoId { get; set; }
        public int PessoaIdCad { get; set; }
        public int PessoaIdEmp { get; set; }
        public string EixoAbaixadoComparacao { get; set; }
        public string EixoSuspensoComparacao { get; set; }
        public string ComparaTarifa { get; set; }
        //Chave para busca tabela tarifa
        public string OpRodoviaChave { get; set; }
        public string KmChave { get; set; }
        public string SentidoChave { get; set; }
        public string CidadeChave { get; set; }
        public string EstadoChave { get; set; }



    }
}
