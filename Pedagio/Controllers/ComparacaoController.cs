using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pedagio.Data.Entities;
using Pedagio.Data;
using Pedagio.Dominio;
using PagedList;

namespace Pedagio.Controllers
{
    public class ComparacaoController : Controller
    {

        private IHostingEnvironment _appEnvironment;
        private readonly ICompetenciaRepository _competenciaRepository;

        public ComparacaoController(IHostingEnvironment env, ICompetenciaRepository competenciaRepository)
        {
            _appEnvironment = env;
            _competenciaRepository = competenciaRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult teste()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CompararExcel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CompararExcelLista()
        {
            var arquivosImportados = _competenciaRepository.ListarArquivosImportados();
            return View(arquivosImportados);
        }


        public IActionResult ConferenciaLista(int id)
        {
            var conferenciaLista = _competenciaRepository.ListarContabilizaDesvio(id);
            return View(conferenciaLista);
        }

        [HttpPost]
        public IActionResult ConferenciaFiltroLista(string dataInicio, string dataFim, string placa, string viagem)
        {

            var conferenciaLista = _competenciaRepository.ConferenciaFiltroLista(dataInicio, dataFim, placa, viagem);
            return View("ConferenciaLista", conferenciaLista);
        }

        [HttpPost]
        public IActionResult CreditosFiltroLista(string dataInicio, string dataFim, string placa, string viagem)
        {
            var creditosLista = _competenciaRepository.CreditosFiltroLista(dataInicio, dataFim, placa, viagem);
            return View("CreditosLista", creditosLista);
        }
               
        [HttpPost]
        public IActionResult PassagensPedagioFiltroLista(string dataInicio, string dataFim, string placa)
        {
            var passagensPedagioLista = _competenciaRepository.PassagensPedagioFiltroLista(dataInicio, dataFim, placa);
            return View("PassagensPedagioLista", passagensPedagioLista);
        }

        [HttpPost]
        public IActionResult PassagensValePedagioFiltroLista(string dataInicio, string dataFim, string placa, string viagem)
        {
            var passagensValePegadioLista = _competenciaRepository.PassagensValePedagioFiltroLista(dataInicio, dataFim, placa, viagem);
            return View("PassagensValePedagioLista", passagensValePegadioLista);
        }

        public IActionResult PassagensPedagioLista()
        {
            var passagensPegadio = _competenciaRepository.PassagensPedagioLista();
            return View(passagensPegadio);
        }

        public IActionResult PassagensValePedagioLista(int? pagina)
        {
            var passagensValePedagio = _competenciaRepository.PassagensValePedagioLista();

            int paginaTamanho = 200;
            int paginaNumero = (pagina ?? 1);

            return View(passagensValePedagio.ToPagedList(paginaNumero, paginaTamanho));
        }

        public IActionResult CreditosLista(int? pagina)
        {
            var creditos = _competenciaRepository.CreditosLista("","");

            int paginaTamanho = 200;
            int paginaNumero = (pagina ?? 1);

            return View(creditos.ToPagedList(paginaNumero, paginaTamanho));
        }

        [HttpPost]
        public IActionResult CreditosLista(int? pagina, string dataInicio, string dataFim)
        {
            var creditos = _competenciaRepository.CreditosLista("", "");
            return View(creditos);
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
                string nomeArquivo = "Passagens_" + DateTime.Now.Millisecond.ToString();
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

                //Salva arquivo
                _competenciaRepository.SalvarArquivoImportado(arquivoImportado);
                //Busca Id arquivo
                arquivoImportado = _competenciaRepository.GetArquivoImportadoId(arquivoImportado.NomeGerado);

                _contagem++;
            }

            List<Passagem> listaPassagens = new List<Passagem>();
            CompararArquivo compararArquivo = new CompararArquivo();
            //listaPassagens = compararArquivo.CompararArquivos(comparacaoArquivos);



            //PassagensPedagio
            List<PassagensPedagio> listaPassagensPedagio = new List<PassagensPedagio>();
            listaPassagensPedagio = compararArquivo.LerAbaPassagensPedagio(arquivoImportado);

            foreach (PassagensPedagio passagensPedagio in listaPassagensPedagio)
            {
                _competenciaRepository.SalvarPassagensPedagio(passagensPedagio);
            }

            //PassagensValePedagio
            List<PassagensValePedagio> listaPassagensValePedagios = new List<PassagensValePedagio>();
            listaPassagensValePedagios = compararArquivo.LerAbaPassagensValePedagio(arquivoImportado);

            foreach (PassagensValePedagio passagemValePedagio in listaPassagensValePedagios)
            {
                _competenciaRepository.SalvarPassagensValePedagio(passagemValePedagio);
            }

            //Creditos
            List<Creditos> listaCreditos = new List<Creditos>();
            listaCreditos = compararArquivo.LerAbaCreditos(arquivoImportado);

            foreach (Creditos credito in listaCreditos)
            {
                _competenciaRepository.SalvarCreditos(credito);
            }

            return Redirect("CompararExcelLista");
        }

        public IActionResult GerarContabilizacao(int id)
        {
            ViewBag.Carregamento = "<img src='~/images/loader.gif' /> <br />";

            //Gera Conferencia do Desviso e Salva do Banco
            _competenciaRepository.GerarContabilizacao(id);

            //Lista Conferencia ja cadastrada
            var conferenciaLista = _competenciaRepository.ListarContabilizaDesvio(id);

            return View("ConferenciaLista", conferenciaLista);
        }

        [HttpGet]
        public IActionResult ExluirContabilizacao(int id)
        {
            _competenciaRepository.DeletarArquivosImportados(id);
            return Redirect("CompararExcelLista");
        }



    }
}
