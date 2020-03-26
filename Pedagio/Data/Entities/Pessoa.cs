using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pedagio.Data.Entities
{
    public class Pessoa
    {
        public int PessoaId { get; set; }
        [Required]
        public string Nome { get; set; }
        public string NomeFantasia { get; set; }
        public string Email { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public int Cep { get; set; }
        public int Cnpj { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public int TipoPessoaId { get; set; }
        public DateTime DataCad { get; set; }
        public DateTime dataAlt { get; set; }
        public int PessoaIdCad { get; set; }
        public int PessoaIdAlt { get; set; }
        public int PessoaIdEmp { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public int Status { get; set; }

    }
}
