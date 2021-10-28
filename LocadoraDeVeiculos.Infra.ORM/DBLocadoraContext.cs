using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using LocadoraDeVeiculos.Dominio.AutomovelModule;
using LocadoraDeVeiculos.Dominio.CupomModule;
using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using LocadoraDeVeiculos.Dominio.GrupoAutomovelModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Dominio.TaxasEServicosModule;
using LocadoraDeVeiculos.Dominio.PessoaFisicaModule;
using LocadoraDeVeiculos.Dominio.PessoaJuridicaModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using LocadoraDeVeiculos.Dominio.RequisicaoEmailModule;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using Microsoft.Extensions.Logging;
using Serilog.Extensions.Logging;
using Serilog;
using System.Reflection;

#nullable disable

namespace LocadoraDeVeiculos.Infra.ORM.Models
{
    public class DBLocadoraContext : DbContext
    {
        private string connectionString;

        private static ILoggerFactory loggerFactorySerilog =
            LoggerFactory.Create(builder =>
            {
                builder
                .AddSerilog()
                .AddFilter((category, level) =>
                        category == DbLoggerCategory.Database.Command.Name
                        && level == LogLevel.Information);
            });

        public DbSet<Automovel> Automoveis { get; set; }
        public DbSet<GrupoAutomovel> GruposAutomovel { get; set; }
        public DbSet<Parceiro> Parceiros { get; set; }
        public DbSet<TaxaEServico> TaxasEServicos { get; set; }
        public DbSet<Cupom> Cupons { get; set; }
        public DbSet<PessoaJuridica> PessoasJuridicas { get; set; }
        public DbSet<PessoaFisica> PessoasFisicas { get; set; }
        public DbSet<RequisicaoEmail> RequisicaoEmails { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

        public DBLocadoraContext()
        {
            IConfiguration configuration =
                new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .AddJsonFile("appsettings.json")
                .Build();

            string bancoDeDados = configuration.GetSection("bancoDeDados").Value;

            connectionString = configuration.GetConnectionString(bancoDeDados);

            //if (Database.GetPendingMigrations().Any())
            //    Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(loggerFactorySerilog)
                .UseLazyLoadingProxies()
                .UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DBLocadoraContext).Assembly);
        }
    }
}
