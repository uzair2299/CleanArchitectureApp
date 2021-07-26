using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitecture.Infrastructure.Migrations
{
    public partial class sub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutoSpecificationSubs_AutoSpecifications_AutoSpecificationId",
                table: "AutoSpecificationSubs");

            migrationBuilder.DropIndex(
                name: "IX_AutoSpecificationSubs_AutoSpecificationId",
                table: "AutoSpecificationSubs");

            migrationBuilder.DropColumn(
                name: "AutoSpecificationId",
                table: "AutoSpecificationSubs");

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "AutoSpecifications",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AutoSpecifications_ParentId",
                table: "AutoSpecifications",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AutoSpecifications_AutoSpecifications_ParentId",
                table: "AutoSpecifications",
                column: "ParentId",
                principalTable: "AutoSpecifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutoSpecifications_AutoSpecifications_ParentId",
                table: "AutoSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_AutoSpecifications_ParentId",
                table: "AutoSpecifications");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "AutoSpecifications");

            migrationBuilder.AddColumn<int>(
                name: "AutoSpecificationId",
                table: "AutoSpecificationSubs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AutoSpecificationSubs_AutoSpecificationId",
                table: "AutoSpecificationSubs",
                column: "AutoSpecificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AutoSpecificationSubs_AutoSpecifications_AutoSpecificationId",
                table: "AutoSpecificationSubs",
                column: "AutoSpecificationId",
                principalTable: "AutoSpecifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
