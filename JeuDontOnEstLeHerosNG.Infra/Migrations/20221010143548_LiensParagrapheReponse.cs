using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JeuDontOnEstLeHerosNG.Infra.Migrations
{
    public partial class LiensParagrapheReponse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParagrapheId",
                table: "Reponse",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParagrapheId",
                table: "Reponse");
        }
    }
}
