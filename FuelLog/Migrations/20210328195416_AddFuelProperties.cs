using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FuelLog.Migrations
{
    public partial class AddFuelProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvgConsumption",
                table: "Fuels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Fuels",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "OdoCounter",
                table: "Fuels",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvgConsumption",
                table: "Fuels");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Fuels");

            migrationBuilder.DropColumn(
                name: "OdoCounter",
                table: "Fuels");
        }
    }
}
