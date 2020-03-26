using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pedagio.Data.Entities
{
    public class Passagem
    {
        public int PassagemId { get; set; }
        public string Placa { get; set; }
        public DateTime Data { get; set; }
        public string Hora { get; set; }
        public string Rodovia { get; set; }
        public string Praca { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Valor { get; set; }
        public int Viagem { get; set; }
        public string Embarcado { get; set; }
        public string Categoria { get; set; }
        public int Tag { get; set; }
        public int NumVP { get; set; }
        public DateTime DataCad { get; set; }
        public DateTime DataAlt { get; set; }
        public int PessoaIdCad { get; set; }
        public int PessoaIdAlt { get; set; }
        public int PessoaIdEmp { get; set; }
        public int ComparacaoArquivosId { get; set; }
    }
}
