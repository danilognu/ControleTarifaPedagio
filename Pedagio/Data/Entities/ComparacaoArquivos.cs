using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pedagio.Data.Entities
{
    public class ComparacaoArquivos
    {
        public int ComparacaoArquivosId { get; set; }
        public string NomeArqOrigem1 { get; set; }
        public string NomeArqGerado1 { get; set; }
        public string NomeArqOrigem2 { get; set; }
        public string NomeArqGerado2 { get; set; }
        public DateTime DataCadastro { get; set; }
        public int PessoaIdCad { get; set; }
        public int PessoaIdEmp { get; set; }
        public string PastaArquivo { get; set; }
    }
}
