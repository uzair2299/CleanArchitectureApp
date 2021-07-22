using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitecture.Infrastructure.Migrations
{
    public partial class dimension : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutoVersionDimension",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExteriorLength = table.Column<int>(type: "int", nullable: false),
                    ExteriorWidth = table.Column<int>(type: "int", nullable: false),
                    ExteriorHeight = table.Column<int>(type: "int", nullable: false),
                    InteriorLength = table.Column<int>(type: "int", nullable: false),
                    InteriorWidth = table.Column<int>(type: "int", nullable: false),
                    InteriorHeight = table.Column<int>(type: "int", nullable: false),
                    Wheelbase = table.Column<int>(type: "int", nullable: false),
                    MinimumGroundClearance = table.Column<int>(type: "int", nullable: false),
                    TreadFront = table.Column<int>(type: "int", nullable: false),
                    TreadRear = table.Column<int>(type: "int", nullable: false),
                    OverhangFront = table.Column<int>(type: "int", nullable: false),
                    OverhangRear = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutoVersionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoVersionDimension", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutoVersionDimension_AutoVersion_AutoVersionId",
                        column: x => x.AutoVersionId,
                        principalTable: "AutoVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutoVersionDimension_AutoVersionId",
                table: "AutoVersionDimension",
                column: "AutoVersionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutoVersionDimension");
        }
    }
}
