using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JeuDontOnEstLeHerosNG.Infra.Migrations
{
    public partial class LiensParagrapheReponse4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {/*
            migrationBuilder.DropForeignKey(
                name: "FK_Reponse_Paragraphe_ParagrapheId",
                table: "Reponse");

            migrationBuilder.DropIndex(
                name: "IX_Reponse_ParagrapheId",
                table: "Reponse");

            migrationBuilder.DropColumn(
                name: "ParagrapheId",
                table: "Reponse");*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {/*
            migrationBuilder.AddColumn<int>(
                name: "ParagrapheId",
                table: "Reponse",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reponse_ParagrapheId",
                table: "Reponse",
                column: "ParagrapheId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reponse_Paragraphe_ParagrapheId",
                table: "Reponse",
                column: "ParagrapheId",
                principalTable: "Paragraphe",
                principalColumn: "Id");*/
        }
    }
}
