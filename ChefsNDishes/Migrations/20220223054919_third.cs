using Microsoft.EntityFrameworkCore.Migrations;

namespace ChefsNDishes.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Chefs_ChefId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_ChefId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "ChefId",
                table: "Dishes");

            migrationBuilder.AddColumn<int>(
                name: "ChefId1",
                table: "Dishes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_ChefId1",
                table: "Dishes",
                column: "ChefId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Chefs_ChefId1",
                table: "Dishes",
                column: "ChefId1",
                principalTable: "Chefs",
                principalColumn: "ChefId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Chefs_ChefId1",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_ChefId1",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "ChefId1",
                table: "Dishes");

            migrationBuilder.AddColumn<int>(
                name: "ChefId",
                table: "Dishes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_ChefId",
                table: "Dishes",
                column: "ChefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Chefs_ChefId",
                table: "Dishes",
                column: "ChefId",
                principalTable: "Chefs",
                principalColumn: "ChefId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
