using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitecture.Infrastructure.Migrations
{
    public partial class specification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutoSpecificationSubs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecificationSubParameter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutoSpecificationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoSpecificationSubs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutoSpecificationSubs_AutoSpecifications_AutoSpecificationId",
                        column: x => x.AutoSpecificationId,
                        principalTable: "AutoSpecifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutoSpecificationSubs_AutoSpecificationId",
                table: "AutoSpecificationSubs",
                column: "AutoSpecificationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutoSpecificationSubs");
        }
    }
}
