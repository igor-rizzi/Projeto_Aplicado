using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjAplicado.Data.Migrations
{
    public partial class removeAttVaga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Habilidades",
                table: "Vagas");

            migrationBuilder.DropColumn(
                name: "Requisitos",
                table: "Vagas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Habilidades",
                table: "Vagas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Requisitos",
                table: "Vagas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
