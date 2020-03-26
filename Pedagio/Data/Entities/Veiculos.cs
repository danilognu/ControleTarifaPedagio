using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pedagio.Data.Entities
{
    public class Veiculos
    {
        [Key]
        public int VeiculoId { get; set; }
        public string Placa { get; set; }
        public string NomeModelo { get; set; }
        public int TipoVeiculoId { get; set; }
        public int OperacaoVeiculoId { get; set; }
        public int PessoaIdCad { get; set; }
        public int PessoaIdEmp { get; set; }
        public DateTime DataCad { get; set; }
        public DateTime DataAlt { get; set; }
        public int Status { get; set; }
        public int CategoriaIdEixoSuspenso  { get; set; }
        public int CategoriaIdEixoAbaixado { get; set; }
    }
}
