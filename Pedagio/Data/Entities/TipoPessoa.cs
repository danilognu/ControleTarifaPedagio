using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pedagio.Data.Entities
{
    public class TipoPessoa
    {
        public int TipoPessoaId { get; set; }
        public string Nome { get; set; }
        public DateTime DataCad { get; set; }
        public DateTime DataAlt { get; set; }
    }
}
