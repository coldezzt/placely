using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BL.Migrations
{
    /// <inheritdoc />
    public partial class seeding_started_notifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "notifications",
                columns: new[] { "id", "content", "date", "is_deleted", "receiver_id", "title" },
                values: new object[,]
                {
                    { 1L, "This is some helpful information", new DateOnly(2024, 3, 18), false, 2L, "Info" },
                    { 2L, "This is some helpful information", new DateOnly(2024, 3, 18), false, 2L, "Info" },
                    { 3L, "This is already readed some helpful information", new DateOnly(2024, 3, 18), false, 3L, "Info" },
                    { 4L, "This is already readed some helpful information", new DateOnly(2024, 3, 18), true, 3L, "Info" }
                });

            migrationBuilder.InsertData(
                table: "tenants",
                columns: new[] { "id", "about", "avatar_path", "creation_year", "email", "name", "password", "phone_number", "work" },
                values: new object[,]
                {
                    { 4L, "I'm test landlord 1", "", 2024L, "test.landlord.1@email.domen", "Test landlord 1", "test.landlord.1@email.domen", "111 1111 11 11", "I'm working here" },
                    { 5L, "I'm test landlord 2", "", 2024L, "test.landlord.2@email.domen", "Test landlord 2", "test.landlord.2@email.domen", "222 2222 22 22", "I'm working here" },
                    { 6L, "I'm test landlord 3", "", 2024L, "test.landlord.3@email.domen", "Test landlord 3", "test.landlord.3@email.domen", "333 3333 33 33", "I'm working here" }
                });

            migrationBuilder.InsertData(
                table: "notifications",
                columns: new[] { "id", "content", "date", "is_deleted", "receiver_id", "title" },
                values: new object[,]
                {
                    { 5L, "This is request on reservation", new DateOnly(2024, 3, 18), false, 4L, "Request" },
                    { 6L, "This is readed request on reservation", new DateOnly(2024, 3, 18), true, 5L, "Request" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 5L);
        }
    }
}
