using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage_2.Migrations
{
    public partial class Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOfArrival",
                table: "ParkedVehicle",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 7, 13, 47, 13, 783, DateTimeKind.Local).AddTicks(6663),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 6, 16, 28, 36, 73, DateTimeKind.Local).AddTicks(6646));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOfArrival",
                table: "ParkedVehicle",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 6, 16, 28, 36, 73, DateTimeKind.Local).AddTicks(6646),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 7, 13, 47, 13, 783, DateTimeKind.Local).AddTicks(6663));
        }
    }
}
