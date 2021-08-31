using Microsoft.EntityFrameworkCore.Migrations;

namespace Gamestorefinal.Migrations
{
    public partial class updatelists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.AddColumn<int>(
                name: "OrderClientId",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrdereSupplierId",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_OrderClientId",
                table: "Games",
                column: "OrderClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_OrdereSupplierId",
                table: "Games",
                column: "OrdereSupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_OrderClient_OrderClientId",
                table: "Games",
                column: "OrderClientId",
                principalTable: "OrderClient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_OrdereSupplier_OrdereSupplierId",
                table: "Games",
                column: "OrdereSupplierId",
                principalTable: "OrdereSupplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_OrderClient_OrderClientId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_OrdereSupplier_OrdereSupplierId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_OrderClientId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_OrdereSupplierId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "OrderClientId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "OrdereSupplierId",
                table: "Games");

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: true),
                    OrderClientId = table.Column<int>(type: "int", nullable: true),
                    OrdereSupplierId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_OrderClient_OrderClientId",
                        column: x => x.OrderClientId,
                        principalTable: "OrderClient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_OrdereSupplier_OrdereSupplierId",
                        column: x => x.OrdereSupplierId,
                        principalTable: "OrdereSupplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_GameId",
                table: "Order",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderClientId",
                table: "Order",
                column: "OrderClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrdereSupplierId",
                table: "Order",
                column: "OrdereSupplierId");
        }
    }
}
