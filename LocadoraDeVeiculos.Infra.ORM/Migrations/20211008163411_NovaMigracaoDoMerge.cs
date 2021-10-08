using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeVeiculos.Infra.ORM.Migrations
{
    public partial class NovaMigracaoDoMerge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBGrupoAutomovel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlanoDiario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlanoKmControlado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlanoKmLivre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBGrupoAutomovel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBParceiro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBParceiro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBPessoaJuridica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Cnpj = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPessoaJuridica", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBAutomovel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Chassi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Portas = table.Column<int>(type: "int", nullable: false),
                    CapacidadeTanque = table.Column<int>(type: "int", nullable: false),
                    TamanhoPortaMalas = table.Column<int>(type: "int", nullable: false),
                    KmRegistrada = table.Column<int>(type: "int", nullable: false),
                    TipoCombustivel = table.Column<int>(type: "int", nullable: false),
                    Cambio = table.Column<int>(type: "int", nullable: false),
                    Direcao = table.Column<int>(type: "int", nullable: false),
                    GrupoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAutomovel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBAutomovel_TBGrupoAutomovel_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "TBGrupoAutomovel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBCupom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    ParceiroId = table.Column<int>(type: "int", nullable: true),
                    Tipo = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    ValorMinimo = table.Column<double>(type: "float", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QtdUsos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCupom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBCupom_TBParceiro_ParceiroId",
                        column: x => x.ParceiroId,
                        principalTable: "TBParceiro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBFoto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imagem = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    AutomovelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBFoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBFoto_TBAutomovel_AutomovelId",
                        column: x => x.AutomovelId,
                        principalTable: "TBAutomovel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBAutomovel_GrupoId",
                table: "TBAutomovel",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBCupom_ParceiroId",
                table: "TBCupom",
                column: "ParceiroId");

            migrationBuilder.CreateIndex(
                name: "IX_TBFoto_AutomovelId",
                table: "TBFoto",
                column: "AutomovelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBCupom");

            migrationBuilder.DropTable(
                name: "TBFoto");

            migrationBuilder.DropTable(
                name: "TBPessoaJuridica");

            migrationBuilder.DropTable(
                name: "TBParceiro");

            migrationBuilder.DropTable(
                name: "TBAutomovel");

            migrationBuilder.DropTable(
                name: "TBGrupoAutomovel");
        }
    }
}
