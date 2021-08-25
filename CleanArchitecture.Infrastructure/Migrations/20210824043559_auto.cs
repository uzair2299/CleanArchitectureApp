using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitecture.Infrastructure.Migrations
{
    public partial class auto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CrubWeight",
                table: "AutoVersion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExteriorHeight",
                table: "AutoVersion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExteriorLength",
                table: "AutoVersion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExteriorWidth",
                table: "AutoVersion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FuelTankCapacity",
                table: "AutoVersion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GrossVehicleWeigth",
                table: "AutoVersion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GroundClearance",
                table: "AutoVersion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InteriorHeight",
                table: "AutoVersion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InteriorLength",
                table: "AutoVersion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InteriorWidth",
                table: "AutoVersion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinimumGroundClearance",
                table: "AutoVersion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OverhangFront",
                table: "AutoVersion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OverhangRear",
                table: "AutoVersion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RunningGroundClearance",
                table: "AutoVersion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SeatingCapacity",
                table: "AutoVersion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TreadFront",
                table: "AutoVersion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TreadRear",
                table: "AutoVersion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Wheelbase",
                table: "AutoVersion",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CrubWeight",
                table: "AutoVersion");

            migrationBuilder.DropColumn(
                name: "ExteriorHeight",
                table: "AutoVersion");

            migrationBuilder.DropColumn(
                name: "ExteriorLength",
                table: "AutoVersion");

            migrationBuilder.DropColumn(
                name: "ExteriorWidth",
                table: "AutoVersion");

            migrationBuilder.DropColumn(
                name: "FuelTankCapacity",
                table: "AutoVersion");

            migrationBuilder.DropColumn(
                name: "GrossVehicleWeigth",
                table: "AutoVersion");

            migrationBuilder.DropColumn(
                name: "GroundClearance",
                table: "AutoVersion");

            migrationBuilder.DropColumn(
                name: "InteriorHeight",
                table: "AutoVersion");

            migrationBuilder.DropColumn(
                name: "InteriorLength",
                table: "AutoVersion");

            migrationBuilder.DropColumn(
                name: "InteriorWidth",
                table: "AutoVersion");

            migrationBuilder.DropColumn(
                name: "MinimumGroundClearance",
                table: "AutoVersion");

            migrationBuilder.DropColumn(
                name: "OverhangFront",
                table: "AutoVersion");

            migrationBuilder.DropColumn(
                name: "OverhangRear",
                table: "AutoVersion");

            migrationBuilder.DropColumn(
                name: "RunningGroundClearance",
                table: "AutoVersion");

            migrationBuilder.DropColumn(
                name: "SeatingCapacity",
                table: "AutoVersion");

            migrationBuilder.DropColumn(
                name: "TreadFront",
                table: "AutoVersion");

            migrationBuilder.DropColumn(
                name: "TreadRear",
                table: "AutoVersion");

            migrationBuilder.DropColumn(
                name: "Wheelbase",
                table: "AutoVersion");
        }
    }
}
