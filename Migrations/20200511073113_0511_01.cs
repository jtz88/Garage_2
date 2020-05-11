using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage_2.Migrations
{
    public partial class _0511_01 : Migration
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
                    vehicleType = table.Column<int>(nullable: false),
                    NrOfWheels = table.Column<int>(nullable: false),
                    Color = table.Column<string>(maxLength: 32, nullable: true),
                    Brand = table.Column<string>(maxLength: 32, nullable: true),
                    Model = table.Column<string>(maxLength: 64, nullable: true),
                    TimeOfArrival = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 5, 11, 9, 31, 12, 712, DateTimeKind.Local).AddTicks(8633))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkedVehicle", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ParkedVehicle",
                columns: new[] { "Id", "Brand", "Color", "Model", "NrOfWheels", "RegNr", "vehicleType" },
                values: new object[] { 1, null, null, null, 4, "ABC123", 3 });

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
