using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectQLThueXe.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColReceipt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReceiptDescription",
                table: "Receipts",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiptDescription",
                table: "Receipts");
        }
    }
}
