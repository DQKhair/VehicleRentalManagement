using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectQLThueXe.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReceiptStatus_ID",
                table: "Receipts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CarStatus_ID",
                table: "Car",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CarStatus",
                columns: table => new
                {
                    CarStatus_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarStatusName = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarStatus", x => x.CarStatus_ID);
                });

            migrationBuilder.CreateTable(
                name: "ReceiptStatus",
                columns: table => new
                {
                    ReceiptStatus_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiptstatusName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptStatus", x => x.ReceiptStatus_ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_ReceiptStatus_ID",
                table: "Receipts",
                column: "ReceiptStatus_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Car_CarStatus_ID",
                table: "Car",
                column: "CarStatus_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_CarStatus",
                table: "Car",
                column: "CarStatus_ID",
                principalTable: "CarStatus",
                principalColumn: "CarStatus_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_ReceiptStatus",
                table: "Receipts",
                column: "ReceiptStatus_ID",
                principalTable: "ReceiptStatus",
                principalColumn: "ReceiptStatus_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_CarStatus",
                table: "Car");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_ReceiptStatus",
                table: "Receipts");

            migrationBuilder.DropTable(
                name: "CarStatus");

            migrationBuilder.DropTable(
                name: "ReceiptStatus");

            migrationBuilder.DropIndex(
                name: "IX_Receipts_ReceiptStatus_ID",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Car_CarStatus_ID",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "ReceiptStatus_ID",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "CarStatus_ID",
                table: "Car");
        }
    }
}
