using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectQLThueXe.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarType",
                columns: table => new
                {
                    CarType_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarType", x => x.CarType_ID);
                });

            migrationBuilder.CreateTable(
                name: "KCT",
                columns: table => new
                {
                    KCT_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KCT_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KCT_Phone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    KCT_address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    KCT_CCCD = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KCT", x => x.KCT_ID);
                });

            migrationBuilder.CreateTable(
                name: "KT",
                columns: table => new
                {
                    KT_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KT_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KT_Phone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    KT_Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    KT_CCCD = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KT", x => x.KT_ID);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Car_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarType_ID = table.Column<int>(type: "int", nullable: true),
                    KCT_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Car_ID);
                    table.ForeignKey(
                        name: "FK_Car_CarType",
                        column: x => x.CarType_ID,
                        principalTable: "CarType",
                        principalColumn: "CarType_ID");
                    table.ForeignKey(
                        name: "FK_Car_KCT",
                        column: x => x.KCT_ID,
                        principalTable: "KCT",
                        principalColumn: "KCT_ID");
                });

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    Receipt_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    totalMoney = table.Column<double>(type: "float", nullable: false),
                    TimeStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalDay = table.Column<int>(type: "int", nullable: false),
                    ReceiptTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KT_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.Receipt_ID);
                    table.ForeignKey(
                        name: "FK_Receipts_KT",
                        column: x => x.KT_ID,
                        principalTable: "KT",
                        principalColumn: "KT_ID");
                });

            migrationBuilder.CreateTable(
                name: "ReceiptDetail",
                columns: table => new
                {
                    ReceiptDetail_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Car_model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Car_Price = table.Column<double>(type: "float", nullable: false),
                    Car_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Receipt_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptDetail", x => x.ReceiptDetail_ID);
                    table.ForeignKey(
                        name: "FK_ReceiptDetail_Car",
                        column: x => x.Car_ID,
                        principalTable: "Car",
                        principalColumn: "Car_ID");
                    table.ForeignKey(
                        name: "FK_ReceiptDetail_Receipts",
                        column: x => x.Receipt_ID,
                        principalTable: "Receipts",
                        principalColumn: "Receipt_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_CarType_ID",
                table: "Car",
                column: "CarType_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Car_KCT_ID",
                table: "Car",
                column: "KCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptDetail_Car_ID",
                table: "ReceiptDetail",
                column: "Car_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptDetail_Receipt_ID",
                table: "ReceiptDetail",
                column: "Receipt_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_KT_ID",
                table: "Receipts",
                column: "KT_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReceiptDetail");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropTable(
                name: "CarType");

            migrationBuilder.DropTable(
                name: "KCT");

            migrationBuilder.DropTable(
                name: "KT");
        }
    }
}
