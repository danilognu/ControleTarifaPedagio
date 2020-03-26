using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Pedagio.Data;
using Pedagio.Data.Entities;
using Pedagio.ViewsModels;
using Pedagio.Dominio;
using System;
using System.Security.Cryptography;

namespace Pedagio.Controllers
{
    public class PessoaController : Controller
    {

        private readonly IPessoaRepository _pessoaRepository;

        public PessoaController(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var pessoas = _pessoaRepository.ConsultaPessoas();
            return View(pessoas);
        }

        [HttpGet]
        public IActionResult ConsultaPessoa(string tipoPessoa)
        {

            int codigoTipoPessoa = 0;
            int id = 0;

            if (tipoPessoa == "User")
            {
                codigoTipoPessoa = Comum.CodigoTipoPessoaUsuario;
                ViewBag.NomeTitulo = "Usuario";
            }
            else
            {
                codigoTipoPessoa = Comum.CodigoTipoPessoaEmpresa;
                ViewBag.NomeTitulo = "Empresa";
            }

            var listaPessoas = _pessoaRepository.ListarPessoas(id, codigoTipoPessoa, null);
            return View(listaPessoas);
        }

        [HttpPost]
        public IActionResult ConsultaPessoa(string tipoPessoa, string nome)
        {
            int codigoTipoPessoa = 0;
            int id = 0;
            

            if (tipoPessoa == "Usuario")
            {
                codigoTipoPessoa = Comum.CodigoTipoPessoaUsuario;
                ViewBag.NomeTitulo = "Usuario";
            }
            else
            {
                codigoTipoPessoa = Comum.CodigoTipoPessoaEmpresa;
                ViewBag.NomeTitulo = "Empresa";
            }
            
            var listaPessoas = _pessoaRepository.ListarPessoas(id, codigoTipoPessoa, nome);

            return View(listaPessoas);
        }


        [HttpGet]
        public IActionResult SalvarPessoa(int? id, string tipoPessoa)
        {
            int codigoTipoPessoa = 0;
            bool UserTipoPessoa = true;
            
            if (tipoPessoa == "User")
            {
                codigoTipoPessoa = Comum.CodigoTipoPessoaUsuario;
                UserTipoPessoa = true;
                ViewBag.NomeTitulo = "Usuario";
            }
            else
            {
                codigoTipoPessoa = Comum.CodigoTipoPessoaEmpresa;
                UserTipoPessoa = false;
                ViewBag.NomeTitulo = "Empresa";
            }

            List<Pessoa> listaPessoas = new List<Pessoa>();
            PessoaViewsModels pessoaViewsModels = new PessoaViewsModels();
            pessoaViewsModels.UserTipoPessoa = UserTipoPessoa;
            pessoaViewsModels.TipoPessoaId = codigoTipoPessoa;
            pessoaViewsModels.Status = 1;

            ViewBag.TipoPessoas = _pessoaRepository.ListarTipoPessoa(codigoTipoPessoa);

            if (id != null)
            {
                listaPessoas = _pessoaRepository.ListarPessoas(id, codigoTipoPessoa, null);

                foreach(var pessoa in listaPessoas)
                {
                    var _cep = Convert.ToString(pessoa.Cep);
                    var _cnpj = Convert.ToString(pessoa.Cnpj);

                    pessoaViewsModels.PessoaId = pessoa.PessoaId;
                    pessoaViewsModels.Nome = pessoa.Nome;
                    pessoaViewsModels.NomeFantasia = pessoa.NomeFantasia;
                    pessoaViewsModels.Email = pessoa.Email;
                    pessoaViewsModels.Telefone1 = pessoa.Telefone1;
                    pessoaViewsModels.Telefone2 = pessoa.Telefone2;
                    pessoaViewsModels.Endereco = pessoa.Endereco;
                    pessoaViewsModels.Numero = pessoa.Numero;
                    pessoaViewsModels.Bairro = pessoa.Bairro;
                    pessoaViewsModels.Cep = _cep;
                    pessoaViewsModels.Cnpj = _cnpj;
                    pessoaViewsModels.TipoPessoaId = codigoTipoPessoa;
                    pessoaViewsModels.Status = pessoa.Status;
                    pessoaViewsModels.Login = pessoa.Login;
                    pessoaViewsModels.Senha = pessoa.Senha;
                    pessoaViewsModels.UserTipoPessoa = UserTipoPessoa;

                }

            }
           

            return View(pessoaViewsModels);

        }

        [HttpPost]
        public IActionResult SalvarPessoa(PessoaViewsModels pessoaViewsModels)
        {
            int _cnpj = 0;
            int _cep = 0;
            string _telefone1;
            string _telefone2;
            string _senha;

            Hash hash = new Hash(SHA512.Create());
            Pessoa _pessoa = new Pessoa();

            _cnpj = Convert.ToInt32(Comum.ClearCNPJ(pessoaViewsModels.Cnpj));
            _cep = Convert.ToInt32(Comum.ClearCEP(pessoaViewsModels.Cep));
            _telefone1 = Comum.ClearTelefone(pessoaViewsModels.Telefone1);
            _telefone2 = Comum.ClearTelefone(pessoaViewsModels.Telefone2);

            if (pessoaViewsModels.Senha != null)
            {
                _senha = hash.CriptografarSenha(pessoaViewsModels.Senha);
            }
            else
            {
                _senha =  _pessoaRepository.GetSenha(pessoaViewsModels.PessoaId);

            }
            
            _pessoa.PessoaId = pessoaViewsModels.PessoaId;
            _pessoa.Nome = pessoaViewsModels.Nome;
            _pessoa.NomeFantasia = pessoaViewsModels.NomeFantasia;
            _pessoa.Email = pessoaViewsModels.Email;
            _pessoa.Telefone1 = _telefone1;
            _pessoa.Telefone2 = _telefone2;
            _pessoa.Endereco = pessoaViewsModels.Endereco;
            _pessoa.Numero = pessoaViewsModels.Numero;
            _pessoa.Bairro = pessoaViewsModels.Bairro;
            _pessoa.Cep = _cep;
            _pessoa.Cnpj = _cnpj;
            _pessoa.Status = pessoaViewsModels.Status;
            _pessoa.Login = pessoaViewsModels.Login;
            _pessoa.Senha = _senha;


            if (pessoaViewsModels.PessoaId == 0)
            {
                TipoPessoa tipoPessoa = new TipoPessoa();
                _pessoa.TipoPessoa = _pessoaRepository.GetTipoPessoa(pessoaViewsModels.TipoPessoaId);

                _pessoa.DataCad = DateTime.Today;
                _pessoaRepository.Salvar(_pessoa);
            }
            else
            {
                _pessoa.TipoPessoaId = pessoaViewsModels.TipoPessoaId;
                _pessoa.dataAlt = DateTime.Today;
                _pessoaRepository.Editar(_pessoa);
            }

            string tipoDeConsulta = "";
            if(pessoaViewsModels.TipoPessoaId == Comum.CodigoTipoPessoaUsuario)
            {
                tipoDeConsulta = "User";
            }
            else
            {
                tipoDeConsulta = "Company";
            }

            return RedirectToAction("ConsultaPessoa", new { tipoPessoa = tipoDeConsulta });

        }

        [HttpGet]
        public IActionResult CancelaPessoa(int tipoPessoaId)
        {
            string tipoDeConsulta = "";
            if (tipoPessoaId == Comum.CodigoTipoPessoaUsuario)
            {
                tipoDeConsulta = "User";
            }
            else
            {
                tipoDeConsulta = "Company";
            }

            return RedirectToAction("ConsultaPessoa", new { tipoPessoa = tipoDeConsulta });
        }


        //Em breve deletar
        [HttpGet]
        public IActionResult Cadastro()
        {
            //ViewBag.TipoPessoas = _pessoaRepository.ListarTipoPessoa();
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Pessoa viewModel)
        {


            viewModel.TipoPessoa.TipoPessoaId = 5;

            if (viewModel.PessoaId == 0)
            {
                _pessoaRepository.Salvar(viewModel);
            }
            else
            {
                _pessoaRepository.Editar(viewModel);                
            }

            return RedirectToAction("Cadastro");
        }

        public IActionResult Editar(int id)
        {
            var pessoa = _pessoaRepository.GetPessoa(id);

            var pessoaViewsModels = new PessoaViewsModels();
            var tipoPessoaViewsModels = new TipoPessoaViewsModels();

            tipoPessoaViewsModels.TipoPessoaId = pessoa.TipoPessoaId;
            tipoPessoaViewsModels.Nome = "";

            pessoaViewsModels.PessoaId = pessoa.PessoaId;
            pessoaViewsModels.Nome = pessoa.Nome;
            pessoaViewsModels.NomeFantasia = pessoa.NomeFantasia;
            pessoaViewsModels.Email = pessoa.Email;
            pessoaViewsModels.Telefone1 = pessoa.Telefone1;
            pessoaViewsModels.Telefone2 = pessoa.Telefone2;
            pessoaViewsModels.Endereco = pessoa.Endereco;
            pessoaViewsModels.Numero = pessoa.Numero;
            pessoaViewsModels.Bairro = pessoa.Bairro;
            //pessoaViewsModels.Cep = pessoa.Cep;
            //pessoaViewsModels.Cnpj = pessoa.Cnpj;
            pessoaViewsModels.TipoPessoa = tipoPessoaViewsModels;
            pessoaViewsModels.TipoPessoaId = pessoa.TipoPessoaId;
            pessoaViewsModels.DataCad = pessoa.DataCad;
            pessoaViewsModels.dataAlt = pessoa.dataAlt;
            pessoaViewsModels.PessoaIdCad = pessoa.PessoaIdCad;
            pessoaViewsModels.PessoaIdAlt = pessoa.PessoaIdAlt;
            pessoaViewsModels.PessoaIdEmp = pessoa.PessoaIdEmp;
            pessoaViewsModels.Login = pessoa.Login;
            pessoaViewsModels.Senha = pessoa.Senha;
            pessoaViewsModels.Status = pessoa.Status;

            return View("Cadastro", pessoaViewsModels);
        }

        public IActionResult Deletar(int id)
        {
            _pessoaRepository.Deletar(id);
            return RedirectToAction("Index");
        }

    }
}
