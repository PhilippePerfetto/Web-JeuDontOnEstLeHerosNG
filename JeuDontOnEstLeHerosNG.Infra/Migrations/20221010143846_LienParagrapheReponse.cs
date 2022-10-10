using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JeuDontOnEstLeHerosNG.Infra.Migrations
{
    public partial class LienParagrapheReponse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {/*
            migrationBuilder.CreateIndex(
                name: "IX_Reponse_ParagrapheId",
                table: "Reponse",
                column: "ParagrapheId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reponse_Paragraphe_ParagrapheId",
                table: "Reponse",
                column: "ParagrapheId",
                principalTable: "Paragraphe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {/*
            migrationBuilder.DropForeignKey(
                name: "FK_Reponse_Paragraphe_ParagrapheId",
                table: "Reponse");

            migrationBuilder.DropIndex(
                name: "IX_Reponse_ParagrapheId",
                table: "Reponse");*/
        }
    }
}
