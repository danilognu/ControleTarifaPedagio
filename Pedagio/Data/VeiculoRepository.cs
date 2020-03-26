using System.Collections.Generic;
using System.Linq;
using Pedagio.Data.Entities;
using Pedagio.Data;
using Pedagio.ViewsModels;

namespace Pedagio.Data
{
    public class VeiculoRepository: IVeiculoRepository
    {

        private readonly ApplicationDbContext _context;

        public VeiculoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<VeiculoViewsModels> ListarVeiculos(int? id)
        {

            var _ssQuery = from v in _context.Veiculos
                           join t in _context.TipoVeiculos on v.TipoVeiculoId equals t.TipoVeiculoId
                           join op in _context.OperacaoVeiculos on v.OperacaoVeiculoId equals op.OperacaoVeiculoId
                           select new
                           {
                               VeiculoId = v.VeiculoId,
                               Placa = v.Placa,
                               NomeModelo = v.NomeModelo,
                               Tipoveiculo = t.Nome,
                               Operacao = op.Nome,
                               TipoVeiculoId = t.TipoVeiculoId,
                               OperacaoVeiculoId = op.OperacaoVeiculoId,
                               Status = v.Status,
                               CategoriaIdEixoAbaixado = v.CategoriaIdEixoAbaixado,
                               CategoriaIdEixoSuspenso = v.CategoriaIdEixoSuspenso
                           };

            if (id > 0)
            {
                _ssQuery = _ssQuery.Where(v => v.VeiculoId == id);
            }


            List<VeiculoViewsModels> veiculos = new List<VeiculoViewsModels>();

            foreach(var result in _ssQuery)
            {
                veiculos.Add(new VeiculoViewsModels()
                {
                    VeiculoId = result.VeiculoId,
                    Placa = result.Placa,
                    NomeModelo = result.NomeModelo,
                    TipoVeiculoNome = result.Tipoveiculo,
                    OperacaoVeiculoNome = result.Operacao,
                    TipoVeiculoId = result.TipoVeiculoId,
                    OperacaoVeiculoId = result.OperacaoVeiculoId,
                    Status = result.Status,
                    CategoriaIdEixoAbaixado = result.CategoriaIdEixoAbaixado,
                    CategoriaIdEixoSuspenso = result.CategoriaIdEixoSuspenso
                });
            }

            return veiculos;

        }

        public void SalvarVeiculo(Veiculos veiculos)
        {
            _context.Veiculos.Add(veiculos);
            _context.SaveChanges();
        }

        public void EditarVeiculo(Veiculos veiculos)
        {
            _context.Veiculos.Update(veiculos);
            _context.SaveChangesAsync();

        }

        public List<TipoVeiculo> ListarTipoVeiculos(int? id)
        {

            var sQuery = from tp in _context.TipoVeiculos
                         select tp;

            if (id > 0)
            {
                sQuery = sQuery.Where(b => b.TipoVeiculoId == id);
            }

            List<TipoVeiculo> listaTipoveiculo = new List<TipoVeiculo>();

            foreach(var result in sQuery)
            {
                listaTipoveiculo.Add(new TipoVeiculo()
                {
                    TipoVeiculoId = result.TipoVeiculoId,
                    Nome = result.Nome,
                    Status = result.Status
                });
            }

            return listaTipoveiculo.ToList();

        }

        public List<OperacaoVeiculo> ListarOperacaoVeiculos(int? id)
        {
            var sQuery = from op in _context.OperacaoVeiculos
                         select op;

            if(id > 0)
            {
                sQuery = sQuery.Where(b => b.OperacaoVeiculoId == id);
            }

            List<OperacaoVeiculo> listaOperacaoVeiculos = new List<OperacaoVeiculo>();

            foreach(var result in sQuery)
            {
                listaOperacaoVeiculos.Add(new OperacaoVeiculo()
                {
                    OperacaoVeiculoId = result.OperacaoVeiculoId,
                    Nome = result.Nome,
                    Status = result.Status
                });
            }

            return listaOperacaoVeiculos.ToList();

        }

        public List<CategoriaVeiculo> ListarCategoriVeiculo(int? id)
        {
            var sQuery = from cat in _context.CategoriaVeiculos
                         select cat;

            List<CategoriaVeiculo> listCategoriaVeiculos = new List<CategoriaVeiculo>();

            foreach(var result in sQuery)
            {
                listCategoriaVeiculos.Add(new CategoriaVeiculo()
                {
                    CategoriaId = result.CategoriaId,
                    Numero = result.Numero,
                    Descricao = result.Descricao
                });
            }

            return listCategoriaVeiculos.ToList();

        }

        public void SalvarTipoVeiculo(TipoVeiculo tipoVeiculo)
        {
            _context.TipoVeiculos.Add(tipoVeiculo);
            _context.SaveChanges();
        }

        public void EditarTipoVeiculo(TipoVeiculo tipoVeiculo)
        {
            _context.TipoVeiculos.Update(tipoVeiculo);
            _context.SaveChangesAsync();
        }

        public void SalvarOperacaoVeiculo(OperacaoVeiculo operacaoVeiculo)
        {
            _context.OperacaoVeiculos.Add(operacaoVeiculo);
            _context.SaveChanges();
        }

        public void EditarOperacaoVeiculo(OperacaoVeiculo operacaoVeiculo)
        {
            _context.OperacaoVeiculos.Update(operacaoVeiculo);
            _context.SaveChangesAsync();
        }

    }
}
