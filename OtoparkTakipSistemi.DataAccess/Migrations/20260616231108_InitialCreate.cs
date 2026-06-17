using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OtoparkTakipSistemi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkingSlots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SlotNumber = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Floor = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    IsOccupied = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSlots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tariffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TariffName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    BasePrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    HourlyPrice = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tariffs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParkingRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LicensePlate = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    VehicleType = table.Column<int>(type: "INTEGER", nullable: false),
                    ParkingSlotId = table.Column<int>(type: "INTEGER", nullable: false),
                    CheckInTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CheckOutTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingRecords_ParkingSlots_ParkingSlotId",
                        column: x => x.ParkingSlotId,
                        principalTable: "ParkingSlots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ParkingSlots",
                columns: new[] { "Id", "Floor", "IsOccupied", "SlotNumber" },
                values: new object[,]
                {
                    { 1, "Kat 1", false, "A-1" },
                    { 2, "Kat 1", false, "A-2" },
                    { 3, "Kat 2", false, "B-1" },
                    { 4, "Kat 2", false, "B-2" }
                });

            migrationBuilder.InsertData(
                table: "Tariffs",
                columns: new[] { "Id", "BasePrice", "HourlyPrice", "TariffName" },
                values: new object[] { 1, 40.00m, 15.00m, "Standart Gündüz Tarifesi" });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingRecords_ParkingSlotId",
                table: "ParkingRecords",
                column: "ParkingSlotId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingRecords");

            migrationBuilder.DropTable(
                name: "Tariffs");

            migrationBuilder.DropTable(
                name: "ParkingSlots");
        }
    }
}
