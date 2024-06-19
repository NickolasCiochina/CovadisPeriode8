using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoCovadis.Migrations
{
    /// <inheritdoc />
    public partial class adminRoleAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
                migrationBuilder.InsertData(
                   table: "RoleUser",
                   columns: new[] { "RolesId", "UsersId" },
                   values: new object[,]
                   {
                       { 1, 1 },
                       { 2, 2 }
                   }
                   ); 
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
