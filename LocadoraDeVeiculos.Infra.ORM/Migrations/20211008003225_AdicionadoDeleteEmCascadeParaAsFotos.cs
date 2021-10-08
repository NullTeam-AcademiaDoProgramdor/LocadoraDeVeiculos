using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeVeiculos.Infra.ORM.Migrations
{
    public partial class AdicionadoDeleteEmCascadeParaAsFotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBFoto_TBAutomovel_AutomovelId",
                table: "TBFoto");

            migrationBuilder.AddForeignKey(
                name: "FK_TBFoto_TBAutomovel_AutomovelId",
                table: "TBFoto",
                column: "AutomovelId",
                principalTable: "TBAutomovel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBFoto_TBAutomovel_AutomovelId",
                table: "TBFoto");

            migrationBuilder.AddForeignKey(
                name: "FK_TBFoto_TBAutomovel_AutomovelId",
                table: "TBFoto",
                column: "AutomovelId",
                principalTable: "TBAutomovel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
