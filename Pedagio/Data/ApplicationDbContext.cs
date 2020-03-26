using Microsoft.EntityFrameworkCore;
using Pedagio.Data.Entities;

namespace Pedagio.Data
{
    public class ApplicationDbContext : DbContext
    {

        //Ver como Apagar
        public DbSet<Passagem> Passagens { get; set; }
        public DbSet<ComparacaoArquivos> ComparacaoArquivos { get; set; }

        //Em utlização
        public DbSet<TipoPessoa> TipoPessoas { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<PassagensPedagio> PassagensPedagios { get; set; }
        public DbSet<PassagensValePedagio> PassagensValePedagios { get; set; }
        public DbSet<Creditos> Creditos { get; set; }
        public DbSet<ArquivosImportados> ArquivosImportados { get; set; }
        public DbSet<ContabilizaDesvio> ContabilizaDesvio { get; set; }
        public DbSet<Veiculos> Veiculos { get; set; }
        public DbSet<TipoVeiculo> TipoVeiculos { get; set; }
        public DbSet<OperacaoVeiculo> OperacaoVeiculos { get; set; }
        public DbSet<Rodovia> Rodovias { get; set; }
        public DbSet<RodoviasTarifas> RodoviasTarifas { get; set; }
        public DbSet<CategoriaVeiculo> CategoriaVeiculos { get; set; }
        public DbSet<RodoviaTarifasOperadoras> RodoviaTarifasOperadoras { get; set; }

        /*
         > dotnet ef migrations add NomeMigration 
         > dotnet ef database update NomeMigration
        */
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFQuerying;Trusted_Connection=True;ConnectRetryCount=0");
        }*/

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

    }
}
