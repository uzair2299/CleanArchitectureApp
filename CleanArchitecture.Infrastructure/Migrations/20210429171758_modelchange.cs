using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitecture.Infrastructure.Migrations
{
    public partial class modelchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartProductionDate",
                table: "AutoVersion",
                newName: "StartProductionYear");

            migrationBuilder.RenameColumn(
                name: "EndProductionDate",
                table: "AutoVersion",
                newName: "EndProductionYear");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartProductionYear",
                table: "AutoVersion",
                newName: "StartProductionDate");

            migrationBuilder.RenameColumn(
                name: "EndProductionYear",
                table: "AutoVersion",
                newName: "EndProductionDate");
        }
    }
}
