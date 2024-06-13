using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoCovadis.Migrations
{
    /// <inheritdoc />
    public partial class AlterKilomerterStand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "eindKilometerStand",
                table: "Reservering",
                newName: "EindKilometerStand");

            migrationBuilder.RenameColumn(
                name: "beginKilometerStand",
                table: "Reservering",
                newName: "BeginKilometerStand");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EindKilometerStand",
                table: "Reservering",
                newName: "eindKilometerStand");

            migrationBuilder.RenameColumn(
                name: "BeginKilometerStand",
                table: "Reservering",
                newName: "beginKilometerStand");
        }
    }
}
