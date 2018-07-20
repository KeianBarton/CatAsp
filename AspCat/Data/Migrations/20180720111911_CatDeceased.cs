using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AspCat.Data.Migrations
{
    public partial class CatDeceased : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeathDate",
                table: "Cats",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeceased",
                table: "Cats",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeathDate",
                table: "Cats");

            migrationBuilder.DropColumn(
                name: "IsDeceased",
                table: "Cats");
        }
    }
}
