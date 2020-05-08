using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage_2.Migrations
{
    public partial class addedDbEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOfArrival",
                table: "ParkedVehicle",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 8, 15, 42, 16, 509, DateTimeKind.Local).AddTicks(3370),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 7, 15, 13, 4, 275, DateTimeKind.Local).AddTicks(4646));

            migrationBuilder.InsertData(
                table: "ParkedVehicle",
                columns: new[] { "Id", "Brand", "Color", "Model", "NrOfWheels", "RegNr", "VehicleType" },
                values: new object[] { 2, null, null, null, 2, "EFG456", 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOfArrival",
                table: "ParkedVehicle",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 7, 15, 13, 4, 275, DateTimeKind.Local).AddTicks(4646),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 8, 15, 42, 16, 509, DateTimeKind.Local).AddTicks(3370));
        }
    }
}
