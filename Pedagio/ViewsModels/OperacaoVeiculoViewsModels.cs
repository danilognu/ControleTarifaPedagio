using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pedagio.ViewsModels
{
    public class OperacaoVeiculoViewsModels
    {
        public int OperacaoVeiculoId { get; set; }
        public string Nome { get; set; }
        public int PessoaIdCad { get; set; }
        public int PessoaIdEmp { get; set; }
        public int Status { get; set; }
    }
}
