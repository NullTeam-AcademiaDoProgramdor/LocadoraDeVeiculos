using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using LocadoraDeVeiculos.Dominio.CupomModule;
using LocadoraDeVeiculos.Dominio.GrupoAutomovelModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Dominio.TaxasEServicosModule;
using LocadoraDeVeiculos.Dominio.PessoaJuridicaModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using LocadoraDeVeiculos.Dominio.RequisicaoEmailModule;

#nullable disable

namespace LocadoraDeVeiculos.Infra.ORM.Models
{
    public class DBLocadoraContext : DbContext
    {
        private string connectionString;

        public DbSet<GrupoAutomovel> GruposAutomovel { get; set; }
        public DbSet<Parceiro> Parceiros { get; set; }
        public DbSet<TaxaEServico> TaxasEServicos { get; set; }
        public DbSet<Cupom> Cupons { get; set; }
        public DbSet<Cupom> Cupoms { get; set; }
        public DbSet<PessoaJuridica> PessoasJuridicas { get; set; }
        public DbSet<RequisicaoEmail> RequisicaoEmails { get; set; }

        public DBLocadoraContext()
        {
            IConfiguration configuration = 
                new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .SetBasePath(Directory.GetCurrentDirectory())
                .Build();

            string bancoDeDados = configuration.GetSection("bancoDeDados").Value;

            connectionString = configuration.GetConnectionString(bancoDeDados);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DBLocadoraContext).Assembly);          
        }
    }
}
