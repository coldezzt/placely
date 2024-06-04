using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Placely.Main.Migrations
{
    /// <inheritdoc />
    public partial class some_contract_fixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "lease_start_date",
                table: "contracts",
                newName: "lease_start_date_time");

            migrationBuilder.RenameColumn(
                name: "lease_end_date",
                table: "contracts",
                newName: "lease_end_date_time");

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "lease_end_date_time", "lease_start_date_time" },
                values: new object[] { new DateTime(2024, 5, 28, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5669), new DateTime(2024, 4, 21, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5665) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "lease_end_date_time", "lease_start_date_time" },
                values: new object[] { new DateTime(2024, 5, 12, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5683), new DateTime(2024, 4, 28, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5683) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "lease_end_date_time", "lease_start_date_time" },
                values: new object[] { new DateTime(2024, 4, 29, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5685), new DateTime(2024, 4, 26, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5684) });

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(2024, 4, 26, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5783));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 4, 27, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5786));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 4, 22, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5788));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateOnly(2024, 4, 28));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateOnly(2024, 4, 28));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateOnly(2024, 4, 28));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 4L,
                column: "date",
                value: new DateOnly(2024, 4, 28));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 5L,
                column: "date",
                value: new DateOnly(2024, 4, 28));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 6L,
                column: "date",
                value: new DateOnly(2024, 4, 28));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 1L,
                column: "publication_date",
                value: new DateTime(2024, 4, 27, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5622));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 2L,
                column: "publication_date",
                value: new DateTime(2024, 3, 29, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5636));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 3L,
                column: "publication_date",
                value: new DateTime(2024, 2, 28, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5638));

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 8, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5709), new DateTime(2024, 4, 21, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5710) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 25, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5713), new DateTime(2024, 4, 28, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5714) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 25, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5715), new DateTime(2024, 4, 26, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5716) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 28, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5718), new DateTime(2024, 5, 2, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5718) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 18, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5720), new DateTime(2024, 5, 2, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5721) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "lease_start_date_time",
                table: "contracts",
                newName: "lease_start_date");

            migrationBuilder.RenameColumn(
                name: "lease_end_date_time",
                table: "contracts",
                newName: "lease_end_date");

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 5, 25, 17, 7, 18, 372, DateTimeKind.Utc).AddTicks(4219), new DateTime(2024, 4, 18, 17, 7, 18, 372, DateTimeKind.Utc).AddTicks(4217) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 5, 9, 17, 7, 18, 372, DateTimeKind.Utc).AddTicks(4227), new DateTime(2024, 4, 25, 17, 7, 18, 372, DateTimeKind.Utc).AddTicks(4226) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 4, 26, 17, 7, 18, 372, DateTimeKind.Utc).AddTicks(4229), new DateTime(2024, 4, 23, 17, 7, 18, 372, DateTimeKind.Utc).AddTicks(4228) });

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(2024, 4, 23, 17, 7, 18, 372, DateTimeKind.Utc).AddTicks(4376));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 4, 24, 17, 7, 18, 372, DateTimeKind.Utc).AddTicks(4380));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 4, 19, 17, 7, 18, 372, DateTimeKind.Utc).AddTicks(4382));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateOnly(2024, 4, 25));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateOnly(2024, 4, 25));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateOnly(2024, 4, 25));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 4L,
                column: "date",
                value: new DateOnly(2024, 4, 25));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 5L,
                column: "date",
                value: new DateOnly(2024, 4, 25));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 6L,
                column: "date",
                value: new DateOnly(2024, 4, 25));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 1L,
                column: "publication_date",
                value: new DateTime(2024, 4, 24, 17, 7, 18, 372, DateTimeKind.Utc).AddTicks(4180));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 2L,
                column: "publication_date",
                value: new DateTime(2024, 3, 26, 17, 7, 18, 372, DateTimeKind.Utc).AddTicks(4192));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 3L,
                column: "publication_date",
                value: new DateTime(2024, 2, 25, 17, 7, 18, 372, DateTimeKind.Utc).AddTicks(4194));

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 5, 17, 7, 18, 372, DateTimeKind.Utc).AddTicks(4253), new DateTime(2024, 4, 18, 17, 7, 18, 372, DateTimeKind.Utc).AddTicks(4255) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 22, 17, 7, 18, 372, DateTimeKind.Utc).AddTicks(4258), new DateTime(2024, 4, 25, 17, 7, 18, 372, DateTimeKind.Utc).AddTicks(4259) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 22, 17, 7, 18, 372, DateTimeKind.Utc).AddTicks(4260), new DateTime(2024, 4, 23, 17, 7, 18, 372, DateTimeKind.Utc).AddTicks(4261) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 25, 17, 7, 18, 372, DateTimeKind.Utc).AddTicks(4262), new DateTime(2024, 4, 29, 17, 7, 18, 372, DateTimeKind.Utc).AddTicks(4263) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 15, 17, 7, 18, 372, DateTimeKind.Utc).AddTicks(4265), new DateTime(2024, 4, 29, 17, 7, 18, 372, DateTimeKind.Utc).AddTicks(4265) });
        }
    }
}
