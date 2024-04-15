using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CorrectingSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 4, 15, 14, 8, 41, 50, DateTimeKind.Local).AddTicks(2624));

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Latitude", "Longitude" },
                values: new object[] { new DateTime(2024, 4, 5, 11, 8, 41, 50, DateTimeKind.Local).AddTicks(2693), 21.0, 2.0 });

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "Latitude", "Longitude" },
                values: new object[] { new DateTime(2024, 3, 4, 5, 8, 41, 50, DateTimeKind.Local).AddTicks(2709), 5.0, 54.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 4, 15, 14, 7, 37, 323, DateTimeKind.Local).AddTicks(8197));

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Latitude", "Longitude" },
                values: new object[] { new DateTime(2024, 4, 5, 11, 7, 37, 323, DateTimeKind.Local).AddTicks(8267), 12.0, 22.0 });

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "Latitude", "Longitude" },
                values: new object[] { new DateTime(2024, 3, 4, 5, 7, 37, 323, DateTimeKind.Local).AddTicks(8281), 12.0, 22.0 });
        }
    }
}
