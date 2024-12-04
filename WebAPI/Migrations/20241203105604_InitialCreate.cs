using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EModels",
                columns: table => new
                {
                    Environmentid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Unit = table.Column<string>(type: "TEXT", nullable: true),
                    TotalEnergy = table.Column<double>(type: "REAL", nullable: false),
                    CrudeFuel = table.Column<double>(type: "REAL", nullable: false),
                    GasFuel = table.Column<double>(type: "REAL", nullable: false),
                    PurchElec = table.Column<double>(type: "REAL", nullable: false),
                    RenewEnergy = table.Column<double>(type: "REAL", nullable: false),
                    FossilEnergy = table.Column<double>(type: "REAL", nullable: false),
                    Year = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EModels", x => x.Environmentid);
                });

            migrationBuilder.CreateTable(
                name: "GHModels",
                columns: table => new
                {
                    GreenHouseId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Unit = table.Column<string>(type: "TEXT", nullable: true),
                    scope12Market = table.Column<double>(type: "REAL", nullable: false),
                    scope12location = table.Column<double>(type: "REAL", nullable: false),
                    scope3soldproducts = table.Column<double>(type: "REAL", nullable: false),
                    Year = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GHModels", x => x.GreenHouseId);
                });

            migrationBuilder.CreateTable(
                name: "WaModels",
                columns: table => new
                {
                    WaterId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Unit = table.Column<string>(type: "TEXT", nullable: true),
                    WaterConsumption = table.Column<double>(type: "REAL", nullable: false),
                    WaterRecycled = table.Column<double>(type: "REAL", nullable: false),
                    Year = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaModels", x => x.WaterId);
                });

            migrationBuilder.CreateTable(
                name: "WModels",
                columns: table => new
                {
                    WasteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Unit = table.Column<string>(type: "TEXT", nullable: true),
                    TotalWaste = table.Column<double>(type: "REAL", nullable: false),
                    Year = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WModels", x => x.WasteId);
                });

            migrationBuilder.InsertData(
                table: "EModels",
                columns: new[] { "Environmentid", "CrudeFuel", "FossilEnergy", "GasFuel", "PurchElec", "RenewEnergy", "TotalEnergy", "Unit", "Year" },
                values: new object[,]
                {
                    { 1, 52912.0, 85667.0, 22516.0, 5268.0, 5703.0, 91370.0, "MWh", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 49992.0, 86986.0, 24177.0, 3567.0, 4123.0, 91109.0, "MWh", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "GHModels",
                columns: new[] { "GreenHouseId", "Unit", "Year", "scope12Market", "scope12location", "scope3soldproducts" },
                values: new object[,]
                {
                    { 1, "tons CO2 eq", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 19013.0, 20769.0, 1612627.0 },
                    { 2, "tons CO2 eq", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20143.0, 20783.0, 1929831.0 }
                });

            migrationBuilder.InsertData(
                table: "WModels",
                columns: new[] { "WasteId", "TotalWaste", "Unit", "Year" },
                values: new object[,]
                {
                    { 1, 1549.0, "tons", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1559.0, "tons", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "WaModels",
                columns: new[] { "WaterId", "Unit", "WaterConsumption", "WaterRecycled", "Year" },
                values: new object[,]
                {
                    { 1, "m³", 18409.0, 8955.0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "m³", 79773.0, 12926.0, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EModels");

            migrationBuilder.DropTable(
                name: "GHModels");

            migrationBuilder.DropTable(
                name: "WaModels");

            migrationBuilder.DropTable(
                name: "WModels");
        }
    }
}
