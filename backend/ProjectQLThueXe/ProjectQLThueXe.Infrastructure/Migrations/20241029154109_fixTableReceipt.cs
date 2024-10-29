using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectQLThueXe.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixTableReceipt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeEnd",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "TimeStart",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "TotalDay",
                table: "Receipts");

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeEnd",
                table: "ReceiptDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStart",
                table: "ReceiptDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TotalDay",
                table: "ReceiptDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeEnd",
                table: "ReceiptDetail");

            migrationBuilder.DropColumn(
                name: "TimeStart",
                table: "ReceiptDetail");

            migrationBuilder.DropColumn(
                name: "TotalDay",
                table: "ReceiptDetail");

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeEnd",
                table: "Receipts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStart",
                table: "Receipts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TotalDay",
                table: "Receipts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
