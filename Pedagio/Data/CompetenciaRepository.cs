using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pedagio.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Pedagio.ViewsModels;

namespace Pedagio.Data
{
    public class CompetenciaRepository : ICompetenciaRepository
    {
        private readonly ApplicationDbContext _context;

        public CompetenciaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SalvarPassagensPedagio(PassagensPedagio passagensPedagio)
        {
            _context.PassagensPedagios.Add(passagensPedagio);
            _context.SaveChanges();
        }

        public void SalvarPassagensValePedagio(PassagensValePedagio passagensValePedagio)
        {
            _context.PassagensValePedagios.Add(passagensValePedagio);
            _context.SaveChanges();
        }

        public void SalvarCreditos(Creditos creditos)
        {
            _context.Creditos.Add(creditos);
            _context.SaveChanges();
        }

        public void SalvarArquivoImportado(ArquivosImportados arquivoImportado)
        {
            _context.ArquivosImportados.Add(arquivoImportado);
            _context.SaveChanges();
        }

        public ArquivosImportados GetArquivoImportadoId(string nomeArquivo)
        {
            var arquivo = _context.ArquivosImportados.First(c => c.NomeGerado == nomeArquivo);
            return arquivo;
        }

        public List<ArquivoImportadoViewsModels> ListarArquivosImportados()
        {

            var sQuey = _context.ArquivosImportados;

            List<ArquivoImportadoViewsModels> arquivosImportados = new List<ArquivoImportadoViewsModels>();

            foreach(var result in sQuey)
            {
                var iQuery = _context.ContabilizaDesvio
                            .Where(b => b.ArquivoImportadoId == result.ArquivoImportadoId)
                            .ToList();

                var contaContabilizados = iQuery.Count();

                arquivosImportados.Add(new ArquivoImportadoViewsModels()
                {
                    ArquivoImportadoId = result.ArquivoImportadoId,
                    NomeOrigem = result.NomeOrigem,
                    DataImportacao = result.DataImportacao,
                    IndGerado = contaContabilizados
                });
            }


            return arquivosImportados.ToList();
        }

        public void GerarContabilizacao(int id)
        {

            decimal ValorCredito = 0;
            decimal ValorPassagemValePedagio = 0;
            decimal ValorDesvio = 0;

            var sQuery = _context.PassagensValePedagios
                        .GroupBy(o => new { o.Placa, o.Viagem })
                        .Select(g => new
                        {
                            g.Key.Placa,
                            g.Key.Viagem,
                            Soma = g.Sum(o => o.Valor)
                        });


            foreach (var resultado in sQuery)
            {

                var sQueryCredito = _context.Creditos
                                    .Where(b => b.Placa == resultado.Placa)
                                    .Where(b => b.Viagem == resultado.Viagem)
                                    .ToList();

                foreach (var resultCredito in sQueryCredito)
                {
                    if (ValorCredito > 0)
                    {
                        ValorCredito = Convert.ToDecimal(resultCredito.Valor);
                    }
                    else
                    {
                        ValorCredito = 0;
                    }
                }

                //Realiza o calculo
                ValorPassagemValePedagio = Convert.ToDecimal(resultado.Soma);
                ValorDesvio = ValorCredito - ValorPassagemValePedagio;

                ContabilizaDesvio contabilizaDesvio = new ContabilizaDesvio();
                contabilizaDesvio.Placa = resultado.Placa;
                contabilizaDesvio.Viagem = resultado.Viagem;
                contabilizaDesvio.ValorCredito = ValorCredito;
                contabilizaDesvio.ValorPassagemValePedagio = ValorPassagemValePedagio;
                contabilizaDesvio.Desvio = ValorDesvio;
                contabilizaDesvio.DataCad = DateTime.Today;
                contabilizaDesvio.ArquivoImportadoId = id;

                SalvarContabilizaDesvio(contabilizaDesvio);

            }

        }

        public void SalvarContabilizaDesvio(ContabilizaDesvio contabilizaDesvio)
        {
            _context.ContabilizaDesvio.Add(contabilizaDesvio);
            _context.SaveChanges();
        }

        public List<ContabilizaDesvio> ListarContabilizaDesvio(int id)
        {
            var sQuery = _context.ContabilizaDesvio
                         .Where(p => p.ContabilizaDesvioId > 0);


            if(id > 0)
            {
                sQuery  = sQuery.Where(p => p.ArquivoImportadoId == id);
            }
                         

            List<ContabilizaDesvio> listaContabilizaDesvios = new List<ContabilizaDesvio>();

            foreach (var resultCredito in sQuery)
            {
                               
                listaContabilizaDesvios.Add(new ContabilizaDesvio()
                {
                    Placa = resultCredito.Placa,
                    Viagem = resultCredito.Viagem,
                    ValorCredito = resultCredito.ValorCredito,
                    ValorPassagemValePedagio = resultCredito.ValorPassagemValePedagio,
                    Desvio = resultCredito.Desvio,
                    ArquivoImportadoId = resultCredito.ArquivoImportadoId,
                    DataCad = resultCredito.DataCad
                });
            }

            return listaContabilizaDesvios.ToList();

        }

        public List<ContabilizaDesvio> ConferenciaFiltroLista(string dataInicio, string dataFim, string placa, string viagem)
        {
            DateTime _dataInicio = Convert.ToDateTime(dataInicio);
            DateTime _dataFim = Convert.ToDateTime(dataFim);

            var sQuery = _context.ContabilizaDesvio
                         .Where(b => b.ContabilizaDesvioId > 0);

            DateTime dataValida;
            if (DateTime.TryParse(dataInicio,out dataValida))
            {
                sQuery = sQuery.Where(b => b.DataCad >= _dataInicio)
                               .Where(b => b.DataCad <= _dataFim);
            }

            if (placa != null)
            {
                sQuery = sQuery.Where(b => b.Placa == placa);
            }
            if(viagem != null)
            {
                sQuery = sQuery.Where(b => b.Viagem == viagem);
            }

            List<ContabilizaDesvio> listaContabilizaDesvios = new List<ContabilizaDesvio>();

            foreach (var resultCredito in sQuery)
            {
                listaContabilizaDesvios.Add(new ContabilizaDesvio()
                {
                    Placa = resultCredito.Placa,
                    Viagem = resultCredito.Viagem,
                    ValorCredito = resultCredito.ValorCredito,
                    ValorPassagemValePedagio = resultCredito.ValorPassagemValePedagio,
                    Desvio = resultCredito.Desvio,
                    ArquivoImportadoId = resultCredito.ArquivoImportadoId,
                    DataCad = resultCredito.DataCad

                });
            }


            return listaContabilizaDesvios.ToList();
        }

        public List<Creditos> CreditosFiltroLista(string dataInicio, string dataFim, string placa, string viagem)
        {
            DateTime _dataInicio = Convert.ToDateTime(dataInicio);
            DateTime _dataFim = Convert.ToDateTime(dataFim);

            var sQuery = _context.Creditos
                         .Where(b => b.CreditoId > 0);

            DateTime dataValida;
            if (DateTime.TryParse(dataInicio, out dataValida))
            {
                sQuery = sQuery.Where(b => b.Data >= _dataInicio)
                               .Where(b => b.Data <= _dataFim);
            }

            if (placa != null)
            {
                sQuery = sQuery.Where(b => b.Placa == placa);
            }
            if (viagem != null)
            {
                sQuery = sQuery.Where(b => b.Viagem == viagem);
            }

            List<Creditos> listaCreditos = new List<Creditos>();

            foreach(var resultCredito in sQuery)
            {
                listaCreditos.Add(new Creditos() {
                    CreditoId = resultCredito.CreditoId,
                    Placa = resultCredito.Placa,
                    Tag = resultCredito.Tag,
                    Data = resultCredito.Data,
                    Hora = resultCredito.Hora,
                    Descricao = resultCredito.Descricao,
                    Viagem = resultCredito.Viagem,
                    Praca = resultCredito.Praca,
                    Valor = resultCredito.Valor,
                    Embarcador = resultCredito.Embarcador,
                    Cnpj = resultCredito.Cnpj,
                    ArquivoImportadoId = resultCredito.ArquivoImportadoId
                });
            }

            return listaCreditos.ToList();

        }

        public List<PassagensPedagio> PassagensPedagioFiltroLista(string dataInicio, string dataFim, string placa)
        {
            DateTime _dataInicio = Convert.ToDateTime(dataInicio);
            DateTime _dataFim = Convert.ToDateTime(dataFim);

            var sQuery = _context.PassagensPedagios
                         .Where(b => b.PassagemPedagioId > 0);

            DateTime dataValida;
            if (DateTime.TryParse(dataInicio, out dataValida))
            {
                sQuery = sQuery.Where(b => b.Data >= _dataInicio)
                               .Where(b => b.Data <= _dataFim);
            }

            if (placa != null)
            {
                sQuery = sQuery.Where(b => b.Placa == placa);
            }

            List<PassagensPedagio> listaPassagensPedagios = new List<PassagensPedagio>();

            foreach(var resultPassagensPedagios in sQuery)
            {
                listaPassagensPedagios.Add(new PassagensPedagio() {
                    PassagemPedagioId = resultPassagensPedagios.ArquivoImportadoId,
                    Placa = resultPassagensPedagios.Placa,
                    Tag = resultPassagensPedagios.Tag,
                    Prefixo = resultPassagensPedagios.Prefixo,
                    Marca = resultPassagensPedagios.Marca,
                    Categ = resultPassagensPedagios.Categ,
                    Data = resultPassagensPedagios.Data,
                    Hora = resultPassagensPedagios.Hora,
                    Rodovia = resultPassagensPedagios.Rodovia,
                    Praca = resultPassagensPedagios.Praca,
                    Valor = resultPassagensPedagios.Valor,
                    ArquivoImportadoId = resultPassagensPedagios.ArquivoImportadoId
                });
            }

            return listaPassagensPedagios.ToList();

        }

        public List<PassagensValePedagio> PassagensValePedagioFiltroLista(string dataInicio, string dataFim, string placa, string viagem)
        {
            DateTime _dataInicio = Convert.ToDateTime(dataInicio);
            DateTime _dataFim = Convert.ToDateTime(dataFim);

            var sQuery = _context.PassagensValePedagios
                         .Where(b => b.PassagemValePedagioId > 0);

            DateTime dataValida;
            if (DateTime.TryParse(dataInicio, out dataValida))
            {
                sQuery = sQuery.Where(b => b.Data >= _dataInicio)
                               .Where(b => b.Data <= _dataFim);
            }

            if (placa != null)
            {
                sQuery = sQuery.Where(b => b.Placa == placa);
            }
            if (viagem != null)
            {
                sQuery = sQuery.Where(b => b.Viagem == viagem);
            }


            List<PassagensValePedagio> listaPassagensValePedagios = new List<PassagensValePedagio>();

            foreach(var resultPassagensValePedagios in sQuery)
            {
                listaPassagensValePedagios.Add(new PassagensValePedagio()
                {
                    PassagemValePedagioId = resultPassagensValePedagios.ArquivoImportadoId,
                    Placa = resultPassagensValePedagios.Placa,
                    Tag = resultPassagensValePedagios.Tag,
                    Prefixo = resultPassagensValePedagios.Prefixo,
                    Marca = resultPassagensValePedagios.Marca,
                    Categ = resultPassagensValePedagios.Categ,
                    Data = resultPassagensValePedagios.Data,
                    Hora = resultPassagensValePedagios.Hora,
                    Rodovia = resultPassagensValePedagios.Rodovia,
                    Praca = resultPassagensValePedagios.Praca,
                    Valor = resultPassagensValePedagios.Valor,
                    Viagem = resultPassagensValePedagios.Viagem,
                    Embarcador = resultPassagensValePedagios.Embarcador,
                    Cnpj = resultPassagensValePedagios.Cnpj,
                    ArquivoImportadoId = resultPassagensValePedagios.ArquivoImportadoId
                });
            }

            return listaPassagensValePedagios.ToList();

        }

        public List<PassagensPedagio> PassagensPedagioLista()
        {
            var sQuery = _context.PassagensPedagios;

            List<PassagensPedagio> listaPassagensPedagios = new List<PassagensPedagio>();

            foreach (var result in sQuery)
            {
                listaPassagensPedagios.Add(new PassagensPedagio()
                {
                    PassagemPedagioId = result.ArquivoImportadoId
                    ,Placa = result.Placa
                    ,Tag = result.Tag
                    ,Prefixo = result.Prefixo
                    ,Marca = result.Marca
                    ,Categ = result.Categ
                    ,Data = result.Data
                    ,Hora = result.Hora
                    ,Rodovia = result.Rodovia
                    ,Praca = result.Praca
                    ,Valor = result.Valor
                    ,ArquivoImportadoId = result.ArquivoImportadoId
                });

            }

            return listaPassagensPedagios.ToList();
        }

        public List<PassagensValePedagio> PassagensValePedagioLista()
        {
            var sQuery = _context.PassagensValePedagios;

            List<PassagensValePedagio> listaPassagensValePedagios = new List<PassagensValePedagio>();

            foreach (var result in sQuery)
            {
                listaPassagensValePedagios.Add(new PassagensValePedagio()
                {
                    PassagemValePedagioId = result.ArquivoImportadoId
                    ,Placa = result.Placa
                    ,Tag = result.Tag
                    ,Prefixo = result.Prefixo
                    ,Marca = result.Marca
                    ,Categ = result.Categ
                    ,Data = result.Data
                    ,Hora = result.Hora
                    ,Rodovia = result.Rodovia
                    ,Praca = result.Praca
                    ,Valor = result.Valor
                    ,Viagem = result.Viagem
                    ,Embarcador = result.Embarcador
                    ,Cnpj = result.Cnpj
                    ,ArquivoImportadoId = result.ArquivoImportadoId

                });
            }

            return listaPassagensValePedagios.ToList();
        }

        public List<Creditos> CreditosLista(string dataInicio, string dataFim)
        {

            var sQuery = from cred in _context.Creditos
                         select cred;

            if (!String.IsNullOrEmpty(dataInicio))
            {
                DateTime _dataInicio = Convert.ToDateTime(dataInicio);
                DateTime _dataFim = Convert.ToDateTime(dataFim);

                sQuery = sQuery.Where(b => b.Data >= _dataInicio)
                         .Where(b => b.Data <= _dataFim);
            }


            List<Creditos> listaCreditos = new List<Creditos>();

            foreach (var result in sQuery)
            {
                listaCreditos.Add(new Creditos()
                {
                    CreditoId = result.CreditoId                    
                    ,Placa = result.Placa
                    ,Tag = result.Tag
                    ,Data = result.Data
                    ,Hora = result.Hora
                    ,Descricao = result.Descricao
                    ,Viagem = result.Viagem
                    ,Praca = result.Praca
                    ,Valor = result.Valor
                    ,Embarcador = result.Embarcador
                    ,Cnpj = result.Cnpj
                    ,ArquivoImportadoId = result.ArquivoImportadoId
                });
            }

            return listaCreditos.ToList();
        }

        public void DeletarArquivosImportados(int id)
        {
            var arquivo = _context.ArquivosImportados.First(p => p.ArquivoImportadoId == id);
            _context.ArquivosImportados.Remove(arquivo);
            _context.SaveChangesAsync();
        }

    }
}
