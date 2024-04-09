using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Placely.Main.Migrations
{
    /// <inheritdoc />
    public partial class seeding_started_reviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 4, 29, 16, 59, 33, 591, DateTimeKind.Utc).AddTicks(8565), new DateTime(2024, 3, 23, 16, 59, 33, 591, DateTimeKind.Utc).AddTicks(8554) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 4, 13, 16, 59, 33, 591, DateTimeKind.Utc).AddTicks(8573), new DateTime(2024, 3, 30, 16, 59, 33, 591, DateTimeKind.Utc).AddTicks(8573) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 3, 31, 16, 59, 33, 591, DateTimeKind.Utc).AddTicks(8575), new DateTime(2024, 3, 28, 16, 59, 33, 591, DateTimeKind.Utc).AddTicks(8575) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 3, 10, 16, 59, 33, 591, DateTimeKind.Utc).AddTicks(8598), new DateTime(2024, 3, 23, 16, 59, 33, 591, DateTimeKind.Utc).AddTicks(8599) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 3, 27, 16, 59, 33, 591, DateTimeKind.Utc).AddTicks(8602), new DateTime(2024, 3, 30, 16, 59, 33, 591, DateTimeKind.Utc).AddTicks(8603) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 3, 27, 16, 59, 33, 591, DateTimeKind.Utc).AddTicks(8604), new DateTime(2024, 3, 28, 16, 59, 33, 591, DateTimeKind.Utc).AddTicks(8605) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 3, 30, 16, 59, 33, 591, DateTimeKind.Utc).AddTicks(8607), new DateTime(2024, 4, 3, 16, 59, 33, 591, DateTimeKind.Utc).AddTicks(8607) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 3, 20, 16, 59, 33, 591, DateTimeKind.Utc).AddTicks(8609), new DateTime(2024, 4, 3, 16, 59, 33, 591, DateTimeKind.Utc).AddTicks(8610) });

            migrationBuilder.InsertData(
                table: "reviews",
                columns: new[] { "id", "author_id", "content", "property_id", "rating" },
                values: new object[,]
                {
                    { 1L, 1L, "review 1", 1L, 1L },
                    { 2L, 2L, "review 2", 2L, 2L },
                    { 3L, 3L, "review 3", 3L, 3L },
                    { 4L, 4L, "review 4", 1L, 4L },
                    { 5L, 5L, "review 5", 2L, 5L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 5L);

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
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 4, 13, 16, 53, 37, 257, DateTimeKind.Utc).AddTicks(9190), new DateTime(2024, 3, 30, 16, 53, 37, 257, DateTimeKind.Utc).AddTicks(9189) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 3, 31, 16, 53, 37, 257, DateTimeKind.Utc).AddTicks(9192), new DateTime(2024, 3, 28, 16, 53, 37, 257, DateTimeKind.Utc).AddTicks(9191) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 3, 10, 16, 53, 37, 257, DateTimeKind.Utc).AddTicks(9211), new DateTime(2024, 3, 23, 16, 53, 37, 257, DateTimeKind.Utc).AddTicks(9212) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 3, 27, 16, 53, 37, 257, DateTimeKind.Utc).AddTicks(9214), new DateTime(2024, 3, 30, 16, 53, 37, 257, DateTimeKind.Utc).AddTicks(9215) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 3, 27, 16, 53, 37, 257, DateTimeKind.Utc).AddTicks(9221), new DateTime(2024, 3, 28, 16, 53, 37, 257, DateTimeKind.Utc).AddTicks(9222) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 3, 30, 16, 53, 37, 257, DateTimeKind.Utc).AddTicks(9224), new DateTime(2024, 4, 3, 16, 53, 37, 257, DateTimeKind.Utc).AddTicks(9224) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 3, 20, 16, 53, 37, 257, DateTimeKind.Utc).AddTicks(9226), new DateTime(2024, 4, 3, 16, 53, 37, 257, DateTimeKind.Utc).AddTicks(9228) });
        }
    }
}
