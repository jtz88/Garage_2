using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage_2.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOfArrival",
                table: "ParkedVehicle",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 11, 15, 51, 54, 445, DateTimeKind.Local).AddTicks(4328),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 11, 9, 31, 12, 712, DateTimeKind.Local).AddTicks(8633));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Brand", "Color", "Model" },
                values: new object[] { "Volkswagen", "Blue", "Sedan" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOfArrival",
                table: "ParkedVehicle",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 11, 9, 31, 12, 712, DateTimeKind.Local).AddTicks(8633),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 11, 15, 51, 54, 445, DateTimeKind.Local).AddTicks(4328));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Brand", "Color", "Model" },
                values: new object[] { null, null, null });
        }
    }
}
