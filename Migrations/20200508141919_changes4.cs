using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage_2.Migrations
{
    public partial class changes4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOfArrival",
                table: "ParkedVehicle",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 8, 16, 19, 19, 77, DateTimeKind.Local).AddTicks(8975),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 8, 15, 52, 46, 570, DateTimeKind.Local).AddTicks(5124));

            migrationBuilder.InsertData(
                table: "ParkedVehicle",
                columns: new[] { "Id", "Brand", "Color", "Model", "NrOfWheels", "RegNr", "VehicleType" },
                values: new object[] { 7, null, null, null, 12, "EZXC789", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOfArrival",
                table: "ParkedVehicle",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 8, 15, 52, 46, 570, DateTimeKind.Local).AddTicks(5124),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 8, 16, 19, 19, 77, DateTimeKind.Local).AddTicks(8975));

            migrationBuilder.InsertData(
                table: "ParkedVehicle",
                columns: new[] { "Id", "Brand", "Color", "Model", "NrOfWheels", "RegNr", "VehicleType" },
                values: new object[] { 1, null, null, null, 4, "EFG456", 3 });
        }
    }
}
