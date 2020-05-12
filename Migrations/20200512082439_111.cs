﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage_2.Migrations
{
    public partial class _111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkedVehicle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegNr = table.Column<string>(maxLength: 32, nullable: false),
                    VehicleType = table.Column<int>(nullable: false),
                    NrOfWheels = table.Column<int>(nullable: false),
                    Color = table.Column<string>(maxLength: 32, nullable: true),
                    Brand = table.Column<string>(maxLength: 32, nullable: true),
                    Model = table.Column<string>(maxLength: 64, nullable: true),
                    TimeOfArrival = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    PosParkingSpace = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkedVehicle", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ParkedVehicle",
                columns: new[] { "Id", "Brand", "Color", "Model", "NrOfWheels", "PosParkingSpace", "RegNr", "VehicleType" },
                values: new object[] { 1, null, null, null, 4, 0, "US_LM126", 0 });

            migrationBuilder.InsertData(
                table: "ParkedVehicle",
                columns: new[] { "Id", "Brand", "Color", "Model", "NrOfWheels", "PosParkingSpace", "RegNr", "TimeOfArrival", "VehicleType" },
                values: new object[] { 2, null, "White", null, 0, 0, "BVG17", new DateTime(2020, 5, 11, 8, 54, 38, 881, DateTimeKind.Local).AddTicks(5101), 1 });

            migrationBuilder.InsertData(
                table: "ParkedVehicle",
                columns: new[] { "Id", "Brand", "Color", "Model", "NrOfWheels", "PosParkingSpace", "RegNr", "VehicleType" },
                values: new object[,]
                {
                    { 3, null, null, null, 6, 0, "BUS123", 2 },
                    { 4, null, null, null, 4, 0, "ABC123", 3 },
                    { 5, null, "Black", "Yamaha YZF1000R 4VD", 2, 0, "ADZ967", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkedVehicle_RegNr",
                table: "ParkedVehicle",
                column: "RegNr",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkedVehicle");
        }
    }
}
