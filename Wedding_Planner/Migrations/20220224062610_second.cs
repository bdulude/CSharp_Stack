using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding_Planner.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "Weddings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Weddings_CreatorId",
                table: "Weddings",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weddings_Users_CreatorId",
                table: "Weddings",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weddings_Users_CreatorId",
                table: "Weddings");

            migrationBuilder.DropIndex(
                name: "IX_Weddings_CreatorId",
                table: "Weddings");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Weddings");
        }
    }
}
