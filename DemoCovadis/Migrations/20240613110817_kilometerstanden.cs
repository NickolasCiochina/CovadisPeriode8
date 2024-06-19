using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoCovadis.Migrations
{
    /// <inheritdoc />
    public partial class kilometerstanden : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "beginKilometerStand",
                table: "Reservering",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "eindKilometerStand",
                table: "Reservering",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "beginKilometerStand",
                table: "Reservering");

            migrationBuilder.DropColumn(
                name: "eindKilometerStand",
                table: "Reservering");
        }
    }
}
