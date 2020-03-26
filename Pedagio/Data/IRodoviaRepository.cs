
using Pedagio.Data.Entities;
using System.Collections.Generic;
using Pedagio.ViewsModels;

namespace Pedagio.Data
{
    public interface IRodoviaRepository
    {
        //void SalvarArquivoImportado();
        List<Rodovia> RodoviaListar();
        List<RodoviasTarifas> RodoviasTarifasListar();
        List<RodoviaTarifasOperadoras> RodoviasTarifaOperadorasListar();
        void SalvarRodovia(Rodovia rodovia);
        void EditarRodovia(Rodovia rodovia);
        void SalvarRodoviaTarifa(RodoviasTarifas rodoviasTarifas);
        void SalvarRodoviaTarifaOperadoras(RodoviaTarifasOperadoras rodoviaTarifasOperadoras);
        void SalvarStringComparacao(RodoviasTarifas rodoviasTarifas);
        void SalvarStringChaveRodoviaTarifasOperadoras(RodoviaTarifasOperadoras rodoviaTarifasOperadoras);
        List<RodoviasTarifas> RodoviasTarifasGroup();
        List<PassagensValePedagioCalculado> BuscaPassagensValePedagioChave(RodoviasTarifas rodoviasTarifas);
        void AtualizaCalculoPassagensValePedagio(PassagensValePedagioCalculado passagensValePedagioCalculado, int eixoAbaixado, int eixoSuspenso);
        List<PassagensValePedagio> PassagensValePedagiosBuscaComChave(RodoviaTarifasOperadoras rodoviaTarifasOperadoras);
        List<RodoviaTarifasOperadoras> BuscaRodoviaTarifasOperadorasChave();
        void SalvarStringVAlorEixoAbaixado(PassagensValePedagio passagensValePedagio, string strValor);
        void SalvarStringVAlorEixoSuspenso(PassagensValePedagio passagensValePedagio, string strValor);
        List<RodoviaTarifaGroupViewsModels> GetRodoviaTarifasOperadorasGroup();
        List<RodoviaTarifasOperadoras> ListaRodoviasTarifasOperadoras(RodoviaTarifaGroupViewsModels rodoviaTarifaGroupViewsModels);
        List<PassagensPedagioBuscaChaveViewsModels> BuscaTabelaPassagensPedagioComChave(RodoviaTarifasOperadoras rodoviaTarifasOperadoras);
        List<RodoviaTarifasOperadoras> BuscaValoresDasTarifasPorChave(RodoviaTarifasOperadoras rodoviaTarifasOperadoras, int Eixo);

        //gerar chave apartir da passagensPedagio
        List<PassagensPedagio> GetRodoviaPassagensPedagio();
        List<PassagensPedagio> GetPracasPassagensPedagio(string rodovia);
        void UpdateChavePassagensPedagio(PassagensPedagio passagensPedagio);
    }
}
