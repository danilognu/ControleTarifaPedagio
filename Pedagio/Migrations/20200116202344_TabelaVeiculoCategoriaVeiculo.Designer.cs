﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pedagio.Data;

namespace Pedagio.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200116202344_TabelaVeiculoCategoriaVeiculo")]
    partial class TabelaVeiculoCategoriaVeiculo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Pedagio.Data.Entities.ArquivosImportados", b =>
                {
                    b.Property<int>("ArquivoImportadoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataImportacao");

                    b.Property<string>("NomeGerado");

                    b.Property<string>("NomeOrigem");

                    b.Property<string>("PastaImportacao");

                    b.Property<int>("PessoaIdCad");

                    b.Property<int>("PessoaIdEmp");

                    b.HasKey("ArquivoImportadoId");

                    b.ToTable("ArquivosImportados");
                });

            modelBuilder.Entity("Pedagio.Data.Entities.CategoriaVeiculo", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Numero");

                    b.HasKey("CategoriaId");

                    b.ToTable("CategoriaVeiculos");
                });

            modelBuilder.Entity("Pedagio.Data.Entities.ComparacaoArquivos", b =>
                {
                    b.Property<int>("ComparacaoArquivosId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("NomeArqGerado1");

                    b.Property<string>("NomeArqGerado2");

                    b.Property<string>("NomeArqOrigem1");

                    b.Property<string>("NomeArqOrigem2");

                    b.Property<string>("PastaArquivo");

                    b.Property<int>("PessoaIdCad");

                    b.Property<int>("PessoaIdEmp");

                    b.HasKey("ComparacaoArquivosId");

                    b.ToTable("ComparacaoArquivos");
                });

            modelBuilder.Entity("Pedagio.Data.Entities.ContabilizaDesvio", b =>
                {
                    b.Property<int>("ContabilizaDesvioId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArquivoImportadoId");

                    b.Property<DateTime>("DataCad");

                    b.Property<decimal>("Desvio")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("PessoaIdCad");

                    b.Property<int>("PessoaIdEmp");

                    b.Property<string>("Placa");

                    b.Property<decimal>("ValorCredito")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("ValorPassagemValePedagio")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Viagem");

                    b.HasKey("ContabilizaDesvioId");

                    b.ToTable("ContabilizaDesvio");
                });

            modelBuilder.Entity("Pedagio.Data.Entities.Creditos", b =>
                {
                    b.Property<int>("CreditoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArquivoImportadoId");

                    b.Property<string>("Cnpj");

                    b.Property<DateTime>("Data");

                    b.Property<string>("Descricao");

                    b.Property<string>("Embarcador");

                    b.Property<DateTime>("Hora");

                    b.Property<int>("PessoaIdCad");

                    b.Property<int>("PessoaIdEmp");

                    b.Property<string>("Placa");

                    b.Property<string>("Praca");

                    b.Property<string>("Tag");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Viagem");

                    b.HasKey("CreditoId");

                    b.ToTable("Creditos");
                });

            modelBuilder.Entity("Pedagio.Data.Entities.OperacaoVeiculo", b =>
                {
                    b.Property<int>("OperacaoVeiculoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome");

                    b.Property<int>("PessoaIdCad");

                    b.Property<int>("PessoaIdEmp");

                    b.Property<int>("Status");

                    b.HasKey("OperacaoVeiculoId");

                    b.ToTable("OperacaoVeiculos");
                });

            modelBuilder.Entity("Pedagio.Data.Entities.Passagem", b =>
                {
                    b.Property<int>("PassagemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Categoria");

                    b.Property<int>("ComparacaoArquivosId");

                    b.Property<DateTime>("Data");

                    b.Property<DateTime>("DataAlt");

                    b.Property<DateTime>("DataCad");

                    b.Property<string>("Embarcado");

                    b.Property<string>("Hora");

                    b.Property<int>("NumVP");

                    b.Property<int>("PessoaIdAlt");

                    b.Property<int>("PessoaIdCad");

                    b.Property<int>("PessoaIdEmp");

                    b.Property<string>("Placa");

                    b.Property<string>("Praca");

                    b.Property<string>("Rodovia");

                    b.Property<int>("Tag");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("Viagem");

                    b.HasKey("PassagemId");

                    b.ToTable("Passagens");
                });

            modelBuilder.Entity("Pedagio.Data.Entities.PassagensPedagio", b =>
                {
                    b.Property<int>("PassagemPedagioId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArquivoImportadoId");

                    b.Property<string>("Categ");

                    b.Property<DateTime>("Data");

                    b.Property<DateTime>("Hora");

                    b.Property<string>("Marca");

                    b.Property<int>("PessoaIdCad");

                    b.Property<int>("PessoaIdEmp");

                    b.Property<string>("Placa");

                    b.Property<string>("Praca");

                    b.Property<string>("Prefixo");

                    b.Property<string>("Rodovia");

                    b.Property<string>("Tag");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("PassagemPedagioId");

                    b.ToTable("PassagensPedagios");
                });

            modelBuilder.Entity("Pedagio.Data.Entities.PassagensValePedagio", b =>
                {
                    b.Property<int>("PassagemValePedagioId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArquivoImportadoId");

                    b.Property<string>("Categ");

                    b.Property<string>("Cnpj");

                    b.Property<DateTime>("Data");

                    b.Property<string>("Embarcador");

                    b.Property<DateTime>("Hora");

                    b.Property<string>("Marca");

                    b.Property<int>("PessoaIdCad");

                    b.Property<int>("PessoaIdEmp");

                    b.Property<string>("Placa");

                    b.Property<string>("Praca");

                    b.Property<string>("Prefixo");

                    b.Property<string>("Rodovia");

                    b.Property<string>("Tag");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Viagem");

                    b.HasKey("PassagemValePedagioId");

                    b.ToTable("PassagensValePedagios");
                });

            modelBuilder.Entity("Pedagio.Data.Entities.Pessoa", b =>
                {
                    b.Property<int>("PessoaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro");

                    b.Property<int>("Cep");

                    b.Property<int>("Cnpj");

                    b.Property<DateTime>("DataCad");

                    b.Property<string>("Email");

                    b.Property<string>("Endereco");

                    b.Property<string>("Login");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("NomeFantasia");

                    b.Property<string>("Numero");

                    b.Property<int>("PessoaIdAlt");

                    b.Property<int>("PessoaIdCad");

                    b.Property<int>("PessoaIdEmp");

                    b.Property<string>("Senha");

                    b.Property<int>("Status");

                    b.Property<string>("Telefone1");

                    b.Property<string>("Telefone2");

                    b.Property<int>("TipoPessoaId");

                    b.Property<DateTime>("dataAlt");

                    b.HasKey("PessoaId");

                    b.HasIndex("TipoPessoaId");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("Pedagio.Data.Entities.Rodovia", b =>
                {
                    b.Property<int>("RodoviaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataAlt");

                    b.Property<DateTime>("DataCad");

                    b.Property<string>("NomeRodovia");

                    b.HasKey("RodoviaId");

                    b.ToTable("Rodovias");
                });

            modelBuilder.Entity("Pedagio.Data.Entities.RodoviasTarifas", b =>
                {
                    b.Property<int>("RodoviaTarifaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AssociateCompKNownName");

                    b.Property<string>("DateHourProgramStart");

                    b.Property<string>("Name");

                    b.Property<string>("Praca");

                    b.Property<int>("RodoviaId");

                    b.Property<string>("Value");

                    b.Property<string>("VehicleClassId");

                    b.HasKey("RodoviaTarifaId");

                    b.ToTable("RodoviasTarifas");
                });

            modelBuilder.Entity("Pedagio.Data.Entities.TipoPessoa", b =>
                {
                    b.Property<int>("TipoPessoaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataAlt");

                    b.Property<DateTime>("DataCad");

                    b.Property<string>("Nome");

                    b.HasKey("TipoPessoaId");

                    b.ToTable("TipoPessoas");
                });

            modelBuilder.Entity("Pedagio.Data.Entities.TipoVeiculo", b =>
                {
                    b.Property<int>("TipoVeiculoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome");

                    b.Property<int>("PessoaIdCad");

                    b.Property<int>("PessoaIdEmp");

                    b.Property<int>("Status");

                    b.HasKey("TipoVeiculoId");

                    b.ToTable("TipoVeiculos");
                });

            modelBuilder.Entity("Pedagio.Data.Entities.Veiculos", b =>
                {
                    b.Property<int>("VeiculoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoriaIdEixoAbaixado");

                    b.Property<int>("CategoriaIdEixoSuspenso");

                    b.Property<DateTime>("DataAlt");

                    b.Property<DateTime>("DataCad");

                    b.Property<string>("NomeModelo");

                    b.Property<int>("OperacaoVeiculoId");

                    b.Property<int>("PessoaIdCad");

                    b.Property<int>("PessoaIdEmp");

                    b.Property<string>("Placa");

                    b.Property<int>("Status");

                    b.Property<int>("TipoVeiculoId");

                    b.HasKey("VeiculoId");

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("Pedagio.Data.Entities.Pessoa", b =>
                {
                    b.HasOne("Pedagio.Data.Entities.TipoPessoa", "TipoPessoa")
                        .WithMany()
                        .HasForeignKey("TipoPessoaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
