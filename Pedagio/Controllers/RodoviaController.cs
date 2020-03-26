using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pedagio.Data;
using Pedagio.Data.Entities;
using Pedagio.Dominio;
using PagedList;
using Pedagio.ViewsModels;

namespace Pedagio.Controllers
{

    public class RodoviaController : Controller
    {

        private IHostingEnvironment _appEnvironment;
        private readonly IRodoviaRepository _rodoviaRepository;

        public RodoviaController(IHostingEnvironment env, IRodoviaRepository rodoviaRepository)
        {
            _appEnvironment = env;
            _rodoviaRepository = rodoviaRepository;
        }


        [HttpGet]
        public IActionResult ListarRodovias(int? pagina)
        {

            var rodovias = _rodoviaRepository.RodoviaListar();

            int paginaTamanho = 200;
            int paginaNumero = (pagina ?? 1);

            return View(rodovias.ToPagedList(paginaNumero, paginaTamanho));
        }

        [HttpGet]
        public IActionResult SalvarRodovia(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult SalvarRodovia(RodoviaViewsModels rodoviaViewsModels)
        {
            var _rodovia = new Rodovia();
            _rodovia.RodoviaId = rodoviaViewsModels.RodoviaId;
            _rodovia.NomeRodovia = rodoviaViewsModels.NomeRodovia;

            if (!String.IsNullOrEmpty(rodoviaViewsModels.NomeRodovia))
            {
                if (rodoviaViewsModels.RodoviaId == 0)
                {
                    _rodoviaRepository.SalvarRodovia(_rodovia);
                    ViewBag.Aviso = "Cadastrado com Sucesso!! ";
                }
                else
                {
                    _rodoviaRepository.EditarRodovia(_rodovia);
                    ViewBag.Aviso = "Alterdo com Sucesso!! ";
                }
            }

            return View(rodoviaViewsModels);
        }

        [HttpGet]
        public IActionResult Importar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ListarRodoviasTarifaOperadoras(int? pagina)
        {

            var rodovias = _rodoviaRepository.RodoviasTarifaOperadorasListar();

            int paginaTamanho = 200;
            int paginaNumero = (pagina ?? 1);

            return View(rodovias.ToPagedList(paginaNumero, paginaTamanho));
        }

        [HttpGet]
        public IActionResult ListarRodoviasTarifa(int? pagina)
        {

            var rodovias = _rodoviaRepository.RodoviasTarifasListar();

            int paginaTamanho = 200;
            int paginaNumero = (pagina ?? 1);

            return View(rodovias.ToPagedList(paginaNumero, paginaTamanho));
        }

        public async Task<IActionResult> EnviarArquivo(List<IFormFile> arquivos)
        {

            ViewBag.Carregamento = "Carregando";

            var arquivoImportado = new ArquivosImportados();
            int _contagem = 0;

            long tamanhoArquivos = arquivos.Sum(f => f.Length);
            // caminho completo do arquivo na localização temporária
            var caminhoArquivo = Path.GetTempFileName();

            // processa os arquivo enviados
            //percorre a lista de arquivos selecionados
            foreach (var arquivo in arquivos)
            {
                //verifica se existem arquivos 
                if (arquivo == null || arquivo.Length == 0)
                {
                    //retorna a viewdata com erro
                    ViewData["Erro"] = "Error: Arquivo(s) não selecionado(s)";
                    return View(ViewData);
                }
                // < define a pasta onde vamos salvar os arquivos >
                string pasta = "Arquivos_Usuario";
                // Define um nome para o arquivo enviado incluindo o sufixo obtido de milesegundos
                string nomeArquivo = "RodoviaTarifasOp_" + DateTime.Now.Millisecond.ToString();
                //verifica qual o tipo de arquivo : xlsx, xls ou tmp
                if (arquivo.FileName.Contains(".xlsx"))
                    nomeArquivo += ".xlsx";
                else if (arquivo.FileName.Contains(".xls"))
                    nomeArquivo += ".xls";
                else
                    nomeArquivo += ".tmp";
                //< obtém o caminho físico da pasta wwwroot >
                string caminho_WebRoot = _appEnvironment.WebRootPath;
                // monta o caminho onde vamos salvar o arquivo : 
                // ~\wwwroot\Arquivos\Arquivos_Usuario\Recebidos
                string caminhoDestinoArquivo = caminho_WebRoot + "\\" + pasta + "\\";
                // incluir a pasta Recebidos e o nome do arquivo enviado : 
                // ~\wwwroot\Arquivos\Arquivos_Usuario\Recebidos\
                string caminhoDestinoArquivoOriginal = caminhoDestinoArquivo + "\\Recebidos\\" + nomeArquivo;
                string caminhoArquivoServ = caminhoDestinoArquivo + "\\Recebidos\\";
                //copia o arquivo para o local de destino original
                using (var stream = new FileStream(caminhoDestinoArquivoOriginal, FileMode.Create))
                {
                    await arquivo.CopyToAsync(stream);
                }

                arquivoImportado.NomeOrigem = arquivo.FileName;
                arquivoImportado.NomeGerado = nomeArquivo;
                arquivoImportado.PastaImportacao = caminhoArquivoServ;
                arquivoImportado.DataImportacao = DateTime.Today;
                arquivoImportado.PessoaIdCad = 1;
                arquivoImportado.PessoaIdEmp = 1;

                _contagem++;
            }

            RodoviaDominio rodoviaDominio = new RodoviaDominio();

            //SALVA TABELA RODOVIA TARIFA FOI DESATIVADO POIS O CLIENTE NÃO SABE OQUE QUER
            /*List<Rodovia> listaRodovias = _rodoviaRepository.RodoviaListar();

            foreach (Rodovia rodovia in listaRodovias)
            {

                List<RodoviasTarifas> listaRodoviasTarifas = new List<RodoviasTarifas>();
                listaRodoviasTarifas = rodoviaDominio.LerExcelRodovia(arquivoImportado, rodovia);

                foreach (RodoviasTarifas rodoviasTarifa in listaRodoviasTarifas)
                {
                    _rodoviaRepository.SalvarRodoviaTarifa(rodoviasTarifa);
                }
            }*/

            List<RodoviaTarifasOperadoras> listaRodoviaTarifasOperadoras = new List<RodoviaTarifasOperadoras>();
            listaRodoviaTarifasOperadoras = rodoviaDominio.LerExcelRodoviaTarifasOperadoras(arquivoImportado);

            foreach (RodoviaTarifasOperadoras rodoviaTarifasOperadoras in listaRodoviaTarifasOperadoras)
            {
                _rodoviaRepository.SalvarRodoviaTarifaOperadoras(rodoviaTarifasOperadoras);
            }
            
            //return Redirect("ListarRodoviasTarifa");
            return Redirect("ListarRodoviasTarifaOperadoras");

        }

        [HttpGet]
        public IActionResult GerarStringComparacao()
        {
            RodoviaDominio rodoviaDominio = new RodoviaDominio();

            List<PassagensPedagio> listaPassagensPedagiosGroupRodovia = new List<PassagensPedagio>();
            listaPassagensPedagiosGroupRodovia = _rodoviaRepository.GetRodoviaPassagensPedagio();
            foreach(PassagensPedagio itemRodvia in listaPassagensPedagiosGroupRodovia)
            {

                List<PassagensPedagio> listaPraca = new List<PassagensPedagio>();
                listaPraca = _rodoviaRepository.GetPracasPassagensPedagio(itemRodvia.Rodovia);
                foreach(PassagensPedagio itemPraca in listaPraca)
                {

                    //Verifica Chave Um
                    var MontaChaveUm = new ChaveBuscaViewsModels();
                    MontaChaveUm = rodoviaDominio.MontaChaveUm(itemPraca.Praca);
                    if (MontaChaveUm.Valida)
                    {
                        //Chave é valida
                        AtualizaPassagensPedagio(MontaChaveUm, itemPraca.PassagemPedagioId);

                    }
                    if (!MontaChaveUm.Valida)
                    {

                        var MontaChaveDois = new ChaveBuscaViewsModels();
                        MontaChaveDois = rodoviaDominio.MontaChaveDois(itemPraca.Praca);
                        if (MontaChaveDois.Valida)
                            AtualizaPassagensPedagio(MontaChaveDois, itemPraca.PassagemPedagioId);

                    }
                }

            }



            return View();

        }

        public void AtualizaPassagensPedagio(ChaveBuscaViewsModels chave, int id)
        {
            PassagensPedagio passagemChaveUm = new PassagensPedagio();
            passagemChaveUm.PassagemPedagioId = id;
            passagemChaveUm.OpRodoviaChave = chave.Rodovia;
            passagemChaveUm.KmChave = chave.Km;
            passagemChaveUm.SentidoChave = chave.Sentido;
            passagemChaveUm.CidadeChave = chave.Cidade;
            passagemChaveUm.EstadoChave = chave.Estado;
            _rodoviaRepository.UpdateChavePassagensPedagio(passagemChaveUm);
        }

       /* [HttpGet]
        public IActionResult GerarStringComparacao()
        {

            //Busca Rodovias Agupadas e verifica se existe na validação pedagio
            List<RodoviaTarifaGroupViewsModels> listaRodoviaTarifaGroup = new List<RodoviaTarifaGroupViewsModels>();
            listaRodoviaTarifaGroup = _rodoviaRepository.GetRodoviaTarifasOperadorasGroup();
            foreach (RodoviaTarifaGroupViewsModels rodoviaTarifaGroup in listaRodoviaTarifaGroup)
            {
                if(rodoviaTarifaGroup.ExisteRodovia > 0)
                {
                    //Busca todas as Tarifas da Rodovia corrente gerando chave de busca na tabela de vale pegadio
                    List<RodoviaTarifasOperadoras> listaTarifaDaRodovia = new List<RodoviaTarifasOperadoras>();
                    listaTarifaDaRodovia = _rodoviaRepository.ListaRodoviasTarifasOperadoras(rodoviaTarifaGroup);

                    foreach (RodoviaTarifasOperadoras rodoviaTarifasOperadoras in listaTarifaDaRodovia)
                    {
                        //Busca pela Chave Gerada na Tabela de PassagensPedagio para a comparação de valores posterior 
                        List<PassagensPedagioBuscaChaveViewsModels>  listaPedagioBuscaChaveViewsModels = new List<PassagensPedagioBuscaChaveViewsModels>();
                        listaPedagioBuscaChaveViewsModels = _rodoviaRepository.BuscaTabelaPassagensPedagioComChave(rodoviaTarifasOperadoras);

                        foreach (PassagensPedagioBuscaChaveViewsModels pasPedaBuscaChaveV in listaPedagioBuscaChaveViewsModels)
                        {
                            //Busca pela Chave na tabela de Tarifa trazendo os valores de todas as tarifas para a comparação
                            List<RodoviaTarifasOperadoras> listTarifaValor = new List<RodoviaTarifasOperadoras>();
                            listTarifaValor = _rodoviaRepository.BuscaValoresDasTarifasPorChave(rodoviaTarifasOperadoras, pasPedaBuscaChaveV.EixoAbaixado);

                            int _contMaior, _contMenor, _contIgual;
                            _contMaior = 1;
                            _contMenor = 2;
                            _contIgual = 3;

                            foreach (RodoviaTarifasOperadoras itemValor in listTarifaValor)
                            {
                                if(pasPedaBuscaChaveV.Valor < itemValor.Tarifa)
                                {
                                    _contMaior++;
                                }
                                else if(pasPedaBuscaChaveV.Valor > itemValor.Tarifa)
                                {
                                    _contMenor++;
                                }
                                else if (pasPedaBuscaChaveV.Valor == itemValor.Tarifa)
                                {
                                    _contIgual++;
                                }
                            }

                            string TextTarifa = "";
                            if(_contIgual > 1)
                            {
                                TextTarifa = "IGUAL";
                            }
                            else
                            {
                                if (_contMenor > 1)
                                {
                                    TextTarifa = "MENOR";
                                }
                                else if (_contMenor > _contMaior && _contMenor > 1)
                                {
                                    TextTarifa = "MAIOR";
                                }
                            }


                        }


                    }



                }
            }

            return View();

        } */


        //[HttpGet]
        //public IActionResult GerarStringComparacao()
        //{
        //RodoviaDominio rodoviaDominio = new RodoviaDominio();
        /*
         * CRIADO UMA NOVA IMPORTAÇÃO POIS FOI ENVIADO UM NOVO LAYOUT 
        */
        /* List<RodoviaTarifasOperadoras> listaRodoviaTarifasOperadorasSave = new List<RodoviaTarifasOperadoras>();
         List<RodoviaTarifasOperadoras> listaRodoviaTarifasOperadoras = new List<RodoviaTarifasOperadoras>();
         listaRodoviaTarifasOperadoras = _rodoviaRepository.RodoviasTarifaOperadorasListar();

         foreach (RodoviaTarifasOperadoras rodoviaTarifasOperadoras in listaRodoviaTarifasOperadoras)
         {
             var rodoviaTarifasOperadorasViewsModels = new RodoviaTarifasOperadorasViewsModels();
             rodoviaTarifasOperadorasViewsModels = rodoviaDominio.GerarStringChaveRodoviasTarifasOp(rodoviaTarifasOperadoras);

             //Gera Lista Com Chave
             listaRodoviaTarifasOperadorasSave.Add(new RodoviaTarifasOperadoras()
             {
                 RodoviaTarifasOperadorasId = rodoviaTarifasOperadoras.RodoviaTarifasOperadorasId,
                 Km = rodoviaTarifasOperadorasViewsModels.Km,
                 Cidade = rodoviaTarifasOperadorasViewsModels.Cidade,
                 Rodovia = rodoviaTarifasOperadorasViewsModels.Rodovia,
                 Eixo = rodoviaTarifasOperadorasViewsModels.Eixo
             });

         }

         foreach (RodoviaTarifasOperadoras rodoviaTarifasOperadoras in listaRodoviaTarifasOperadorasSave)
         {
             try
             {
                 _rodoviaRepository.SalvarStringChaveRodoviaTarifasOperadoras(rodoviaTarifasOperadoras);
             }
             catch (IOException e)
             {
                 @ViewBag.Messagem = e.Message;
             }

         }*/

        /*DAQUI PARA BAIXO NAO UTILIZAR POR HORA SOMENTE O DE CIMA QUE GERA A GRAVES DAS CIDADES*/


        /*List<RodoviaTarifasOperadoras> listaRodoviaTarifasOperadorasCheve = new List<RodoviaTarifasOperadoras>();
        listaRodoviaTarifasOperadorasCheve = _rodoviaRepository.BuscaRodoviaTarifasOperadorasChave();

        foreach (RodoviaTarifasOperadoras rodoviaTarifasOperadoras in listaRodoviaTarifasOperadorasCheve)
        {

            List<PassagensValePedagio> listaChavepassagensValePedagios = new List<PassagensValePedagio>();
            listaChavepassagensValePedagios  = _rodoviaRepository.PassagensValePedagiosBuscaComChave(rodoviaTarifasOperadoras);

            foreach(PassagensValePedagio passagensValePedagio in listaChavepassagensValePedagios)
            {
                string cidade = rodoviaTarifasOperadoras.Cidade;
                int idR = rodoviaTarifasOperadoras.RodoviaTarifasOperadorasId;
                int idP = passagensValePedagio.PassagemValePedagioId;
                string _textoValor = "";
                if(passagensValePedagio.Valor < rodoviaTarifasOperadoras.Tarifa)
                {
                    _textoValor = "MENOR";
                }
                if (passagensValePedagio.Valor > rodoviaTarifasOperadoras.Tarifa)
                {
                    _textoValor = "MAIOR";
                }
                if (passagensValePedagio.Valor == rodoviaTarifasOperadoras.Tarifa)
                {
                    _textoValor = "IGAUAL";
                }

                if(rodoviaTarifasOperadoras.Eixo == passagensValePedagio.EixoAbaixado)
                {
                    _rodoviaRepository.SalvarStringVAlorEixoAbaixado(passagensValePedagio, _textoValor);
                }
                else
                {
                    _rodoviaRepository.SalvarStringVAlorEixoSuspenso(passagensValePedagio, _textoValor);
                }



            }
        }*/




        //PEGA TODAS AS CHAVES DAS TARIFAS
        /*List<RodoviasTarifas> listaRodoviasTarifasGroup = _rodoviaRepository.RodoviasTarifasGroup();

        foreach (var itemChave in listaRodoviasTarifasGroup)
        {
            listaPassagensValePedagiosChave = _rodoviaRepository.BuscaPassagensValePedagioChave(itemChave);

            int eixoAbaixado = 0;
            int eixoSuspenso = 0;

            //GERA COMPARAÇÃO DE VALOR ENTRE TABELA DE TARIFAS E PASSAGENS VALE PEDAGIO
            foreach (var itemCalculado in listaPassagensValePedagiosChave)
            {
                string ValorTarifaEixoAbaixadoStr = itemCalculado.ValorTarifaEixoAbaixado;
                ValorTarifaEixoAbaixadoStr = ValorTarifaEixoAbaixadoStr.Replace('.', ',');
                decimal ValorTarifaEixoAbaixadoDec = Convert.ToDecimal(ValorTarifaEixoAbaixadoStr);

                string ValorTarifaEixoSuspensoStr = itemCalculado.ValorTarifaEixoSuspenso;
                ValorTarifaEixoSuspensoStr = ValorTarifaEixoSuspensoStr.Replace('.', ',');
                decimal ValorTarifaEixoSuspensoDec = Convert.ToDecimal(ValorTarifaEixoSuspensoStr);

                if (itemCalculado.Valor == ValorTarifaEixoAbaixadoDec)
                {
                    eixoAbaixado = 1;
                }

                if (itemCalculado.Valor == ValorTarifaEixoSuspensoDec)
                {
                    eixoSuspenso = 1;
                }

                _rodoviaRepository.AtualizaCalculoPassagensValePedagio(itemCalculado, eixoAbaixado, eixoSuspenso);

                eixoAbaixado = 0;
                eixoSuspenso = 0;
            }

        }*/



        /*
            * NÃO APAGAR GERA A CHAVE
            *
        */

        /*List<RodoviasTarifas> listaRodoviasTarifasSave = new List<RodoviasTarifas>();

        //Lista Rodovias
        List<RodoviasTarifas> listaRodoviasTarifas = new List<RodoviasTarifas>();
        listaRodoviasTarifas = _rodoviaRepository.RodoviasTarifasListar();

        foreach (RodoviasTarifas rodoviasTarifa in listaRodoviasTarifas)
        {
            //Gera a Chave
            var rodoviasTfViewsModels = new RodoviasTarifasViewsModels();
            rodoviasTfViewsModels = rodoviaDominio.GerarStringComparacao(rodoviasTarifa);

            //Gera Lista Com Chave
            listaRodoviasTarifasSave.Add(new RodoviasTarifas(){
                RodoviaTarifaId = rodoviasTarifa.RodoviaTarifaId,
                Km = rodoviasTfViewsModels.Km,
                Cidade = rodoviasTfViewsModels.Cidade,
                Rodovia = rodoviasTfViewsModels.Rodovia
            });

        }
        @ViewBag.Messagem = "Carregando..";

        //Grava Chave
        foreach (RodoviasTarifas rodoviasTarifa in listaRodoviasTarifasSave)
        {
            try
            {                    
                _rodoviaRepository.SalvarStringComparacao(rodoviasTarifa);
            }
            catch (IOException e)
            {
                @ViewBag.Messagem = e.Message;
            }

        }*/


        /*   List<PassagensValePedagioCalculado> listaPassagensValePedagiosChave = new List<PassagensValePedagioCalculado>();

           //PEGA TODAS AS CHAVES DAS TARIFAS
           List<RodoviasTarifas> listaRodoviasTarifasGroup = _rodoviaRepository.RodoviasTarifasGroup();

           foreach (var itemChave in listaRodoviasTarifasGroup)
           {
               listaPassagensValePedagiosChave = _rodoviaRepository.BuscaPassagensValePedagioChave(itemChave);

               int eixoAbaixado = 0;
               int eixoSuspenso = 0;

               //GERA COMPARAÇÃO DE VALOR ENTRE TABELA DE TARIFAS E PASSAGENS VALE PEDAGIO
               foreach (var itemCalculado in listaPassagensValePedagiosChave)
               {
                   string ValorTarifaEixoAbaixadoStr = itemCalculado.ValorTarifaEixoAbaixado;
                   ValorTarifaEixoAbaixadoStr = ValorTarifaEixoAbaixadoStr.Replace('.', ',');
                   decimal ValorTarifaEixoAbaixadoDec = Convert.ToDecimal(ValorTarifaEixoAbaixadoStr);

                   string ValorTarifaEixoSuspensoStr = itemCalculado.ValorTarifaEixoSuspenso;
                   ValorTarifaEixoSuspensoStr = ValorTarifaEixoSuspensoStr.Replace('.', ',');
                   decimal ValorTarifaEixoSuspensoDec = Convert.ToDecimal(ValorTarifaEixoSuspensoStr);

                   if (itemCalculado.Valor == ValorTarifaEixoAbaixadoDec)
                   {
                       eixoAbaixado = 1;
                   }

                   if (itemCalculado.Valor == ValorTarifaEixoSuspensoDec)
                   {
                       eixoSuspenso = 1;
                   }

                   _rodoviaRepository.AtualizaCalculoPassagensValePedagio(itemCalculado, eixoAbaixado, eixoSuspenso);

                   eixoAbaixado = 0;
                   eixoSuspenso = 0;
               }

           }        */


        //    return View();
        // }

    }

    
}
