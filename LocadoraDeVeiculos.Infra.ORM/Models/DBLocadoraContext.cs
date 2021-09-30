using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LocadoraDeVeiculos.Infra.ORM.Models
{
    public partial class DBLocadoraContext : DbContext
    {
        public DBLocadoraContext()
        {
        }

        public DBLocadoraContext(DbContextOptions<DBLocadoraContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Automovel> Automovels { get; set; }
        public virtual DbSet<Cupom> Cupoms { get; set; }
        public virtual DbSet<FotoAutomovel> FotoAutomovels { get; set; }
        public virtual DbSet<Funcionario> Funcionarios { get; set; }
        public virtual DbSet<GrupoAutomovel> GrupoAutomovels { get; set; }
        public virtual DbSet<Locacao> Locacaos { get; set; }
        public virtual DbSet<Parceiro> Parceiros { get; set; }
        public virtual DbSet<PessoaFisica> PessoaFisicas { get; set; }
        public virtual DbSet<PessoaJuridica> PessoaJuridicas { get; set; }
        public virtual DbSet<RequisicaoEmail> RequisicaoEmails { get; set; }
        public virtual DbSet<TaxaEservico> TaxaEservicos { get; set; }
        public virtual DbSet<TaxasEservicosUsada> TaxasEservicosUsadas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=DBLocadora;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Automovel>(entity =>
            {
                entity.ToTable("Automovel");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ano).HasColumnName("ano");

                entity.Property(e => e.Cambio)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cambio");

                entity.Property(e => e.CapacidadePortaMalas).HasColumnName("capacidadePortaMalas");

                entity.Property(e => e.CapacidadeTanque).HasColumnName("capacidadeTanque");

                entity.Property(e => e.Chassi)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("chassi");

                entity.Property(e => e.Cor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cor");

                entity.Property(e => e.Direcao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("direcao");

                entity.Property(e => e.Grupo).HasColumnName("grupo");

                entity.Property(e => e.KmRegistrada).HasColumnName("kmRegistrada");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("marca");

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("modelo");

                entity.Property(e => e.NPortas).HasColumnName("n_portas");

                entity.Property(e => e.Placa)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("placa");

                entity.Property(e => e.TipoCombustivel)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipoCombustivel");

                entity.HasOne(d => d.GrupoNavigation)
                    .WithMany(p => p.Automovels)
                    .HasForeignKey(d => d.Grupo)
                    .HasConstraintName("FK_Automovel_GrupoAutomoveis");
            });

            modelBuilder.Entity<Cupom>(entity =>
            {
                entity.ToTable("Cupom");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("codigo");

                entity.Property(e => e.DataVencimento)
                    .HasColumnType("datetime")
                    .HasColumnName("dataVencimento");

                entity.Property(e => e.Parceiro).HasColumnName("parceiro");

                entity.Property(e => e.QtdUsos).HasColumnName("qtdUsos");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipo");

                entity.Property(e => e.Valor).HasColumnName("valor");

                entity.Property(e => e.ValorMinimo).HasColumnName("valorMinimo");

                entity.HasOne(d => d.ParceiroNavigation)
                    .WithMany(p => p.Cupoms)
                    .HasForeignKey(d => d.Parceiro)
                    .HasConstraintName("FK_Cupom_Parceiro");
            });

            modelBuilder.Entity<FotoAutomovel>(entity =>
            {
                entity.ToTable("FotoAutomovel");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Automovel).HasColumnName("automovel");

                entity.Property(e => e.Foto)
                    .IsRequired()
                    .HasColumnType("image")
                    .HasColumnName("foto");

                entity.HasOne(d => d.AutomovelNavigation)
                    .WithMany(p => p.FotoAutomovels)
                    .HasForeignKey(d => d.Automovel)
                    .HasConstraintName("FK_FotoAutomovel_Automovel");
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.ToTable("Funcionario");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DataDeEntrada)
                    .HasColumnType("datetime")
                    .HasColumnName("dataDeEntrada");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Salario).HasColumnName("salario");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("senha");
            });

            modelBuilder.Entity<GrupoAutomovel>(entity =>
            {
                entity.ToTable("GrupoAutomovel");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.PlanoDiarioPrecoDia).HasColumnName("planoDIario_precoDIa");

                entity.Property(e => e.PlanoDiarioPrecoKm).HasColumnName("planoDiario_precoKm");

                entity.Property(e => e.PlanoKmControladoKmDisponiveis).HasColumnName("planoKmControlado_KmDisponiveis");

                entity.Property(e => e.PlanoKmControladoPrecoDia).HasColumnName("planoKmControlado_precoDia");

                entity.Property(e => e.PlanoKmControladoPrecoKmExtrapolado).HasColumnName("planoKmControlado_precoKmExtrapolado");

                entity.Property(e => e.PlanoKmLivrePrecoDia).HasColumnName("planoKmLivre_precoDia");
            });

            modelBuilder.Entity<Locacao>(entity =>
            {
                entity.ToTable("Locacao");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Automovel).HasColumnName("automovel");

                entity.Property(e => e.Caucao).HasColumnName("caucao");

                entity.Property(e => e.Condutor).HasColumnName("condutor");

                entity.Property(e => e.Cupom).HasColumnName("cupom");

                entity.Property(e => e.DataDevolucao)
                    .HasColumnType("datetime")
                    .HasColumnName("dataDevolucao");

                entity.Property(e => e.DataDevolucaoEsperada)
                    .HasColumnType("datetime")
                    .HasColumnName("dataDevolucaoEsperada");

                entity.Property(e => e.DataSaida)
                    .HasColumnType("datetime")
                    .HasColumnName("dataSaida");

                entity.Property(e => e.Funcionario).HasColumnName("funcionario");

                entity.Property(e => e.KmAutomovelFinal).HasColumnName("kmAutomovelFinal");

                entity.Property(e => e.KmRegistrada).HasColumnName("kmRegistrada");

                entity.Property(e => e.PlanoSelecionado).HasColumnName("planoSelecionado");

                entity.Property(e => e.PorcentagemFinalCombustivel).HasColumnName("porcentagemFinalCombustivel");

                entity.HasOne(d => d.AutomovelNavigation)
                    .WithMany(p => p.Locacaos)
                    .HasForeignKey(d => d.Automovel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Locacao_Automovel");

                entity.HasOne(d => d.CondutorNavigation)
                    .WithMany(p => p.Locacaos)
                    .HasForeignKey(d => d.Condutor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Locacao_PessoaFisica");

                entity.HasOne(d => d.CupomNavigation)
                    .WithMany(p => p.Locacaos)
                    .HasForeignKey(d => d.Cupom)
                    .HasConstraintName("FK_Locacao_Cupom");

                entity.HasOne(d => d.FuncionarioNavigation)
                    .WithMany(p => p.Locacaos)
                    .HasForeignKey(d => d.Funcionario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Locacao_Funcionario");
            });

            modelBuilder.Entity<Parceiro>(entity =>
            {
                entity.ToTable("Parceiro");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<PessoaFisica>(entity =>
            {
                entity.ToTable("PessoaFisica");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cnh)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cnh");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cpf");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.EmpresaLigada).HasColumnName("empresaLigada");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("endereco");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("rg");

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefone");

                entity.Property(e => e.VencimentoCnh)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("vencimentoCnh");

                entity.HasOne(d => d.EmpresaLigadaNavigation)
                    .WithMany(p => p.PessoaFisicas)
                    .HasForeignKey(d => d.EmpresaLigada)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_PessoaFisica_PessoaJuridica");
            });

            modelBuilder.Entity<PessoaJuridica>(entity =>
            {
                entity.ToTable("PessoaJuridica");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cnpj");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("endereco");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefone");
            });

            modelBuilder.Entity<RequisicaoEmail>(entity =>
            {
                entity.ToTable("RequisicaoEmail");

                entity.Property(e => e.EmailDestino)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("emailDestino");

                entity.Property(e => e.Mensagem)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("mensagem");

                entity.Property(e => e.NomePdf)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("nomePdf");
            });

            modelBuilder.Entity<TaxaEservico>(entity =>
            {
                entity.ToTable("TaxaEServico");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EhFixo).HasColumnName("ehFixo");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Preco).HasColumnName("preco");
            });

            modelBuilder.Entity<TaxasEservicosUsada>(entity =>
            {
                entity.ToTable("TaxasEServicosUsadas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Locacao).HasColumnName("locacao");

                entity.Property(e => e.TaxaEservico).HasColumnName("taxaEServico");

                entity.HasOne(d => d.LocacaoNavigation)
                    .WithMany(p => p.TaxasEservicosUsada)
                    .HasForeignKey(d => d.Locacao)
                    .HasConstraintName("FK_TaxasEServicosUsadas_Locacao");

                entity.HasOne(d => d.TaxaEservicoNavigation)
                    .WithMany(p => p.TaxasEservicosUsada)
                    .HasForeignKey(d => d.TaxaEservico)
                    .HasConstraintName("FK_TaxasEServicosUsadas_TaxaEServico");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
