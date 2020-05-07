﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage_2.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOfArrival",
                table: "ParkedVehicle",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 6, 16, 28, 36, 73, DateTimeKind.Local).AddTicks(6646),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 6, 16, 8, 59, 527, DateTimeKind.Local).AddTicks(6233));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOfArrival",
                table: "ParkedVehicle",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 6, 16, 8, 59, 527, DateTimeKind.Local).AddTicks(6233),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 6, 16, 28, 36, 73, DateTimeKind.Local).AddTicks(6646));
        }
    }
}
