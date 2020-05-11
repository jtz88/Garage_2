using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage_2.Migrations
{
    public partial class _0507_02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOfArrival",
                table: "ParkedVehicle",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 7, 16, 3, 32, 536, DateTimeKind.Local).AddTicks(7775),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 7, 15, 13, 4, 275, DateTimeKind.Local).AddTicks(4646));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOfArrival",
                table: "ParkedVehicle",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 7, 15, 13, 4, 275, DateTimeKind.Local).AddTicks(4646),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 7, 16, 3, 32, 536, DateTimeKind.Local).AddTicks(7775));
        }
    }
}
