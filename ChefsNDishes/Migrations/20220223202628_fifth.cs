using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChefsNDishes.Migrations
{
    public partial class fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Chefs",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Chefs",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
