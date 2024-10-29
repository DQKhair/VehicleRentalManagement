using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectQLThueXe.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateColCar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NumberPlate",
                table: "Car",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberPlate",
                table: "Car");
        }
    }
}
