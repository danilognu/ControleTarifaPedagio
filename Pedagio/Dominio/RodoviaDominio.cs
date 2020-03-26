using System;
using System.Collections.Generic;
using System.Linq;
using Pedagio.Data.Entities;
using OfficeOpenXml;
using System.IO;
using Pedagio.ViewsModels;


namespace Pedagio.Dominio
{
    public class RodoviaDominio
    {


        public List<RodoviaTarifasOperadoras> LerExcelRodoviaTarifasOperadoras(ArquivosImportados arquivosImportados)
        {
            List<RodoviaTarifasOperadoras> listaRodoviasTarifas = new List<RodoviaTarifasOperadoras>();


            FileInfo file = new FileInfo(Path.Combine(arquivosImportados.PastaImportacao, arquivosImportados.NomeGerado));

            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets["Exportar Planilha"];
                int totalRows = workSheet.Dimension.Rows;
                int contRows = GetLastUsedRow(workSheet);

                for (int i = 2; i <= contRows; i++)
                {
                    if (!String.IsNullOrEmpty(workSheet.Cells[i, 1].Value.ToString()))
                    {

                        RodoviaTarifasOperadoras rodoviaTarifasOperadoras = new RodoviaTarifasOperadoras();
                        rodoviaTarifasOperadoras.AssociateId = Int32.Parse(workSheet.Cells[i, 1].Value.ToString());
                        rodoviaTarifasOperadoras.AssociateCompKnownName = workSheet.Cells[i, 2].Value.ToString();
                        rodoviaTarifasOperadoras.EntryId = Int32.Parse(workSheet.Cells[i, 3].Value.ToString());
                        rodoviaTarifasOperadoras.RoadCode = workSheet.Cells[i, 4].Value.ToString();
                        rodoviaTarifasOperadoras.RoadEntryKm = workSheet.Cells[i, 5].Value.ToString();
                        rodoviaTarifasOperadoras.Descricao = workSheet.Cells[i, 6].Value.ToString();
                        rodoviaTarifasOperadoras.CategoryArtespId = Int32.Parse(workSheet.Cells[i, 7].Value.ToString());
                        rodoviaTarifasOperadoras.Nome = workSheet.Cells[i, 8].Value.ToString();
                        rodoviaTarifasOperadoras.Tarifa = Convert.ToDecimal(workSheet.Cells[i, 9].Value.ToString());
                        rodoviaTarifasOperadoras.PAssagem90Dias = workSheet.Cells[i, 10].Value.ToString();
                        listaRodoviasTarifas.Add(rodoviaTarifasOperadoras);

                    }
                }

            }

            return listaRodoviasTarifas;
        }

        public List<RodoviasTarifas> LerExcelRodovia(ArquivosImportados arquivosImportados, Rodovia rodovia)
        {
            List<RodoviasTarifas> listaRodoviasTarifas = new List<RodoviasTarifas>();


            FileInfo file = new FileInfo(Path.Combine(arquivosImportados.PastaImportacao, arquivosImportados.NomeGerado));

            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets[rodovia.NomeRodovia];
                int totalRows = workSheet.Dimension.Rows;
                int contRows = GetLastUsedRow(workSheet);

                for (int i = 2; i <= contRows; i++)
                {
                    if (!String.IsNullOrEmpty(workSheet.Cells[i, 1].Value.ToString()))
                    {

                        RodoviasTarifas rodoviasTarifas = new RodoviasTarifas();
                        rodoviasTarifas.AssociateCompKNownName = workSheet.Cells[i, 1].Value.ToString(); ;
                        rodoviasTarifas.Praca = workSheet.Cells[i, 2].Value.ToString(); ;
                        rodoviasTarifas.VehicleClassId = workSheet.Cells[i, 3].Value.ToString(); ;
                        rodoviasTarifas.Name = workSheet.Cells[i, 4].Value.ToString(); 
                        rodoviasTarifas.DateHourProgramStart = workSheet.Cells[i, 5].Value.ToString();
                        rodoviasTarifas.Value = workSheet.Cells[i, 6].Value.ToString();
                        rodoviasTarifas.RodoviaId = rodovia.RodoviaId;
                        listaRodoviasTarifas.Add(rodoviasTarifas);

                    }
                }

            }

            return listaRodoviasTarifas;
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

        public RodoviasTarifasViewsModels GerarStringComparacao(RodoviasTarifas rodoviasTarifas)
        {
            string praca = rodoviasTarifas.Praca;
            //Itupeva Sul - SP 348 KM 77+430
            //SP330, KM117+710, NORTE, NOVA ODESSA

            var cidade = praca.Split("-");
            var rodovia = cidade[1].Split("KM");

            string[] km;
            km = rodovia[1].Split("+");
            if(km.Length == 1)
            {
                km = rodovia[1].Split(".");
            }

            string kmSpace = km[0].Replace(" ", "");
            string rodoviaSpace = rodovia[0].Replace(" ", "");
            
            RodoviasTarifasViewsModels rodoviasTfViewsModels = new RodoviasTarifasViewsModels();
            rodoviasTfViewsModels.Rodovia = rodoviaSpace;
            rodoviasTfViewsModels.Km = "KM" + kmSpace;
            rodoviasTfViewsModels.Cidade = cidade[0];

            return rodoviasTfViewsModels;
        }

        //Rodovia + KM + Sentido + Cidade
        public ChaveBuscaViewsModels MontaChaveUm(string praca)
        {

            ChaveBuscaViewsModels chave = new ChaveBuscaViewsModels();

            bool _validaChave = false;

            if (praca.IndexOf(",") > 0)
            {
                var _strPraca = praca.Split(",");

                int valorArray = _strPraca.Length;

                if (_strPraca[1].Length > 0)
                {
                    string _km = _strPraca[1];
                    string _verificaKM = _km.Replace(" ", "").Substring(0, 2);

                    if (_verificaKM == "KM")
                    {
                        _validaChave = true;
                    }
                }

                if (_validaChave)
                {
                    chave.Rodovia = _strPraca[0];

                    //monta km
                    string mntKm = _strPraca[1];
                    var mntKmIncFim = mntKm.Split("+");
                    chave.Km = mntKmIncFim[0].Replace(" ", "");

                    string mntCidade = "";

                    if (valorArray > 3)
                    {
                        chave.Sentido = _strPraca[2];
                        mntCidade     = _strPraca[3];
                    }
                    else
                    {
                        mntCidade = _strPraca[2];
                    }
                    
                    if (mntCidade.IndexOf("-") > 0)
                    {
                        var mntCidadeEstado = mntCidade.Split("-");
                        chave.Cidade = mntCidadeEstado[0];
                        chave.Estado = mntCidadeEstado[1];

                    }
                    else
                    {
                        chave.Cidade = mntCidade;
                    }


                }
            }           

            chave.Valida = _validaChave;

            return chave;
        }

        //Somente Cidade
        public ChaveBuscaViewsModels MontaChaveDois(string praca)
        {
            ChaveBuscaViewsModels chave = new ChaveBuscaViewsModels();

            int validaKm = praca.IndexOf("KM");
            string pontoCardealAtual = "";
            string montaPraca = "";
            string mbCidade = "";
            string mbKm = "";
            bool _valida = false;

            //Existe Km na Chave
            if(validaKm > 0)
            {
                //Localiza ponto cardeal
                string[] pontoCardeal = { "NORTE", "SUL", "LESTE", "OESTE" };
                foreach (string ponto in pontoCardeal)
                {
                    int validaPonto = praca.IndexOf(ponto);
                    if(validaPonto > 0)
                    {
                        pontoCardealAtual = ponto;
                        montaPraca = praca.Replace(pontoCardealAtual, "");
                        var montaCidkm = montaPraca.Split("KM");
                        mbCidade = montaCidkm[0];
                        mbKm = montaCidkm[1];

                        chave.Sentido = pontoCardealAtual;
                        chave.Cidade = mbCidade;

                        //Trata KM
                        chave.Km = GetTrataKm(mbKm);
                        
                        _valida = true;
                    }

                }
                if (!_valida)
                {
                    if (praca.IndexOf("-") > 0)
                    {
                        var bsCidade = praca.Split("-");

                        chave.Cidade = bsCidade[0];
                        chave.Km = GetTrataKm(mbKm);
                        _valida = true;
                    }
                }

            }
            else
            {
                if (!_valida)
                {
                    if(praca.IndexOf(",") == -1)
                    {
                        chave.Cidade = praca;
                        _valida = true;
                    }
                    
                }

            }
            chave.Valida = _valida;

            return chave;

        }

        public string GetTrataKm(string km)
        {
            string _km = "";

            if (km.IndexOf("+") > 0)
            {
                var _kmMais = km.Split("+");
                string _kmSmais = "KM" + _kmMais[0].Replace(" ", "");
                _km = _kmSmais;
            }
            else if (km.IndexOf(",") > 0)
            {
                var _kmVirgula = km.Split(",");
                _km = "KM" + _kmVirgula[0].Replace(" ", ""); ;
            }
            else
            {
                _km = "KM" + km.Replace(" ", "");
            }

            return _km;
        }


        public RodoviaTarifasOperadorasViewsModels GerarStringChaveRodoviasTarifasOp(RodoviaTarifasOperadoras rodoviaTarifasOperadoras)
        {
            string praca = rodoviaTarifasOperadoras.Descricao;
            string exioNome = rodoviaTarifasOperadoras.Nome;
            //Itupeva Sul - SP 348 KM 77+430
            //SP330, KM117+710, NORTE, NOVA ODESSA

            //SP 348 - km 39 + 047 - Franco da Rocha


            var stringBase = praca.Split("-");

            int contaCidade = stringBase.Length-1;

            var cidade = stringBase[contaCidade];
            var rodovia = stringBase[0];
            var kmStr = stringBase[1];
            var eixo = exioNome.Split(" "); ;

            string[] km;
            km = kmStr.Split("+");

            string kmSpace = km[0].Replace(" ", "");
            string rodoviaSpace = rodovia.Replace(" ", "");
            int eixoSpace = Convert.ToInt32(eixo[0].Replace(" ", ""));

            RodoviaTarifasOperadorasViewsModels rodoviasTfViewsModels = new RodoviaTarifasOperadorasViewsModels();
            rodoviasTfViewsModels.Rodovia = rodoviaSpace;
            rodoviasTfViewsModels.Km = kmSpace;
            rodoviasTfViewsModels.Cidade = cidade;
            rodoviasTfViewsModels.Eixo = eixoSpace;

            return rodoviasTfViewsModels;

        }




    }
}
