using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitecture.Infrastructure.Migrations
{
    public partial class AutoVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutoVersion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AutoVersionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutoModelId = table.Column<int>(type: "int", nullable: false),
                    AutoBodyTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoVersion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutoVersion_AutoBodyType_AutoBodyTypeId",
                        column: x => x.AutoBodyTypeId,
                        principalTable: "AutoBodyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutoVersion_AutoModels_AutoModelId",
                        column: x => x.AutoModelId,
                        principalTable: "AutoModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutoVersion_AutoBodyTypeId",
                table: "AutoVersion",
                column: "AutoBodyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoVersion_AutoModelId",
                table: "AutoVersion",
                column: "AutoModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutoVersion");
        }
    }
}
