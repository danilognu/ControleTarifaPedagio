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
    [Migration("20191112133941_TabelasPassagenseCreditos")]
    partial class TabelasPassagenseCreditos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<decimal>("Valor");

                    b.Property<int>("Viagem");

                    b.HasKey("PassagemId");

                    b.ToTable("Passagens");
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
