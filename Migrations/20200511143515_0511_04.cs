using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage_2.Migrations
{
    public partial class _0511_04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOfArrival",
                table: "ParkedVehicle",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 11, 16, 35, 15, 188, DateTimeKind.Local).AddTicks(881),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 11, 16, 35, 15, 499, DateTimeKind.Local).AddTicks(7992));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOfArrival",
                table: "ParkedVehicle",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 11, 16, 35, 15, 499, DateTimeKind.Local).AddTicks(7992),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 11, 16, 35, 15, 188, DateTimeKind.Local).AddTicks(881));
        }
    }
}
