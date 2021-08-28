using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitecture.Infrastructure.Migrations
{
    public partial class dd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutoVersionSpecifications",
                columns: table => new
                {
                    AutoVersionId = table.Column<int>(type: "int", nullable: false),
                    AutoSpecificationId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoVersionSpecifications", x => new { x.AutoVersionId, x.AutoSpecificationId });
                    table.ForeignKey(
                        name: "FK_AutoVersionSpecifications_AutoSpecifications_AutoSpecificationId",
                        column: x => x.AutoSpecificationId,
                        principalTable: "AutoSpecifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutoVersionSpecifications_AutoVersion_AutoVersionId",
                        column: x => x.AutoVersionId,
                        principalTable: "AutoVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutoVersionSpecifications_AutoSpecificationId",
                table: "AutoVersionSpecifications",
                column: "AutoSpecificationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutoVersionSpecifications");
        }
    }
}
