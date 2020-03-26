using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pedagio.ViewsModels;
using Pedagio.Data;
using Pedagio.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pedagio.Controllers
{
    public class VeiculoController : Controller
    {

        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoController(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        //Consultar
        [HttpGet]
        public IActionResult Consulta()
        {
            var veiculos = _veiculoRepository.ListarVeiculos(0);
            return View(veiculos);
        }


        [HttpPost]
        public JsonResult Consulta([FromBody] VeiculoViewsModels veiculo)
        {
           
            return Json(veiculo.Placa);
        }

        //Tipo de Veiculo
        [HttpGet]
        public IActionResult ConsultaTipoVeiculo()
        {
            var tipoVeiculos = _veiculoRepository.ListarTipoVeiculos(0);
            return View(tipoVeiculos);
        }

        [HttpGet]
        public IActionResult SalvarTipoVeiculo(int? id)
        {
            List<TipoVeiculo> listaTipoVeiculos = new List<TipoVeiculo>();
            TipoVeiculoViewsModels tipoVeiculoViewsModels = new TipoVeiculoViewsModels();

            if (id != null)
            {
                listaTipoVeiculos = _veiculoRepository.ListarTipoVeiculos(id);

                foreach(var tipoveiculo in listaTipoVeiculos)
                {
                    tipoVeiculoViewsModels.TipoVeiculoId = tipoveiculo.TipoVeiculoId;
                    tipoVeiculoViewsModels.Nome = tipoveiculo.Nome;
                    tipoVeiculoViewsModels.Status = tipoveiculo.Status;
                }

            }
            else
            {
                tipoVeiculoViewsModels.Status = 1;
            }
            
            return View(tipoVeiculoViewsModels); 
        }

        [HttpPost]
        public IActionResult SalvarTipoVeiculo(TipoVeiculoViewsModels tipoVeiculoViewsModels)
        {
            var _tipoVeiculo = new TipoVeiculo();
            _tipoVeiculo.TipoVeiculoId = tipoVeiculoViewsModels.TipoVeiculoId;
            _tipoVeiculo.Nome = tipoVeiculoViewsModels.Nome;
            _tipoVeiculo.Status = tipoVeiculoViewsModels.Status;


            if (!String.IsNullOrEmpty(tipoVeiculoViewsModels.Nome))
            {
                if (tipoVeiculoViewsModels.TipoVeiculoId == 0)
                {
                    _veiculoRepository.SalvarTipoVeiculo(_tipoVeiculo);
                    ViewBag.Aviso = "Cadastrado com Sucesso!! ";
                }
                else
                {
                    _veiculoRepository.EditarTipoVeiculo(_tipoVeiculo);
                    ViewBag.Aviso = "Alterdo com Sucesso!! ";
                }

            }

            return View(tipoVeiculoViewsModels);

        }

        //ConsultaOperacaoVeiculo
        [HttpGet]
        public IActionResult ConsultaOperacaoVeiculo()
        {
            var tipoOperacaoVeiculos = _veiculoRepository.ListarOperacaoVeiculos(0);
            return View(tipoOperacaoVeiculos);
        }

        [HttpGet]
        public IActionResult SalvarOperacaoVeiculo(int? id)
        {
            List<OperacaoVeiculo> listaOperacaoVeiculo = new List<OperacaoVeiculo>();
            OperacaoVeiculoViewsModels operacaoVeiculoViewsModels = new OperacaoVeiculoViewsModels();


            if (id != null)
            {
                listaOperacaoVeiculo = _veiculoRepository.ListarOperacaoVeiculos(id);
                foreach (var operacao in listaOperacaoVeiculo)
                {
                    operacaoVeiculoViewsModels.OperacaoVeiculoId = operacao.OperacaoVeiculoId;
                    operacaoVeiculoViewsModels.Nome = operacao.Nome;
                    operacaoVeiculoViewsModels.Status = operacao.Status;
                }
            }
            else
            {
                operacaoVeiculoViewsModels.Status = 1;
            }

            return View(operacaoVeiculoViewsModels);
        }

        [HttpPost]
        public IActionResult SalvarOperacaoVeiculo(OperacaoVeiculoViewsModels operacaoVeiculoViewsModels)
        {
            var _operacaoVeiculo = new OperacaoVeiculo();
            _operacaoVeiculo.OperacaoVeiculoId = operacaoVeiculoViewsModels.OperacaoVeiculoId;
            _operacaoVeiculo.Nome = operacaoVeiculoViewsModels.Nome;
            _operacaoVeiculo.Status = operacaoVeiculoViewsModels.Status;


            if (!String.IsNullOrEmpty(operacaoVeiculoViewsModels.Nome))
            {
                if (operacaoVeiculoViewsModels.OperacaoVeiculoId == 0)
                {
                    _veiculoRepository.SalvarOperacaoVeiculo(_operacaoVeiculo);
                    ViewBag.Aviso = "Cadastrado com Sucesso!! ";
                }
                else
                {
                    _veiculoRepository.EditarOperacaoVeiculo(_operacaoVeiculo);
                    ViewBag.Aviso = "Alterdo com Sucesso!! ";
                }

            }

            return View(operacaoVeiculoViewsModels);

        }

        //Veiculos
        [HttpGet]
        public IActionResult Salvar(int? id)
        {
            List<VeiculoViewsModels> veiculos = new List<VeiculoViewsModels>();
            VeiculoViewsModels veiculoModel = new VeiculoViewsModels();

            if (id != null)
            {
                veiculos = _veiculoRepository.ListarVeiculos(id);

                foreach (var veiculo in veiculos)
                {
                    veiculoModel.VeiculoId = veiculo.VeiculoId;
                    veiculoModel.Placa = veiculo.Placa;
                    veiculoModel.NomeModelo = veiculo.NomeModelo;
                    veiculoModel.TipoVeiculoId = veiculo.TipoVeiculoId;
                    veiculoModel.OperacaoVeiculoId = veiculo.OperacaoVeiculoId;
                    veiculoModel.Status = veiculo.Status;
                    veiculoModel.CategoriaIdEixoSuspenso = veiculo.CategoriaIdEixoSuspenso;
                    veiculoModel.CategoriaIdEixoAbaixado = veiculo.CategoriaIdEixoAbaixado;
                }

            }
            else
            {
                veiculoModel.Status = 1;
            }

            ViewBag.TipoVeiculo = _veiculoRepository.ListarTipoVeiculos(0);
            ViewBag.OperacaoVeiculo = _veiculoRepository.ListarOperacaoVeiculos(0);
            ViewBag.CategoriaEixoSuspenso = _veiculoRepository.ListarCategoriVeiculo(0);
            ViewBag.CategoriaEixoAbaixado = _veiculoRepository.ListarCategoriVeiculo(0);

            return View(veiculoModel);
        }

        [HttpPost]
        public IActionResult Salvar(VeiculoViewsModels veiculoModel)
        {
            var _veiculo = new Veiculos();
            _veiculo.VeiculoId = veiculoModel.VeiculoId;
            _veiculo.Placa = veiculoModel.Placa;
            _veiculo.NomeModelo = veiculoModel.NomeModelo;
            _veiculo.DataCad = DateTime.Today;
            _veiculo.TipoVeiculoId = veiculoModel.TipoVeiculoId;
            _veiculo.OperacaoVeiculoId = veiculoModel.OperacaoVeiculoId;
            _veiculo.Status = veiculoModel.Status;
            _veiculo.CategoriaIdEixoSuspenso = veiculoModel.CategoriaIdEixoSuspenso;
            _veiculo.CategoriaIdEixoAbaixado = veiculoModel.CategoriaIdEixoAbaixado;


            if ( !String.IsNullOrEmpty(_veiculo.Placa) && !String.IsNullOrEmpty(_veiculo.NomeModelo))
            {

                try
                {
                    if (veiculoModel.VeiculoId == 0)
                    {

                        _veiculoRepository.SalvarVeiculo(_veiculo);
                        ViewBag.Aviso = " Veiculo Cadastrado com Sucesso!! ";
                    }
                    else
                    {
                        _veiculoRepository.EditarVeiculo(_veiculo);
                        ViewBag.Aviso = " Veiculo Alterado com Sucesso!! ";

                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Aviso = ex.Message;
                }

            }

            //ViewBag.TipoVeiculo = _veiculoRepository.ListarTipoVeiculos(0);
            //ViewBag.OperacaoVeiculo = _veiculoRepository.ListarOperacaoVeiculos(0);

            return Redirect("Consulta"); 

        }


               
    }
}
