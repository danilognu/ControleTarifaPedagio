using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pedagio.Data.Entities
{
    public class ArquivosImportados
    {
        [Key]
        public int ArquivoImportadoId { get; set; }
        public string NomeOrigem { get; set; }
        public string NomeGerado { get; set; }
        public string PastaImportacao { get; set; }
        public DateTime DataImportacao { get; set; }
        public int PessoaIdCad { get; set; }
        public int PessoaIdEmp { get; set; }

    }
}
