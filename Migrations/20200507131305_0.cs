using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage_2.Migrations
{
    public partial class _0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOfArrival",
                table: "ParkedVehicle",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 7, 15, 13, 4, 275, DateTimeKind.Local).AddTicks(4646),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 6, 16, 28, 36, 73, DateTimeKind.Local).AddTicks(6646));

            migrationBuilder.AddColumn<int>(
                name: "VehicleType",
                table: "ParkedVehicle",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "VehicleType",
                value: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleType",
                table: "ParkedVehicle");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOfArrival",
                table: "ParkedVehicle",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 6, 16, 28, 36, 73, DateTimeKind.Local).AddTicks(6646),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 7, 15, 13, 4, 275, DateTimeKind.Local).AddTicks(4646));
        }
    }
}
