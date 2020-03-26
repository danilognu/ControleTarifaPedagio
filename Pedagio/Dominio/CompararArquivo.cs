using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using Pedagio.Data.Entities;
using System.IO;
using OfficeOpenXml;
using Pedagio.Data;

namespace Pedagio.Dominio
{
    public class CompararArquivo
    {

        public List<Passagem> CompararArquivos(ComparacaoArquivos comparacaoArquivos)
        {
            List<Passagem> listaDifPassagens = new List<Passagem>();


            return listaDifPassagens;
        }

        public List<PassagensPedagio> LerAbaPassagensPedagio(ArquivosImportados arquivoImportado)
        {
            List<PassagensPedagio> listapassagensPedagios = new List<PassagensPedagio>();

            FileInfo file = new FileInfo(Path.Combine(arquivoImportado.PastaImportacao, arquivoImportado.NomeGerado));

            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets["PASSAGENS PEDÁGIO"];
                int totalRows = workSheet.Dimension.Rows;
                int contRows = GetLastUsedRow(workSheet);

                for (int i = 2; i <= contRows; i++)
                {
                    if (!String.IsNullOrEmpty(workSheet.Cells[i, 1].Value.ToString()))
                    {
                        string montarData = workSheet.Cells[i, 6].Value.ToString() + " " + workSheet.Cells[i, 7].Value.ToString();

                        PassagensPedagio passagensPedagio = new PassagensPedagio();
                        passagensPedagio.Placa = workSheet.Cells[i, 1].Value.ToString();
                        passagensPedagio.Tag = workSheet.Cells[i, 2].Value.ToString();
                        passagensPedagio.Prefixo = workSheet.Cells[i, 3].Value.ToString();
                        passagensPedagio.Marca = workSheet.Cells[i, 4].Value.ToString();
                        passagensPedagio.Categ = workSheet.Cells[i, 5].Value.ToString();
                        passagensPedagio.Data = Convert.ToDateTime(workSheet.Cells[i, 6].Value.ToString());
                        passagensPedagio.Hora = Convert.ToDateTime(montarData);
                        passagensPedagio.Rodovia = workSheet.Cells[i, 8].Value.ToString();
                        passagensPedagio.Praca = workSheet.Cells[i, 9].Value.ToString();
                        passagensPedagio.Valor = Convert.ToDecimal(workSheet.Cells[i, 10].Value.ToString());
                        passagensPedagio.ArquivoImportadoId = arquivoImportado.ArquivoImportadoId;
                        listapassagensPedagios.Add(passagensPedagio);
                    }
                }

            }

            return listapassagensPedagios;

        }

        public List<PassagensValePedagio> LerAbaPassagensValePedagio(ArquivosImportados arquivoImportado)
        {
            List<PassagensValePedagio> listapassagensValePedagios = new List<PassagensValePedagio>();

            FileInfo file = new FileInfo(Path.Combine(arquivoImportado.PastaImportacao, arquivoImportado.NomeGerado));

            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets["PASSAGENS VALE-PEDÁGIO"];
                int totalRows = workSheet.Dimension.Rows;
                int contRows = GetLastUsedRow(workSheet);

                for (int i = 2; i <= contRows; i++)
                {
                    if (!String.IsNullOrEmpty(workSheet.Cells[i, 1].Value.ToString()))
                    {
                        string montarData = workSheet.Cells[i, 6].Value.ToString() + " " + workSheet.Cells[i, 7].Value.ToString();

                        PassagensValePedagio passagensValePedagio = new PassagensValePedagio();
                        passagensValePedagio.Placa = workSheet.Cells[i, 1].Value.ToString();
                        passagensValePedagio.Tag = workSheet.Cells[i, 2].Value.ToString();
                        passagensValePedagio.Prefixo = workSheet.Cells[i, 3].Value.ToString();
                        passagensValePedagio.Marca = workSheet.Cells[i, 4].Value.ToString();
                        passagensValePedagio.Categ = workSheet.Cells[i, 5].Value.ToString();
                        passagensValePedagio.Data = Convert.ToDateTime(workSheet.Cells[i, 6].Value.ToString());
                        passagensValePedagio.Hora = Convert.ToDateTime(montarData);
                        passagensValePedagio.Rodovia = workSheet.Cells[i, 8].Value.ToString();
                        passagensValePedagio.Praca = workSheet.Cells[i, 9].Value.ToString();
                        passagensValePedagio.Valor = Convert.ToDecimal(workSheet.Cells[i, 10].Value.ToString());
                        passagensValePedagio.Viagem = workSheet.Cells[i, 11].Value.ToString();
                        passagensValePedagio.Embarcador = workSheet.Cells[i, 12].Value.ToString();
                        passagensValePedagio.Cnpj = workSheet.Cells[i, 13].Value.ToString();
                        passagensValePedagio.ArquivoImportadoId = arquivoImportado.ArquivoImportadoId;
                        listapassagensValePedagios.Add(passagensValePedagio);

                    }
                }
            }

            return listapassagensValePedagios;
        }

        public List<Creditos> LerAbaCreditos(ArquivosImportados arquivoImportado)
        {
            List<Creditos> listaCreditos = new List<Creditos>();

            FileInfo file = new FileInfo(Path.Combine(arquivoImportado.PastaImportacao, arquivoImportado.NomeGerado));

            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets["CRÉDITOS"];
                int totalRows = workSheet.Dimension.Rows;
                int contRows = GetLastUsedRow(workSheet);

                for (int i = 2; i <= contRows; i++)
                {
                    if (!String.IsNullOrEmpty(workSheet.Cells[i, 1].Value.ToString()))
                    {
                        string montarData = workSheet.Cells[i, 3].Value.ToString() + " " + workSheet.Cells[i, 4].Value.ToString();

                        Creditos credito = new Creditos();
                        credito.Placa = workSheet.Cells[i, 1].Value.ToString();
                        credito.Tag = workSheet.Cells[i, 2].Value.ToString();
                        credito.Data = Convert.ToDateTime(workSheet.Cells[i, 3].Value.ToString());
                        credito.Hora = Convert.ToDateTime(montarData);
                        credito.Descricao = workSheet.Cells[i, 5].Value.ToString();
                        credito.Viagem = workSheet.Cells[i, 6].Value.ToString();
                        credito.Praca = workSheet.Cells[i, 7].Value.ToString();
                        credito.Valor = Convert.ToDecimal(workSheet.Cells[i, 8].Value.ToString());
                        credito.Embarcador = workSheet.Cells[i, 9].Value.ToString();
                        credito.Cnpj = workSheet.Cells[i, 10].Value.ToString();
                        credito.ArquivoImportadoId = arquivoImportado.ArquivoImportadoId;
                        listaCreditos.Add(credito);
                    }
                }

            }

            return listaCreditos;


        }

        public List<Passagem> LerExcel(string arquivo, string caminhoArquivoServ)
        {
            List<Passagem> passagens = new List<Passagem>();

            FileInfo file = new FileInfo(Path.Combine(caminhoArquivoServ, arquivo));

            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets["Plan1"];
                int totalRows = workSheet.Dimension.Rows;
                int contRows = GetLastUsedRow(workSheet);

                for (int i = 2; i <= contRows; i++)
                {

                    if (! String.IsNullOrEmpty(workSheet.Cells[i, 1].Value.ToString()) )
                    {

                        Passagem passagem = new Passagem();

                        passagem.Placa = workSheet.Cells[i, 1].Value.ToString();
                        passagem.Data = Convert.ToDateTime(workSheet.Cells[i, 2].Value.ToString());
                        passagem.Hora = workSheet.Cells[i, 3].Value.ToString();
                        passagem.Rodovia = workSheet.Cells[i, 4].Value.ToString();
                        passagem.Praca = workSheet.Cells[i, 5].Value.ToString();
                        passagem.Valor = Convert.ToDecimal(workSheet.Cells[i, 6].Value.ToString());
                        passagem.Viagem = Convert.ToInt32(workSheet.Cells[i, 7].Value.ToString());
                        passagem.Embarcado = workSheet.Cells[i, 8].Value.ToString();
                        passagem.Categoria = workSheet.Cells[i, 9].Value.ToString();
                        passagem.Tag = Convert.ToInt32(workSheet.Cells[i, 10].Value.ToString());
                        passagens.Add(passagem);

                    }

                }

            }

            return passagens;

        }

        public int GetLastUsedRow(ExcelWorksheet sheet)
        {
            var row = sheet.Dimension.End.Row;
            while (row >= 1)
            {
                var range = sheet.Cells[row, 1, row, sheet.Dimension.End.Column];
                if (range.Any(c => !string.IsNullOrEmpty(c.Text)))
                {
                    break;
                }
                row--;
            }
            return row;
        }
    }
}
