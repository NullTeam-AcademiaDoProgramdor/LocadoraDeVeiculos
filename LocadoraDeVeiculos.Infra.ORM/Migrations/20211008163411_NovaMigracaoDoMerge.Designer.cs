﻿// <auto-generated />
using System;
using LocadoraDeVeiculos.Infra.ORM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LocadoraDeVeiculos.Infra.ORM.Migrations
{
    [DbContext(typeof(DBLocadoraContext))]
    [Migration("20211008163411_NovaMigracaoDoMerge")]
    partial class NovaMigracaoDoMerge
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.AutomovelModule.Automovel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<int>("Cambio")
                        .HasColumnType("int");

                    b.Property<int>("CapacidadeTanque")
                        .HasColumnType("int");

                    b.Property<string>("Chassi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Direcao")
                        .HasColumnType("int");

                    b.Property<int?>("GrupoId")
                        .HasColumnType("int");

                    b.Property<int>("KmRegistrada")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Portas")
                        .HasColumnType("int");

                    b.Property<int>("TamanhoPortaMalas")
                        .HasColumnType("int");

                    b.Property<int>("TipoCombustivel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GrupoId");

                    b.ToTable("TBAutomovel");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.CupomModule.Cupom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ParceiroId")
                        .HasColumnType("int");

                    b.Property<int>("QtdUsos")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.Property<double>("ValorMinimo")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ParceiroId");

                    b.ToTable("TBCupom");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.FotoModule.Foto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AutomovelId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Imagem")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("AutomovelId");

                    b.ToTable("TBFoto");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.GrupoAutomovelModule.GrupoAutomovel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlanoDiario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlanoKmControlado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlanoKmLivre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TBGrupoAutomovel");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ParceiroModule.Parceiro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("Id");

                    b.ToTable("TBParceiro");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.PessoaJuridicaModule.PessoaJuridica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TBPessoaJuridica");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.AutomovelModule.Automovel", b =>
                {
                    b.HasOne("LocadoraDeVeiculos.Dominio.GrupoAutomovelModule.GrupoAutomovel", "Grupo")
                        .WithMany()
                        .HasForeignKey("GrupoId");

                    b.Navigation("Grupo");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.CupomModule.Cupom", b =>
                {
                    b.HasOne("LocadoraDeVeiculos.Dominio.ParceiroModule.Parceiro", "Parceiro")
                        .WithMany()
                        .HasForeignKey("ParceiroId");

                    b.Navigation("Parceiro");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.FotoModule.Foto", b =>
                {
                    b.HasOne("LocadoraDeVeiculos.Dominio.AutomovelModule.Automovel", null)
                        .WithMany("Fotos")
                        .HasForeignKey("AutomovelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.AutomovelModule.Automovel", b =>
                {
                    b.Navigation("Fotos");
                });
#pragma warning restore 612, 618
        }
    }
}
