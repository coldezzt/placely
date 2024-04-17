using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Placely.Main.Migrations
{
    /// <inheritdoc />
    public partial class tenant_fixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "creation_year",
                table: "tenants");

            migrationBuilder.AddColumn<int>(
                name: "user_role",
                table: "tenants",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 5, 17, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6099), new DateTime(2024, 4, 10, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6096) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 5, 1, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6105), new DateTime(2024, 4, 17, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6105) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 4, 18, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6107), new DateTime(2024, 4, 15, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6106) });

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(2024, 4, 15, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6249));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 4, 16, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6251));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 4, 11, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6253));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateOnly(2024, 4, 17));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateOnly(2024, 4, 17));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateOnly(2024, 4, 17));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 4L,
                column: "date",
                value: new DateOnly(2024, 4, 17));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 5L,
                column: "date",
                value: new DateOnly(2024, 4, 17));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 6L,
                column: "date",
                value: new DateOnly(2024, 4, 17));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 1L,
                column: "publication_date",
                value: new DateTime(2024, 4, 16, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6024));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 2L,
                column: "publication_date",
                value: new DateTime(2024, 3, 18, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6067));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 3L,
                column: "publication_date",
                value: new DateTime(2024, 2, 17, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6070));

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 3, 28, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6133), new DateTime(2024, 4, 10, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6136) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 14, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6138), new DateTime(2024, 4, 17, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6139) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 14, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6180), new DateTime(2024, 4, 15, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6180) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 17, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6182), new DateTime(2024, 4, 21, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6183) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 7, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6185), new DateTime(2024, 4, 21, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6186) });

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 1L,
                column: "user_role",
                value: 0);

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 2L,
                column: "user_role",
                value: 0);

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 3L,
                column: "user_role",
                value: 0);

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 4L,
                column: "user_role",
                value: 0);

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 5L,
                column: "user_role",
                value: 0);

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 6L,
                column: "user_role",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "user_role",
                table: "tenants");

            migrationBuilder.AddColumn<long>(
                name: "creation_year",
                table: "tenants",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 5, 16, 14, 49, 41, 849, DateTimeKind.Utc).AddTicks(31), new DateTime(2024, 4, 9, 14, 49, 41, 849, DateTimeKind.Utc).AddTicks(27) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 4, 30, 14, 49, 41, 849, DateTimeKind.Utc).AddTicks(37), new DateTime(2024, 4, 16, 14, 49, 41, 849, DateTimeKind.Utc).AddTicks(37) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 4, 17, 14, 49, 41, 849, DateTimeKind.Utc).AddTicks(40), new DateTime(2024, 4, 14, 14, 49, 41, 849, DateTimeKind.Utc).AddTicks(39) });

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(2024, 4, 14, 14, 49, 41, 849, DateTimeKind.Utc).AddTicks(142));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 4, 15, 14, 49, 41, 849, DateTimeKind.Utc).AddTicks(145));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 4, 10, 14, 49, 41, 849, DateTimeKind.Utc).AddTicks(147));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateOnly(2024, 4, 16));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateOnly(2024, 4, 16));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateOnly(2024, 4, 16));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 4L,
                column: "date",
                value: new DateOnly(2024, 4, 16));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 5L,
                column: "date",
                value: new DateOnly(2024, 4, 16));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 6L,
                column: "date",
                value: new DateOnly(2024, 4, 16));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 1L,
                column: "publication_date",
                value: new DateTime(2024, 4, 15, 14, 49, 41, 848, DateTimeKind.Utc).AddTicks(9952));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 2L,
                column: "publication_date",
                value: new DateTime(2024, 3, 17, 14, 49, 41, 848, DateTimeKind.Utc).AddTicks(9996));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 3L,
                column: "publication_date",
                value: new DateTime(2024, 2, 16, 14, 49, 41, 848, DateTimeKind.Utc).AddTicks(9999));

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 3, 27, 14, 49, 41, 849, DateTimeKind.Utc).AddTicks(65), new DateTime(2024, 4, 9, 14, 49, 41, 849, DateTimeKind.Utc).AddTicks(66) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 13, 14, 49, 41, 849, DateTimeKind.Utc).AddTicks(69), new DateTime(2024, 4, 16, 14, 49, 41, 849, DateTimeKind.Utc).AddTicks(70) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 13, 14, 49, 41, 849, DateTimeKind.Utc).AddTicks(71), new DateTime(2024, 4, 14, 14, 49, 41, 849, DateTimeKind.Utc).AddTicks(72) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 16, 14, 49, 41, 849, DateTimeKind.Utc).AddTicks(73), new DateTime(2024, 4, 20, 14, 49, 41, 849, DateTimeKind.Utc).AddTicks(74) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 6, 14, 49, 41, 849, DateTimeKind.Utc).AddTicks(76), new DateTime(2024, 4, 20, 14, 49, 41, 849, DateTimeKind.Utc).AddTicks(77) });

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 1L,
                column: "creation_year",
                value: 2024L);

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 2L,
                column: "creation_year",
                value: 2024L);

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 3L,
                column: "creation_year",
                value: 2024L);

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 4L,
                column: "creation_year",
                value: 2024L);

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 5L,
                column: "creation_year",
                value: 2024L);

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 6L,
                column: "creation_year",
                value: 2024L);
        }
    }
}
