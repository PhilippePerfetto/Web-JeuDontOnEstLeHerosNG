﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JeuDontOnEstLeHerosNG.Infra.Migrations
{
    public partial class LienParagrapheReponse3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {/*
            migrationBuilder.DropForeignKey(
                name: "FK_Reponse_Paragraphe_ParagrapheId",
                table: "Reponse");

            migrationBuilder.AlterColumn<int>(
                name: "ParagrapheId",
                table: "Reponse",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Reponse_Paragraphe_ParagrapheId",
                table: "Reponse",
                column: "ParagrapheId",
                principalTable: "Paragraphe",
                principalColumn: "Id");*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {/*
            migrationBuilder.DropForeignKey(
                name: "FK_Reponse_Paragraphe_ParagrapheId",
                table: "Reponse");

            migrationBuilder.AlterColumn<int>(
                name: "ParagrapheId",
                table: "Reponse",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reponse_Paragraphe_ParagrapheId",
                table: "Reponse",
                column: "ParagrapheId",
                principalTable: "Paragraphe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);*/
        }
    }
}
