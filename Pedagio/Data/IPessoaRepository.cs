using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pedagio.Data.Entities;
using Pedagio.ViewsModels;


namespace Pedagio.Data
{
    public interface IPessoaRepository
    {
        List<TipoPessoa> ListarTipoPessoa(int id);
        List<Pessoa> ListarPessoas(int? id, int? tipoPessoa, string nome);
        TipoPessoa GetTipoPessoa(int id);
        void Salvar(Pessoa pessoa);
        void Deletar(int id);
        void Editar(Pessoa pessoa);
        Pessoa GetPessoa(int id);
        string GetSenha(int id);
        List<PessoaViewsModels> ConsultaPessoas();
    }
}
