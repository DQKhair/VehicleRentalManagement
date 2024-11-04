using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectQLThueXe.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColCarAndKT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "KT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "URLImage",
                table: "Car",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "locationX",
                table: "Car",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "locationY",
                table: "Car",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "KT");

            migrationBuilder.DropColumn(
                name: "URLImage",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "locationX",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "locationY",
                table: "Car");
        }
    }
}
