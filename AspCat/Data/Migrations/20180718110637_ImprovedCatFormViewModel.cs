using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AspCat.Data.Migrations
{
    public partial class ImprovedCatFormViewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cats_Breeds_BreedId",
                table: "Cats");

            migrationBuilder.DropForeignKey(
                name: "FK_Cats_AspNetUsers_OwnerId",
                table: "Cats");

            migrationBuilder.DropIndex(
                name: "IX_Cats_BreedId",
                table: "Cats");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Cats",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "BreedId",
                table: "Cats",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BreedId1",
                table: "Cats",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cats_BreedId1",
                table: "Cats",
                column: "BreedId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cats_Breeds_BreedId1",
                table: "Cats",
                column: "BreedId1",
                principalTable: "Breeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cats_AspNetUsers_OwnerId",
                table: "Cats",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cats_Breeds_BreedId1",
                table: "Cats");

            migrationBuilder.DropForeignKey(
                name: "FK_Cats_AspNetUsers_OwnerId",
                table: "Cats");

            migrationBuilder.DropIndex(
                name: "IX_Cats_BreedId1",
                table: "Cats");

            migrationBuilder.DropColumn(
                name: "BreedId1",
                table: "Cats");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Cats",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "BreedId",
                table: "Cats",
                nullable: true,
                oldClrType: typeof(byte));

            migrationBuilder.CreateIndex(
                name: "IX_Cats_BreedId",
                table: "Cats",
                column: "BreedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cats_Breeds_BreedId",
                table: "Cats",
                column: "BreedId",
                principalTable: "Breeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cats_AspNetUsers_OwnerId",
                table: "Cats",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
