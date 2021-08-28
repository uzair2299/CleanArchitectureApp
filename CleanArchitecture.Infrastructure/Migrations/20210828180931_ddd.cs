using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitecture.Infrastructure.Migrations
{
    public partial class ddd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutoVersion_AutoBodyType_AutoBodyTypeId",
                table: "AutoVersion");

            migrationBuilder.AlterColumn<int>(
                name: "AutoBodyTypeId",
                table: "AutoVersion",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AutoVersion_AutoBodyType_AutoBodyTypeId",
                table: "AutoVersion",
                column: "AutoBodyTypeId",
                principalTable: "AutoBodyType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutoVersion_AutoBodyType_AutoBodyTypeId",
                table: "AutoVersion");

            migrationBuilder.AlterColumn<int>(
                name: "AutoBodyTypeId",
                table: "AutoVersion",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AutoVersion_AutoBodyType_AutoBodyTypeId",
                table: "AutoVersion",
                column: "AutoBodyTypeId",
                principalTable: "AutoBodyType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
