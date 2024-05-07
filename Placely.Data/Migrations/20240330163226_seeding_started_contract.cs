using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Placely.Main.Migrations
{
    /// <inheritdoc />
    public partial class seeding_started_contract : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "contracts",
                columns: new[] { "id", "landlord_id", "lease_end_date", "lease_start_date", "property_id", "tenant_id", "tenant_paid_utilies" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 4, 29, 16, 32, 25, 972, DateTimeKind.Utc).AddTicks(8129), new DateTime(2024, 3, 23, 16, 32, 25, 972, DateTimeKind.Utc).AddTicks(8119), 1L, 1L, "some paid utils in contract between tenant1 and landlord1 in flat property" },
                    { 2L, 2L, new DateTime(2024, 4, 29, 16, 32, 25, 972, DateTimeKind.Utc).AddTicks(8137), new DateTime(2024, 3, 23, 16, 32, 25, 972, DateTimeKind.Utc).AddTicks(8136), 2L, 2L, "some paid utils in contract between tenant2 and landlord2 in hostel property" },
                    { 3L, 3L, new DateTime(2024, 4, 29, 16, 32, 25, 972, DateTimeKind.Utc).AddTicks(8139), new DateTime(2024, 3, 23, 16, 32, 25, 972, DateTimeKind.Utc).AddTicks(8138), 1L, 1L, "some paid utils in contract between tenant1 and landlord3 in flat property" }
                });

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateOnly(2024, 3, 30));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateOnly(2024, 3, 30));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateOnly(2024, 3, 30));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 4L,
                column: "date",
                value: new DateOnly(2024, 3, 30));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 5L,
                column: "date",
                value: new DateOnly(2024, 3, 30));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 6L,
                column: "date",
                value: new DateOnly(2024, 3, 30));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateOnly(2024, 3, 18));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateOnly(2024, 3, 18));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateOnly(2024, 3, 18));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 4L,
                column: "date",
                value: new DateOnly(2024, 3, 18));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 5L,
                column: "date",
                value: new DateOnly(2024, 3, 18));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 6L,
                column: "date",
                value: new DateOnly(2024, 3, 18));
        }
    }
}
