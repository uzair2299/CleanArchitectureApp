using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitecture.Infrastructure.Migrations
{
    public partial class actionsControl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppControllerActions_AppControllers_AppControllersId",
                table: "AppControllerActions");

            migrationBuilder.DropIndex(
                name: "IX_AppControllerActions_AppControllersId",
                table: "AppControllerActions");

            migrationBuilder.DropColumn(
                name: "AppControllersId",
                table: "AppControllerActions");

            migrationBuilder.CreateIndex(
                name: "IX_AppControllerActions_ControllerId",
                table: "AppControllerActions",
                column: "ControllerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppControllerActions_AppControllers_ControllerId",
                table: "AppControllerActions",
                column: "ControllerId",
                principalTable: "AppControllers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppControllerActions_AppControllers_ControllerId",
                table: "AppControllerActions");

            migrationBuilder.DropIndex(
                name: "IX_AppControllerActions_ControllerId",
                table: "AppControllerActions");

            migrationBuilder.AddColumn<int>(
                name: "AppControllersId",
                table: "AppControllerActions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppControllerActions_AppControllersId",
                table: "AppControllerActions",
                column: "AppControllersId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppControllerActions_AppControllers_AppControllersId",
                table: "AppControllerActions",
                column: "AppControllersId",
                principalTable: "AppControllers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
