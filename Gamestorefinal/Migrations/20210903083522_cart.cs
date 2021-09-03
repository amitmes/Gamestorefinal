using Microsoft.EntityFrameworkCore.Migrations;

namespace Gamestorefinal.Migrations
{
    public partial class cart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_ClientId",
                table: "Games",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Client_ClientId",
                table: "Games",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Client_ClientId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_ClientId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Games");
        }
    }
}
