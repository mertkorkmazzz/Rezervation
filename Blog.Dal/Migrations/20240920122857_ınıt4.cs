using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blog.Dal.Migrations
{
    /// <inheritdoc />
    public partial class ınıt4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "IsDeleted", "TableNumber" },
                values: new object[,]
                {
                    { 1, false, "Masa 1" },
                    { 2, false, "Masa 2" }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "FirstName", "IsDeleted", "LastName", "PhoneNumber", "ReservationDate", "TableId" },
                values: new object[,]
                {
                    { 1, "Ahmet", false, "Yılmaz", "123456789", new DateTime(2024, 9, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "Mehmet", false, "Kaya", "987654321", new DateTime(2024, 9, 23, 18, 30, 0, 0, DateTimeKind.Unspecified), 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
