using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage_2.Migrations
{
    public partial class changes3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOfArrival",
                table: "ParkedVehicle",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 8, 15, 52, 46, 570, DateTimeKind.Local).AddTicks(5124),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 8, 15, 46, 38, 685, DateTimeKind.Local).AddTicks(3846));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegNr",
                value: "EFG456");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOfArrival",
                table: "ParkedVehicle",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 8, 15, 46, 38, 685, DateTimeKind.Local).AddTicks(3846),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 8, 15, 52, 46, 570, DateTimeKind.Local).AddTicks(5124));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegNr",
                value: "ABC123");

            migrationBuilder.InsertData(
                table: "ParkedVehicle",
                columns: new[] { "Id", "Brand", "Color", "Model", "NrOfWheels", "RegNr", "VehicleType" },
                values: new object[] { 2, null, null, null, 2, "EFG456", 4 });
        }
    }
}
