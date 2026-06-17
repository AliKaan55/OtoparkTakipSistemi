using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OtoparkTakipSistemi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddSlotCapacity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOccupied",
                table: "ParkingSlots");

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "ParkingSlots",
                type: "INTEGER",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "OccupiedCount",
                table: "ParkingSlots",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ParkingSlots",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Capacity", "OccupiedCount" },
                values: new object[] { 3, 0 });

            migrationBuilder.UpdateData(
                table: "ParkingSlots",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Capacity", "OccupiedCount" },
                values: new object[] { 2, 0 });

            migrationBuilder.UpdateData(
                table: "ParkingSlots",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Capacity", "OccupiedCount" },
                values: new object[] { 1, 0 });

            migrationBuilder.UpdateData(
                table: "ParkingSlots",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Capacity", "OccupiedCount" },
                values: new object[] { 1, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "ParkingSlots");

            migrationBuilder.DropColumn(
                name: "OccupiedCount",
                table: "ParkingSlots");

            migrationBuilder.AddColumn<bool>(
                name: "IsOccupied",
                table: "ParkingSlots",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
