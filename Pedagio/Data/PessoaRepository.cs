using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pedagio.Data.Entities;
using Pedagio.ViewsModels;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Pedagio.Data
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly ApplicationDbContext _context;
        //private object SqlFunctions;

        public PessoaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<TipoPessoa> ListarTipoPessoa(int id)
        {
            var _sQuery = from tp in _context.TipoPessoas
                          select tp;

            if(id > 0)
            {
                _sQuery = _sQuery.Where(b => b.TipoPessoaId == id);
            }

            List<TipoPessoa> listaTipoPessoas = new List<TipoPessoa>();

            foreach(var result in _sQuery)
            {
                listaTipoPessoas.Add(new TipoPessoa() {
                    TipoPessoaId = result.TipoPessoaId,
                    Nome = result.Nome,
                    DataAlt = result.DataAlt,
                    DataCad = result.DataCad
                });
            }

            return listaTipoPessoas.ToList();
        }

        public TipoPessoa GetTipoPessoa(int id)
        {
            var _sQuery = from tp in _context.TipoPessoas
                          select tp;
                _sQuery = _sQuery.Where(b => b.TipoPessoaId == id);


            TipoPessoa tipoPessoas = new TipoPessoa();
            foreach (var result in _sQuery)
            {
                tipoPessoas.TipoPessoaId = result.TipoPessoaId;
                tipoPessoas.Nome = result.Nome;
                tipoPessoas.DataAlt = result.DataAlt;
                tipoPessoas.DataCad = result.DataCad;
            }

            return tipoPessoas;
        }

        public List<Pessoa> ListarPessoas(int? id, int? tipoPessoa, string nome)
        {

            var _sQuery = from p in _context.Pessoas
                      select p;

            if (nome != null)
            {
                   _sQuery = from p in _context.Pessoas
                              where EF.Functions.Like(p.Nome, "" + nome + "%") 
                             select p;
            }
            else
            {
                if (id > 0)
                {
                    _sQuery = _sQuery.Where(b => b.PessoaId == id);
                }
                if (tipoPessoa > 0)
                {
                    _sQuery = _sQuery.Where(b => b.TipoPessoaId == tipoPessoa);
                }
            }

            //nome = "Danilo";
            //var parameterS = new SqlParameter("@s", "Danilo");
            //var sql = @"SELECT * FROM Pessoas where Nome like '%@s%'";
            //var p1 = new SqlParameter("@nome", nome);
            //var _sQuery = _context.Pessoas.FromSql($"SELECT * FROM Pessoas where Nome like '@nome%'", p1)
            //                      .ToList();


            

            List<Pessoa> listaPessoa = new List<Pessoa>();

           foreach(var result in _sQuery)
            {
                listaPessoa.Add(new Pessoa()
                {
                    PessoaId = result.PessoaId,
                    Nome = result.Nome,
                    NomeFantasia = result.NomeFantasia,
                    Email = result.Email,
                    Telefone1 = result.Telefone1,
                    Telefone2 = result.Telefone2,
                    Endereco = result.Endereco,
                    Numero = result.Numero,
                    Bairro = result.Bairro,
                    Cep = result.Cep,
                    Cnpj = result.Cnpj,
                    TipoPessoaId = 1,
                    Status = result.Status,
                    Login = result.Login
                });

            }


            return listaPessoa.ToList();
        }


        public List<PessoaViewsModels> ConsultaPessoas()
        {
            
            var innerQuery = from p in _context.Pessoas
                            join t in _context.TipoPessoas on p.TipoPessoaId equals t.TipoPessoaId
                            select new
                            {
                               Nome = p.Nome,
                               Email = p.Email,
                               Login = p.Login,
                               TipoPessoaNome = t.Nome,
                               Status = p.Status
                            };

            List<PessoaViewsModels> pessoaVM = new List<PessoaViewsModels>();

            foreach(var resultado in innerQuery)
            {
                pessoaVM.Add(new PessoaViewsModels() {
                    Nome = resultado.Nome,
                    Email = resultado.Email,
                    Login = resultado.Login,
                    TipoPessoaNome = resultado.TipoPessoaNome,
                    Status = resultado.Status
                });
            }


            return pessoaVM.ToList();

            //return _context.Pessoas.ToList();
        }

        public void Salvar(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            _context.SaveChanges();
        }

        public string GetSenha(int id)
        {
            string _senha;
            var pessoa = _context.Pessoas.First(c => c.PessoaId == id);
            _senha = pessoa.Senha;
            //Libera LINQ para Cadastrar depois
            _context.Entry(pessoa).State = EntityState.Detached; 
            return pessoa.Senha;
        }

        public Pessoa GetPessoa(int id)
        {
            var pessoa = _context.Pessoas.First(c => c.PessoaId == id);
            return pessoa;
        }

        public void Editar(Pessoa DadosPessoa)
        {
            
            _context.Pessoas.Update(DadosPessoa);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            var pessoa = _context.Pessoas.First(c => c.PessoaId == id);
            _context.Pessoas.Remove(pessoa);
            _context.SaveChangesAsync();
        }

    }
}
