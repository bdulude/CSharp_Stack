using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChefsNDishes.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Chefs");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Chefs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Chefs");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Chefs",
                type: "datetime(6)",
                nullable: true);
        }
    }
}
