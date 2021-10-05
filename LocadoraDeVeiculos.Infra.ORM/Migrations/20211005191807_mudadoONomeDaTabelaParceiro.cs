using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeVeiculos.Infra.ORM.Migrations
{
    public partial class mudadoONomeDaTabelaParceiro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBCupom_Parceiro_ParceiroId",
                table: "TBCupom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parceiro",
                table: "Parceiro");

            migrationBuilder.RenameTable(
                name: "Parceiro",
                newName: "TBParceiro");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "TBParceiro",
                type: "VARCHAR(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TBParceiro",
                table: "TBParceiro",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBCupom_TBParceiro_ParceiroId",
                table: "TBCupom",
                column: "ParceiroId",
                principalTable: "TBParceiro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBCupom_TBParceiro_ParceiroId",
                table: "TBCupom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TBParceiro",
                table: "TBParceiro");

            migrationBuilder.RenameTable(
                name: "TBParceiro",
                newName: "Parceiro");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Parceiro",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parceiro",
                table: "Parceiro",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBCupom_Parceiro_ParceiroId",
                table: "TBCupom",
                column: "ParceiroId",
                principalTable: "Parceiro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
