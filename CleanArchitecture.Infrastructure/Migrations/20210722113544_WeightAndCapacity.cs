using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitecture.Infrastructure.Migrations
{
    public partial class WeightAndCapacity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutoVersionDimension_AutoVersion_AutoVersionId",
                table: "AutoVersionDimension");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AutoVersionDimension",
                table: "AutoVersionDimension");

            migrationBuilder.RenameTable(
                name: "AutoVersionDimension",
                newName: "AutoVersionDimensions");

            migrationBuilder.RenameIndex(
                name: "IX_AutoVersionDimension_AutoVersionId",
                table: "AutoVersionDimensions",
                newName: "IX_AutoVersionDimensions_AutoVersionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AutoVersionDimensions",
                table: "AutoVersionDimensions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AutoVersionWeightCapacities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatingCapacity = table.Column<int>(type: "int", nullable: false),
                    FuelTankCapacity = table.Column<int>(type: "int", nullable: false),
                    CrubWeight = table.Column<int>(type: "int", nullable: false),
                    GrossVehicleWeigth = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutoVersionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoVersionWeightCapacities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutoVersionWeightCapacities_AutoVersion_AutoVersionId",
                        column: x => x.AutoVersionId,
                        principalTable: "AutoVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutoVersionWeightCapacities_AutoVersionId",
                table: "AutoVersionWeightCapacities",
                column: "AutoVersionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AutoVersionDimensions_AutoVersion_AutoVersionId",
                table: "AutoVersionDimensions",
                column: "AutoVersionId",
                principalTable: "AutoVersion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutoVersionDimensions_AutoVersion_AutoVersionId",
                table: "AutoVersionDimensions");

            migrationBuilder.DropTable(
                name: "AutoVersionWeightCapacities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AutoVersionDimensions",
                table: "AutoVersionDimensions");

            migrationBuilder.RenameTable(
                name: "AutoVersionDimensions",
                newName: "AutoVersionDimension");

            migrationBuilder.RenameIndex(
                name: "IX_AutoVersionDimensions_AutoVersionId",
                table: "AutoVersionDimension",
                newName: "IX_AutoVersionDimension_AutoVersionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AutoVersionDimension",
                table: "AutoVersionDimension",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AutoVersionDimension_AutoVersion_AutoVersionId",
                table: "AutoVersionDimension",
                column: "AutoVersionId",
                principalTable: "AutoVersion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
