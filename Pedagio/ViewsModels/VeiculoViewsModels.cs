using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pedagio.ViewsModels
{
    public class VeiculoViewsModels
    {
        public int VeiculoId { get; set; }

        [Required(ErrorMessage = "Por favor, preencha a Placa")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "Por favor, preencha a Modelo")]
        public string NomeModelo { get; set; }

        public int TipoVeiculoId { get; set; }
        public int OperacaoVeiculoId { get; set; }

        public string TipoVeiculoNome { get; set; }
        public string OperacaoVeiculoNome { get; set; }

        public int PessoaIdCad { get; set; }
        public int PessoaIdEmp { get; set; }
        public DateTime DataCad { get; set; }
        public DateTime DataAlt { get; set; }

        public int Status { get; set; }

        public int CategoriaIdEixoSuspenso { get; set; }
        public int CategoriaIdEixoAbaixado { get; set; }

    }
}
