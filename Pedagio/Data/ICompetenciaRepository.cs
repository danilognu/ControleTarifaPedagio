using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pedagio.Data.Entities;
using Pedagio.ViewsModels;

namespace Pedagio.Data
{
    public interface ICompetenciaRepository
    {
        void SalvarArquivoImportado(ArquivosImportados arquivoImportado);
        void SalvarPassagensPedagio(PassagensPedagio passagensPedagio);
        void SalvarPassagensValePedagio(PassagensValePedagio passagensValePedagio);
        void SalvarCreditos(Creditos creditos);
        ArquivosImportados GetArquivoImportadoId(string nomeArquivo);
        List<ArquivoImportadoViewsModels> ListarArquivosImportados();
        void GerarContabilizacao(int id);
        List<ContabilizaDesvio> ListarContabilizaDesvio(int id);
        List<ContabilizaDesvio> ConferenciaFiltroLista(string dataInicio, string dataFim, string placa, string viagem);
        List<PassagensPedagio> PassagensPedagioLista();
        List<PassagensValePedagio> PassagensValePedagioLista();
        List<Creditos> CreditosLista(string dataInicio, string dataFim);
        void DeletarArquivosImportados(int id);
        List<Creditos> CreditosFiltroLista(string dataInicio, string dataFim, string placa, string viagem);
        List<PassagensPedagio> PassagensPedagioFiltroLista(string dataInicio, string dataFim, string placa);
        List<PassagensValePedagio> PassagensValePedagioFiltroLista(string dataInicio, string dataFim, string placa, string viagem);
    }
}
