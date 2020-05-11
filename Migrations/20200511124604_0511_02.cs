using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage_2.Migrations
{
    public partial class _0511_02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOfArrival",
                table: "ParkedVehicle",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 11, 14, 46, 4, 471, DateTimeKind.Local).AddTicks(1608),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 11, 9, 31, 12, 712, DateTimeKind.Local).AddTicks(8633));
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
                oldDefaultValue: new DateTime(2020, 5, 11, 14, 46, 4, 471, DateTimeKind.Local).AddTicks(1608));
        }
    }
}
