using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddingSessionSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "Date", "Latitude", "Longitude", "SessionName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 15, 14, 7, 37, 323, DateTimeKind.Local).AddTicks(8197), 12.0, 22.0, "Test Session 1" },
                    { 2, new DateTime(2024, 4, 5, 11, 7, 37, 323, DateTimeKind.Local).AddTicks(8267), 12.0, 22.0, "Test Session 2" },
                    { 3, new DateTime(2024, 3, 4, 5, 7, 37, 323, DateTimeKind.Local).AddTicks(8281), 12.0, 22.0, "Test Session 3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
