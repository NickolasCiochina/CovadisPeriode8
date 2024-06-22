using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoCovadis.Migrations
{
    /// <inheritdoc />
    public partial class ChauffeursTabelChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Naam",
                table: "Chauffeur",
                newName: "Voornaam");

            migrationBuilder.RenameColumn(
                name: "EindAdres",
                table: "Chauffeur",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "BeginAdres",
                table: "Chauffeur",
                newName: "Achternaam");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Voornaam",
                table: "Chauffeur",
                newName: "Naam");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Chauffeur",
                newName: "EindAdres");

            migrationBuilder.RenameColumn(
                name: "Achternaam",
                table: "Chauffeur",
                newName: "BeginAdres");
        }
    }
}
