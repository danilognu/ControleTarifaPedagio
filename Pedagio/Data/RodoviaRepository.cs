using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pedagio.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Pedagio.ViewsModels;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Pedagio.Data
{
    public class RodoviaRepository : IRodoviaRepository
    {
        private readonly ApplicationDbContext _context;
        private IConfiguration _configuration;

        public RodoviaRepository(ApplicationDbContext context, IConfiguration Configuration)
        {
            _context = context;
            _configuration = Configuration;
        }

        public List<Rodovia> RodoviaListar()
        {
            var sQuery = from rodovia in _context.Rodovias
                         select rodovia;

            List<Rodovia> listaRodovias = new List<Rodovia>();

            foreach (var result in sQuery)
            {
                listaRodovias.Add(new Rodovia()
                {
                    RodoviaId = result.RodoviaId,
                    NomeRodovia = result.NomeRodovia
                });
            }

            return listaRodovias.ToList();

        }

        public List<RodoviasTarifas> RodoviasTarifasListar()
        {
            var sQuery = from rodoviasTarifas in _context.RodoviasTarifas
                         select rodoviasTarifas;

            List<RodoviasTarifas> listaRodoviasTarifas = new List<RodoviasTarifas>();

            foreach (var result in sQuery)
            {
                listaRodoviasTarifas.Add(new RodoviasTarifas()
                {
                    RodoviaTarifaId = result.RodoviaTarifaId,
                    AssociateCompKNownName = result.AssociateCompKNownName,
                    Praca = result.Praca,
                    VehicleClassId = result.VehicleClassId,
                    Name = result.Name,
                    DateHourProgramStart = result.DateHourProgramStart,
                    Value = result.Value,
                    Rodovia = result.Rodovia
                });
            }

            return listaRodoviasTarifas.ToList();
        }

        public List<RodoviaTarifasOperadoras> RodoviasTarifaOperadorasListar()
        {
            var sQuery = from rodoviaTarifasOperadoras in _context.RodoviaTarifasOperadoras
                         select rodoviaTarifasOperadoras;
            sQuery = sQuery.Where(b => b.RodoviaTarifasOperadorasId >= 98936);
            //sQuery = sQuery.Where(b => b.RodoviaTarifasOperadorasId <=  103936);

            List<RodoviaTarifasOperadoras> listaRodoviaTarifasOperadoras = new List<RodoviaTarifasOperadoras>();

            foreach (var result in sQuery)
            {
                listaRodoviaTarifasOperadoras.Add(new RodoviaTarifasOperadoras()
                {
                    RodoviaTarifasOperadorasId = result.RodoviaTarifasOperadorasId
                    ,AssociateId = result.AssociateId
                    ,AssociateCompKnownName = result.AssociateCompKnownName
                    ,EntryId = result.EntryId
                    ,RoadCode = result.RoadCode
                    ,RoadEntryKm = result.RoadEntryKm
                    ,Descricao = result.Descricao
                    ,CategoryArtespId = result.CategoryArtespId
                    ,Nome = result.Nome
                    ,Tarifa = result.Tarifa
                    ,PAssagem90Dias = result.PAssagem90Dias
                });
            }

            return listaRodoviaTarifasOperadoras.ToList();
        }


        public void SalvarRodovia(Rodovia rodovia)
        {
            _context.Rodovias.Add(rodovia);
            _context.SaveChangesAsync();
        }

        public void EditarRodovia(Rodovia rodovia)
        {
            _context.Rodovias.Update(rodovia);
            _context.SaveChangesAsync();
        }

        public void SalvarRodoviaTarifa(RodoviasTarifas rodoviasTarifas)
        {
            _context.RodoviasTarifas.Add(rodoviasTarifas);
            _context.SaveChanges();
        }

        public void SalvarRodoviaTarifaOperadoras(RodoviaTarifasOperadoras rodoviaTarifasOperadoras)
        {
            _context.RodoviaTarifasOperadoras.Add(rodoviaTarifasOperadoras);
            _context.SaveChanges();
        }

        public void SalvarStringComparacao(RodoviasTarifas rodoviasTarifas)
        {
            var rodoviasTarifasSalva = _context.RodoviasTarifas.First(c => c.RodoviaTarifaId == rodoviasTarifas.RodoviaTarifaId);

            rodoviasTarifasSalva.Cidade = rodoviasTarifas.Cidade;
            rodoviasTarifasSalva.Km = rodoviasTarifas.Km;
            rodoviasTarifasSalva.Rodovia = rodoviasTarifas.Rodovia;
            _context.SaveChanges();
        }

        public void SalvarStringChaveRodoviaTarifasOperadoras(RodoviaTarifasOperadoras rodoviaTarifasOperadoras)
        {
            var rodoviasTarifasSalva = _context.RodoviaTarifasOperadoras.First(c => c.RodoviaTarifasOperadorasId == rodoviaTarifasOperadoras.RodoviaTarifasOperadorasId);

            rodoviasTarifasSalva.Cidade = rodoviaTarifasOperadoras.Cidade;
            rodoviasTarifasSalva.Km = rodoviaTarifasOperadoras.Km;
            rodoviasTarifasSalva.Rodovia = rodoviaTarifasOperadoras.Rodovia;
            rodoviasTarifasSalva.Eixo = rodoviaTarifasOperadoras.Eixo;
            _context.SaveChanges();
        }

        public void UpdateChavePassagensPedagio(PassagensPedagio passagensPedagio)
        {
            var passagemUpdate = _context.PassagensPedagios.First(c => c.PassagemPedagioId == passagensPedagio.PassagemPedagioId);

            passagemUpdate.OpRodoviaChave = passagensPedagio.OpRodoviaChave;
            passagemUpdate.KmChave = passagensPedagio.KmChave;
            passagemUpdate.SentidoChave = passagensPedagio.SentidoChave;
            passagemUpdate.CidadeChave = passagensPedagio.CidadeChave;
            passagemUpdate.EstadoChave = passagensPedagio.EstadoChave;
            _context.SaveChanges();

        }

        public List<RodoviaTarifasOperadoras> BuscaRodoviaTarifasOperadorasChave()
        {
            List<RodoviaTarifasOperadoras> rodoviaTarifasOperadoras = new List<RodoviaTarifasOperadoras>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                string sQuery = "SELECT AssociateCompKnownName,Cidade,KM,Rodovia,ISNULL(Eixo,0) Eixo,Tarifa " +
                                "FROM RodoviaTarifasOperadoras  " +
                                "WHERE 1=1 AND AssociateCompKnownName IN('AUTOPISTA FERNÃO DIAS','ECO135','VIA 040','VIA BAHIA')  ";

                using (SqlCommand command = new SqlCommand(sQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            RodoviaTarifasOperadoras rodoviaTarifasOperadorasadd = new RodoviaTarifasOperadoras();

                            rodoviaTarifasOperadorasadd.AssociateCompKnownName = reader.GetString(0);
                            rodoviaTarifasOperadorasadd.Cidade = reader.GetString(1);
                            rodoviaTarifasOperadorasadd.Km = reader.GetString(2);
                            rodoviaTarifasOperadorasadd.Rodovia = reader.GetString(3);
                            rodoviaTarifasOperadorasadd.Eixo = Convert.ToInt32(reader.GetInt32(4));
                            rodoviaTarifasOperadorasadd.Tarifa = Convert.ToDecimal(reader.GetDecimal(5));
                            rodoviaTarifasOperadoras.Add(rodoviaTarifasOperadorasadd);

                        }
                    }
                }
            }

            return rodoviaTarifasOperadoras.ToList();

        }

        public List<PassagensValePedagio> PassagensValePedagiosBuscaComChave(RodoviaTarifasOperadoras rodoviaTarifasOperadoras)
        {
            List<PassagensValePedagio> listaPassagensValePedagios = new List<PassagensValePedagio>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                string sQuery = "SELECT " +
                                " pv.PassagemValePedagioId " +
                                " ,pv.Placa " +
                                " ,pv.Rodovia " +
                                " ,pv.Praca " +
                                " ,pv.Valor " +
                                " ,ISNULL(eixoAbaixado.Numero, 0) AS EixoAbaixado " +
                                " ,ISNULL(eixoSuspenso.Numero, 0) AS EixoSuspenso " +
                                " FROM PassagensValePedagios pv " +
                                " LEFT JOIN Veiculos v ON v.Placa = pv.Placa " +
                                " LEFT JOIN CategoriaVeiculos eixoAbaixado on eixoAbaixado.CategoriaId = v.CategoriaIdEixoAbaixado " +
                                " LEFT JOIN CategoriaVeiculos eixoSuspenso on eixoSuspenso.CategoriaId = v.CategoriaIdEixoSuspenso " +
                                " " +
                                " WHERE " +
                                " pv.Rodovia LIKE @Operadora " +
                                " and pv.Praca LIKE @Cidade " +
                                " and pv.Praca LIKE @Km " +
                                " and pv.Praca LIKE @Rodovia" +
                                " and (eixoAbaixado.Numero = @Eixo or eixoSuspenso.Numero = @Eixo) ";




                using (SqlCommand command = new SqlCommand(sQuery, connection))
                {
                    command.Parameters.AddWithValue("@Operadora", "%" + rodoviaTarifasOperadoras.AssociateCompKnownName + "%");
                    command.Parameters.AddWithValue("@Cidade", "%" + rodoviaTarifasOperadoras.Cidade + "%");
                    command.Parameters.AddWithValue("@Rodovia", "%" + rodoviaTarifasOperadoras.Rodovia + "%");
                    command.Parameters.AddWithValue("@Km", "%" + rodoviaTarifasOperadoras.Km + "%");
                    command.Parameters.AddWithValue("@Eixo",rodoviaTarifasOperadoras.Eixo);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            listaPassagensValePedagios.Add(new PassagensValePedagio()
                            {
                                PassagemValePedagioId = reader.GetInt32(0),
                                Placa = reader.GetString(1),
                                Rodovia = reader.GetString(2),
                                Praca = reader.GetString(3),
                                Valor = Convert.ToDecimal(reader.GetDecimal(4)),
                                EixoAbaixado = reader.GetInt32(5),
                                EixoSuspenso = reader.GetInt32(6)
                            });
                        }
                    }
                }

            }

            return listaPassagensValePedagios.ToList();

        }


        public void SalvarStringVAlorEixoAbaixado(PassagensValePedagio passagensValePedagio, string strValor)
        {
            var rodoviasTarifasSalva = _context.PassagensValePedagios.First(c => c.PassagemValePedagioId == passagensValePedagio.PassagemValePedagioId);
            rodoviasTarifasSalva.EixoAbaixadoComparacao = strValor;
            _context.SaveChanges();
        }

        public void SalvarStringVAlorEixoSuspenso(PassagensValePedagio passagensValePedagio, string strValor)
        {
            var rodoviasTarifasSalva = _context.PassagensValePedagios.First(c => c.PassagemValePedagioId == passagensValePedagio.PassagemValePedagioId);
            rodoviasTarifasSalva.EixoSuspensoComparacao = strValor;
            _context.SaveChanges();
        }



        public List<RodoviasTarifas> RodoviasTarifasGroup()
        {

            List<RodoviasTarifas> listaRodoviasTarifas = new List<RodoviasTarifas>();

            //Configuration.GetConnectionString("DefaultConnection")
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                string sQuery = "SELECT " +
                                " AssociateCompKNownName " +
                                " ,Cidade " +
                                " ,Km " +
                                " ,Rodovia " +
                                " FROM " +
                                " RodoviasTarifas " +
                                " GROUP BY " +
                                " AssociateCompKNownName, Cidade, Km, Rodovia";

                using (SqlCommand command = new SqlCommand(sQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RodoviasTarifas rodoviasTarifas = new RodoviasTarifas();
                            rodoviasTarifas.AssociateCompKNownName = reader.GetString(0);
                            listaRodoviasTarifas.Add(new RodoviasTarifas()
                            {
                                AssociateCompKNownName = reader.GetString(0),
                                Cidade  = reader.GetString(1),
                                Km = reader.GetString(2),
                                Rodovia = reader.GetString(3),
                            });
                        }
                    }
                }
            }
            //Consulta Bruna no SQL Core
            /*string strQuery = "SELECT * FROM BuscaChaveTarifa";
            var sQuery = _context.RodoviasTarifas.FromSql(strQuery); */
            return listaRodoviasTarifas.ToList();
        }

        public List<PassagensValePedagioCalculado> BuscaPassagensValePedagioChave(RodoviasTarifas rodoviasTarifas)
        {

            List<PassagensValePedagio> listaPassagensValePedagio = new List<PassagensValePedagio>();
            List<PassagensValePedagioCalculado> ListapassagensValePedagioCalculados = new List<PassagensValePedagioCalculado>();

            var sQuery = "SELECT " +
                            " pv.PassagemValePedagioId " +
                            ",pv.Placa " +
                            ",pv.Rodovia " +
                            ",pv.Praca " +
                            ",pv.Valor " +
                            ",ISNULL(eixoAbaixado.Numero,0) AS EixoAbaixado " +
                            ",ISNULL(eixoSuspenso.Numero,0) AS EixoSuspenso " +
                            ",ISNULL(( " +
                            "    SELECT top 1 tarifaEixoAbaixado.Value FROM RodoviasTarifas tarifaEixoAbaixado " +
                            "    WHERE tarifaEixoAbaixado.AssociateCompKNownName like @Operadora " +
                            "    AND tarifaEixoAbaixado.Cidade like @Cidade " +
                            "    and tarifaEixoAbaixado.km like @Km " +
                            "    and tarifaEixoAbaixado.Rodovia like @Rodovia " +
                            "    and tarifaEixoAbaixado.VehicleClassId = eixoAbaixado.Numero " +
                            "),0) ValorTarifaEixoAbaixado " +
                            ",ISNULL(( " +
                            "    SELECT top 1 tarifaEixoSuspenso.Value FROM RodoviasTarifas tarifaEixoSuspenso " +
                            "    WHERE tarifaEixoSuspenso.AssociateCompKNownName like @Operadora " +
                            "    AND tarifaEixoSuspenso.Cidade like @Cidade " +
                            "    and tarifaEixoSuspenso.km like @Km " +
                            "    and tarifaEixoSuspenso.Rodovia like @Rodovia " +
                            "    and tarifaEixoSuspenso.VehicleClassId = eixoSuspenso.Numero " +
                            "),0) ValorTarifaEixoSuspenso " +
                            " " +
                            "FROM PassagensValePedagios pv " +
                            "LEFT JOIN Veiculos v ON v.Placa = pv.Placa " +
                            "LEFT JOIN CategoriaVeiculos eixoAbaixado on eixoAbaixado.CategoriaId = v.CategoriaIdEixoAbaixado " +
                            "LEFT JOIN CategoriaVeiculos eixoSuspenso on eixoSuspenso.CategoriaId = v.CategoriaIdEixoSuspenso " +
                            "WHERE " +
                            "pv.Rodovia like @Operadora " +
                            "and pv.Praca like @Cidade " +
                            "and pv.Praca like @Rodovia " +
                            "and pv.Praca like @Km " +
                            "ORDER BY Placa";


            //BUSCA TODOS OS VEICULOS PELA CHAVE DA TARIFA
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sQuery, connection))
                {

                    string sCidade = rodoviasTarifas.Cidade.Replace("Sul", "");
                    string nCidade = sCidade.Replace("Norte", "");
                    string ndCidade = nCidade.Replace(" ", "");


                    command.Parameters.AddWithValue("@Operadora", "%" + rodoviasTarifas.AssociateCompKNownName + "%");
                    command.Parameters.AddWithValue("@Cidade", "%" + ndCidade + "%");
                    command.Parameters.AddWithValue("@Rodovia", "%" + rodoviasTarifas.Rodovia + "%");
                    command.Parameters.AddWithValue("@Km", "%" + rodoviasTarifas.Km + "%");


                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        bool teste = reader.HasRows;
                        while (reader.Read())
                        {

                            string ValorTarifaEixoAbaixado = reader.GetString(7);
                            string ValorTarifaEixoSuspenso = reader.GetString(8);

                            PassagensValePedagioCalculado passagensValePedagioCalculado = new PassagensValePedagioCalculado();
                            passagensValePedagioCalculado.PassagemValePedagioId = reader.GetInt32(0);
                            passagensValePedagioCalculado.Placa = reader.GetString(1);
                            passagensValePedagioCalculado.Rodovia = reader.GetString(2);
                            passagensValePedagioCalculado.Praca = reader.GetString(3);
                            passagensValePedagioCalculado.Valor = reader.GetDecimal(4);
                            passagensValePedagioCalculado.EixoAbaixado = reader.GetInt32(5);
                            passagensValePedagioCalculado.EixoSuspenso = reader.GetInt32(6);
                            passagensValePedagioCalculado.ValorTarifaEixoAbaixado = ValorTarifaEixoAbaixado;
                            passagensValePedagioCalculado.ValorTarifaEixoSuspenso = ValorTarifaEixoSuspenso;
                            ListapassagensValePedagioCalculados.Add(passagensValePedagioCalculado);


                        }
                    }
                }
            }

            return ListapassagensValePedagioCalculados.ToList();

        }

        public void AtualizaCalculoPassagensValePedagio(PassagensValePedagioCalculado passagensValePedagioCalculado, int eixoAbaixado, int eixoSuspenso)
        {

            object updatePassagensValePedagio = null;

            var sQuery = "UPDATE PassagensValePedagios SET " +
                         " EixoAbaixado = @EixoAbaixado" +
                         ", EixoSuspenso = @EixoSuspenso " +
                         "WHERE PassagemValePedagioId = @PassagemValePedagioId";

            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sQuery, connection))
                    {
                        command.Parameters.Add("@EixoAbaixado", SqlDbType.Int);
                        command.Parameters.Add("@EixoSuspenso", SqlDbType.Int);
                        command.Parameters.Add("@PassagemValePedagioId", SqlDbType.Int);

                        command.Parameters["@EixoAbaixado"].Value = eixoAbaixado;
                        command.Parameters["@EixoSuspenso"].Value = eixoSuspenso;
                        command.Parameters["@PassagemValePedagioId"].Value = passagensValePedagioCalculado.PassagemValePedagioId;

                        updatePassagensValePedagio = command.ExecuteScalar();

                    }
                }

            }
            catch (Exception e)
            {

            }

        }

        public List<PassagensPedagio> GetRodoviaPassagensPedagio()
        {

            List<PassagensPedagio> ListaPassagensPedagio = new List<PassagensPedagio>();

            var _Sql = "SELECT Rodovia FROM PassagensPedagios GROUP BY Rodovia ORDER BY 1 ";

            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(_Sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ListaPassagensPedagio.Add(new PassagensPedagio()
                                {
                                    Rodovia = reader.GetString(0)

                                });
                            }
                        }

                    }
                }
            }
            catch (Exception e)
            {
                var msg = e.Message.ToString();
            }

            return ListaPassagensPedagio;

        }


        public List<PassagensPedagio> GetPracasPassagensPedagio(string rodovia)
        {

            List<PassagensPedagio> ListaPassagensPedagio = new List<PassagensPedagio>();


            //var _Sql = "SELECT PassagemPedagioId,Praca FROM PassagensPedagios WHERE PassagemPedagioId in(42267,42306,42310,42316,42942,56680,42271,43983,44391)";
            var _Sql = "SELECT PassagemPedagioId,Praca FROM PassagensPedagios WHERE Rodovia LIKE @Rodovia";

            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(_Sql, connection))
                    {
                        command.Parameters.AddWithValue("@Rodovia", "%" + rodovia + "%");

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ListaPassagensPedagio.Add(new PassagensPedagio()
                                {
                                    PassagemPedagioId = reader.GetInt32(0),
                                    Praca = reader.GetString(1)

                                });
                            }
                        }

                    }
                }
            }
            catch (Exception e)
            {
                var msg = e.Message.ToString();
            }

            return ListaPassagensPedagio;

        }

        //Busca Todas as Rodovias Agrupadas
        public List<RodoviaTarifaGroupViewsModels> GetRodoviaTarifasOperadorasGroup()
        {

            List<RodoviaTarifaGroupViewsModels> ListaRodoviaTarifaGroup = new List<RodoviaTarifaGroupViewsModels>();

            var sQuery = "SELECT AssociateCompKnownName" +
                         ",(SELECT COUNT(*) FROM PassagensPedagios WHERE Rodovia IN(AssociateCompKnownName)) as Existe " +
                         "FROM RodoviaTarifasOperadoras " +
                         "WHERE (SELECT COUNT(*) FROM PassagensPedagios WHERE Rodovia IN(AssociateCompKnownName)) > 0" +
                         "GROUP BY AssociateCompKnownName  ";

            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ListaRodoviaTarifaGroup.Add(new RodoviaTarifaGroupViewsModels()
                                {
                                    Rodovia = reader.GetString(0),
                                    ExisteRodovia = reader.GetInt32(1)

                                });
                            }
                        }

                    }
                }
            }
            catch (Exception e)
            {
                var msg = e.Message.ToString();
            }

            return ListaRodoviaTarifaGroup;

        }


        public List<RodoviaTarifasOperadoras> ListaRodoviasTarifasOperadoras(RodoviaTarifaGroupViewsModels rodoviaTarifaGroupViewsModels)
        {

            List<RodoviaTarifasOperadoras> listaRodoviaTarifasOperadoras = new List<RodoviaTarifasOperadoras>();

            var sQuery = "SELECT " +
                        "  RodoviaTarifasOperadorasId " +
                        " ,AssociateId " +
                        " ,AssociateCompKnownName " +
                        " ,EntryId " +
                        " ,RoadCode " +
                        " ,RoadEntryKm " +
                        " ,Descricao " +
                        " ,CategoryArtespId" +
                        " ,Nome " +
                        " ,Tarifa " +
                        " ,PAssagem90Dias " +
                        " ,Cidade " +
                        " ,Km " +
                        " ,Rodovia " +
                        " ,Eixo" +
                        " FROM RodoviaTarifasOperadoras WHERE AssociateCompKnownName LIKE @Rodovia";
            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Rodovia", "%" + rodoviaTarifaGroupViewsModels.Rodovia + "%");

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                RodoviaTarifasOperadoras rodoviaTF = new RodoviaTarifasOperadoras();
                                rodoviaTF.RodoviaTarifasOperadorasId = reader.GetInt32(0);
                                rodoviaTF.AssociateId = reader.GetInt32(1);
                                rodoviaTF.AssociateCompKnownName = reader.GetString(2);
                                rodoviaTF.EntryId = reader.GetInt32(3);
                                rodoviaTF.RoadCode = reader.GetString(4);
                                rodoviaTF.RoadEntryKm = reader.GetString(5);
                                rodoviaTF.Descricao = reader.GetString(6);
                                rodoviaTF.CategoryArtespId = reader.GetInt32(7);
                                rodoviaTF.Nome = reader.GetString(8);
                                rodoviaTF.Tarifa = reader.GetDecimal(9);
                                rodoviaTF.PAssagem90Dias = reader.GetString(10);
                                rodoviaTF.Cidade = reader.GetString(11);
                                rodoviaTF.Km = reader.GetString(12);
                                rodoviaTF.Rodovia = reader.GetString(13);
                                rodoviaTF.Eixo = reader.GetInt32(14);
                                listaRodoviaTarifasOperadoras.Add(rodoviaTF);
                            }



                         }
                    }
                }

            }
            catch (Exception e)
            {

            }

            return listaRodoviaTarifasOperadoras;

        }

        public List<PassagensPedagioBuscaChaveViewsModels> BuscaTabelaPassagensPedagioComChave(RodoviaTarifasOperadoras rodoviaTarifasOperadoras)
        {

            List<PassagensPedagioBuscaChaveViewsModels> listaPassagensPedagioBuscaChaveViewsModels = new List<PassagensPedagioBuscaChaveViewsModels>();

            var sQuery = "SELECT " +
                         "     p.PassagemPedagioId " +
                         "     ,p.Placa " +
                         "     ,p.Rodovia " +
                         "     ,p.Praca " +
                         "     ,p.Valor " +
                         "     ,eixoAbaixado.Numero as 'eixoAbaixado'" +
                         "     ,exixoSuspenso.Numero as 'exixoSuspenso' " +
                         " FROM PassagensPedagios p " +
                         " LEFT JOIN Veiculos v " +
                         "         ON v.Placa = p.Placa " +
                         " LEFT JOIN CategoriaVeiculos eixoAbaixado " +
                         "         ON eixoAbaixado.CategoriaId = v.CategoriaIdEixoAbaixado " +
                         " LEFT JOIN CategoriaVeiculos exixoSuspenso " +
                         "         ON exixoSuspenso.CategoriaId = v.CategoriaIdEixoSuspenso " +
                         " WHERE p.Rodovia LIKE @Operadora " +
                         " AND(p.Praca LIKE @RodoviaSpace OR p.Praca LIKE @RodoviaSpaceNot) " +
                         " AND(p.Praca LIKE @KmSpace OR p.Praca LIKE @KmSpaceNot) ";

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sQuery, connection))
                {

                    string RodoviaSpace = rodoviaTarifasOperadoras.RoadCode;
                    string RodoviaSpaceNot = rodoviaTarifasOperadoras.RoadCode.Replace(" ", "");

                    var KmSpaceRemove = rodoviaTarifasOperadoras.RoadEntryKm.Split("+");
                    string KmSpace = "KM " + KmSpaceRemove[0];
                    string KmSpaceNot = "KM" + KmSpaceRemove[0];


                    command.Parameters.AddWithValue("@Operadora", "%" + rodoviaTarifasOperadoras.AssociateCompKnownName + "%");
                    command.Parameters.AddWithValue("@RodoviaSpace", "%" + RodoviaSpace + "%");
                    command.Parameters.AddWithValue("@RodoviaSpaceNot", "%" + RodoviaSpaceNot + "%");
                    command.Parameters.AddWithValue("@KmSpace", "%" + KmSpace + "%");
                    command.Parameters.AddWithValue("@KmSpaceNot", "%" + KmSpaceNot + "%");


                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        bool teste = reader.HasRows;
                        while (reader.Read())
                        {

                            PassagensPedagioBuscaChaveViewsModels ListPedagioKeyViewsModels = new PassagensPedagioBuscaChaveViewsModels();
                            ListPedagioKeyViewsModels.PassagemPedagioId = reader.GetInt32(0);
                            ListPedagioKeyViewsModels.Placa = reader.GetString(1);
                            ListPedagioKeyViewsModels.Rodovia = reader.GetString(2);
                            ListPedagioKeyViewsModels.Praca = reader.GetString(3);
                            ListPedagioKeyViewsModels.Valor = reader.GetDecimal(4);
                            ListPedagioKeyViewsModels.EixoAbaixado = reader.GetInt32(5);
                            ListPedagioKeyViewsModels.ExioSuspenso = reader.GetInt32(5);
                            listaPassagensPedagioBuscaChaveViewsModels.Add(ListPedagioKeyViewsModels);

                        }
                    }
                }
            }

            return listaPassagensPedagioBuscaChaveViewsModels;

        }

        public List<RodoviaTarifasOperadoras> BuscaValoresDasTarifasPorChave(RodoviaTarifasOperadoras rodoviaTarifasOperadoras, int Eixo)
        {
            List<RodoviaTarifasOperadoras> listarodoviaTarifasOperadoras = new List<RodoviaTarifasOperadoras>();

            var sQuery = "SELECT " +
                         "   AssociateCompKnownName " +
                         "   ,RoadCode " +
                         "   ,RoadEntryKm " +
                         "   ,Descricao " +
                         "   ,Nome " +
                         "   ,Eixo " +
                         "   ,Tarifa " +
                        " FROM RodoviaTarifasOperadoras " +
                        " WHERE AssociateCompKnownName LIKE @Operadora " +
                        "AND RoadCode LIKE @Rodovia " +
                        "AND RoadEntryKm LIKE @Km " +
                        "AND Cidade LIKE @Cidade " +
                        "AND Eixo = @Eixo ";


            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sQuery, connection))
                {

                    string _cidade = rodoviaTarifasOperadoras.Cidade.Replace(" ", "");

                    command.Parameters.AddWithValue("@Operadora", "%" + rodoviaTarifasOperadoras.AssociateCompKnownName + "%");
                    command.Parameters.AddWithValue("@Rodovia", "%" + rodoviaTarifasOperadoras.RoadCode + "%");
                    command.Parameters.AddWithValue("@Km", "%" + rodoviaTarifasOperadoras.RoadEntryKm + "%");
                    command.Parameters.AddWithValue("@Cidade", "%" + _cidade + "%");
                    command.Parameters.AddWithValue("@Eixo", Eixo);


                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        bool teste = reader.HasRows;
                        while (reader.Read())
                        {

                            RodoviaTarifasOperadoras _rodoviaTarifasOperadoras = new RodoviaTarifasOperadoras();

                            _rodoviaTarifasOperadoras.AssociateCompKnownName = reader.GetString(0);
                            _rodoviaTarifasOperadoras.RoadCode = reader.GetString(1);
                            _rodoviaTarifasOperadoras.RoadEntryKm = reader.GetString(2);
                            _rodoviaTarifasOperadoras.Descricao = reader.GetString(3);
                            _rodoviaTarifasOperadoras.Nome = reader.GetString(4);
                            _rodoviaTarifasOperadoras.Eixo = reader.GetInt32(5);
                            _rodoviaTarifasOperadoras.Tarifa = reader.GetDecimal(6);
                            listarodoviaTarifasOperadoras.Add(_rodoviaTarifasOperadoras);

                        }
                    }
                }
            }

            return listarodoviaTarifasOperadoras;
        }


        


    }
}
