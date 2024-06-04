using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Placely.Main.Migrations
{
    /// <inheritdoc />
    public partial class seeding_started_reservations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "reservation_status_id",
                table: "reservations");

            migrationBuilder.AddColumn<DateTime>(
                name: "creation_date_time",
                table: "reservations",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "decline_reason",
                table: "reservations",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 4, 29, 16, 53, 37, 257, DateTimeKind.Utc).AddTicks(9182), new DateTime(2024, 3, 23, 16, 53, 37, 257, DateTimeKind.Utc).AddTicks(9171) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "landlord_id", "lease_end_date", "lease_start_date" },
                values: new object[] { 1L, new DateTime(2024, 4, 13, 16, 53, 37, 257, DateTimeKind.Utc).AddTicks(9190), new DateTime(2024, 3, 30, 16, 53, 37, 257, DateTimeKind.Utc).AddTicks(9189) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "landlord_id", "lease_end_date", "lease_start_date", "property_id", "tenant_id", "tenant_paid_utilies" },
                values: new object[] { 2L, new DateTime(2024, 3, 31, 16, 53, 37, 257, DateTimeKind.Utc).AddTicks(9192), new DateTime(2024, 3, 28, 16, 53, 37, 257, DateTimeKind.Utc).AddTicks(9191), 3L, 3L, "some paid utils in contract between tenant1 and landlord3 in villa property" });

            migrationBuilder.InsertData(
                table: "reservations",
                columns: new[] { "id", "creation_date_time", "decline_reason", "duration", "entry_date", "guests_amount", "landlord_id", "property_id", "reservation_status", "tenant_id" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 3, 10, 16, 53, 37, 257, DateTimeKind.Utc).AddTicks(9211), null, new TimeSpan(37, 0, 0, 0, 0), new DateTime(2024, 3, 23, 16, 53, 37, 257, DateTimeKind.Utc).AddTicks(9212), (byte)3, 1L, 1L, 1, 1L },
                    { 2L, new DateTime(2024, 3, 27, 16, 53, 37, 257, DateTimeKind.Utc).AddTicks(9214), null, new TimeSpan(14, 0, 0, 0, 0), new DateTime(2024, 3, 30, 16, 53, 37, 257, DateTimeKind.Utc).AddTicks(9215), (byte)1, 1L, 2L, 1, 2L },
                    { 3L, new DateTime(2024, 3, 27, 16, 53, 37, 257, DateTimeKind.Utc).AddTicks(9221), null, new TimeSpan(3, 0, 0, 0, 0), new DateTime(2024, 3, 28, 16, 53, 37, 257, DateTimeKind.Utc).AddTicks(9222), (byte)2, 2L, 3L, 1, 3L },
                    { 4L, new DateTime(2024, 3, 30, 16, 53, 37, 257, DateTimeKind.Utc).AddTicks(9224), null, new TimeSpan(10, 0, 0, 0, 0), new DateTime(2024, 4, 3, 16, 53, 37, 257, DateTimeKind.Utc).AddTicks(9224), (byte)3, 1L, 2L, 0, 1L },
                    { 5L, new DateTime(2024, 3, 20, 16, 53, 37, 257, DateTimeKind.Utc).AddTicks(9226), "too many guests", new TimeSpan(10, 0, 0, 0, 0), new DateTime(2024, 4, 3, 16, 53, 37, 257, DateTimeKind.Utc).AddTicks(9228), (byte)34, 2L, 3L, 2, 3L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L);

            migrationBuilder.DropColumn(
                name: "creation_date_time",
                table: "reservations");

            migrationBuilder.DropColumn(
                name: "decline_reason",
                table: "reservations");

            migrationBuilder.AddColumn<byte>(
                name: "reservation_status_id",
                table: "reservations",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 4, 29, 16, 32, 25, 972, DateTimeKind.Utc).AddTicks(8129), new DateTime(2024, 3, 23, 16, 32, 25, 972, DateTimeKind.Utc).AddTicks(8119) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "landlord_id", "lease_end_date", "lease_start_date" },
                values: new object[] { 2L, new DateTime(2024, 4, 29, 16, 32, 25, 972, DateTimeKind.Utc).AddTicks(8137), new DateTime(2024, 3, 23, 16, 32, 25, 972, DateTimeKind.Utc).AddTicks(8136) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "landlord_id", "lease_end_date", "lease_start_date", "property_id", "tenant_id", "tenant_paid_utilies" },
                values: new object[] { 3L, new DateTime(2024, 4, 29, 16, 32, 25, 972, DateTimeKind.Utc).AddTicks(8139), new DateTime(2024, 3, 23, 16, 32, 25, 972, DateTimeKind.Utc).AddTicks(8138), 1L, 1L, "some paid utils in contract between tenant1 and landlord3 in flat property" });
        }
    }
}
