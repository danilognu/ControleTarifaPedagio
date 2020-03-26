using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pedagio.Data.Entities;
using Pedagio.ViewsModels;

namespace Pedagio.Data
{
    public interface IVeiculoRepository
    {
        void SalvarVeiculo(Veiculos veiculos);
        void EditarVeiculo(Veiculos veiculos);
        void SalvarTipoVeiculo(TipoVeiculo tipoVeiculo);
        void EditarTipoVeiculo(TipoVeiculo tipoVeiculo);
        void SalvarOperacaoVeiculo(OperacaoVeiculo operacaoVeiculo);
        void EditarOperacaoVeiculo(OperacaoVeiculo operacaoVeiculo);
        List<VeiculoViewsModels> ListarVeiculos(int? id);
        List<TipoVeiculo> ListarTipoVeiculos(int? id);
        List<OperacaoVeiculo> ListarOperacaoVeiculos(int? id);
        List<CategoriaVeiculo> ListarCategoriVeiculo(int? id);

        //List<TipoVeiculoViewsModels> ListarTipoVeiculo();
    }
}
