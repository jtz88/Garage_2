using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage_2.Migrations
{
    public partial class changes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOfArrival",
                table: "ParkedVehicle",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 8, 15, 46, 38, 685, DateTimeKind.Local).AddTicks(3846),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 8, 15, 42, 16, 509, DateTimeKind.Local).AddTicks(3370));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOfArrival",
                table: "ParkedVehicle",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 8, 15, 42, 16, 509, DateTimeKind.Local).AddTicks(3370),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 8, 15, 46, 38, 685, DateTimeKind.Local).AddTicks(3846));
        }
    }
}
