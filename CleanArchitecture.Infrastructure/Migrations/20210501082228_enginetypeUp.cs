using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitecture.Infrastructure.Migrations
{
    public partial class enginetypeUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AutoEngineTypeId",
                table: "AutoVersion",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AutoVersion_AutoEngineTypeId",
                table: "AutoVersion",
                column: "AutoEngineTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AutoVersion_AutoEngineType_AutoEngineTypeId",
                table: "AutoVersion",
                column: "AutoEngineTypeId",
                principalTable: "AutoEngineType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutoVersion_AutoEngineType_AutoEngineTypeId",
                table: "AutoVersion");

            migrationBuilder.DropIndex(
                name: "IX_AutoVersion_AutoEngineTypeId",
                table: "AutoVersion");

            migrationBuilder.DropColumn(
                name: "AutoEngineTypeId",
                table: "AutoVersion");
        }
    }
}
