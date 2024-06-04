using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Placely.Main.Migrations
{
    /// <inheritdoc />
    public partial class renames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "reservation_status",
                table: "reservations",
                newName: "status_type");

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "lease_end_date_time", "lease_start_date_time" },
                values: new object[] { new DateTime(2024, 7, 4, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(380), new DateTime(2024, 5, 28, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(376) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "lease_end_date_time", "lease_start_date_time" },
                values: new object[] { new DateTime(2024, 6, 18, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(387), new DateTime(2024, 6, 4, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(387) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "lease_end_date_time", "lease_start_date_time" },
                values: new object[] { new DateTime(2024, 6, 5, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(390), new DateTime(2024, 6, 2, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(389) });

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(2024, 6, 2, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(525));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 6, 3, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(529));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 5, 29, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(531));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateOnly(2024, 6, 4));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateOnly(2024, 6, 4));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateOnly(2024, 6, 4));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 4L,
                column: "date",
                value: new DateOnly(2024, 6, 4));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 5L,
                column: "date",
                value: new DateOnly(2024, 6, 4));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 6L,
                column: "date",
                value: new DateOnly(2024, 6, 4));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 1L,
                column: "publication_date",
                value: new DateTime(2024, 6, 3, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(325));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 2L,
                column: "publication_date",
                value: new DateTime(2024, 5, 5, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(336));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 3L,
                column: "publication_date",
                value: new DateTime(2024, 4, 5, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(339));

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 5, 15, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(422), new DateTime(2024, 5, 28, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(424) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 6, 1, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(431), new DateTime(2024, 6, 4, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(432) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 6, 1, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(434), new DateTime(2024, 6, 2, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(435) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 6, 4, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(437), new DateTime(2024, 6, 8, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(437) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 5, 25, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(440), new DateTime(2024, 6, 8, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(441) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 5, 25, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(444), new DateTime(2024, 6, 8, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(445) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status_type",
                table: "reservations",
                newName: "reservation_status");

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "lease_end_date_time", "lease_start_date_time" },
                values: new object[] { new DateTime(2024, 6, 4, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6294), new DateTime(2024, 4, 28, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6291) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "lease_end_date_time", "lease_start_date_time" },
                values: new object[] { new DateTime(2024, 5, 19, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6300), new DateTime(2024, 5, 5, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6300) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "lease_end_date_time", "lease_start_date_time" },
                values: new object[] { new DateTime(2024, 5, 6, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6303), new DateTime(2024, 5, 3, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6302) });

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(2024, 5, 3, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6439));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 5, 4, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6443));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 4, 29, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6445));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateOnly(2024, 5, 5));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateOnly(2024, 5, 5));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateOnly(2024, 5, 5));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 4L,
                column: "date",
                value: new DateOnly(2024, 5, 5));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 5L,
                column: "date",
                value: new DateOnly(2024, 5, 5));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 6L,
                column: "date",
                value: new DateOnly(2024, 5, 5));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 1L,
                column: "publication_date",
                value: new DateTime(2024, 5, 4, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6249));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 2L,
                column: "publication_date",
                value: new DateTime(2024, 4, 5, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6259));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 3L,
                column: "publication_date",
                value: new DateTime(2024, 3, 6, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6260));

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 15, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6356), new DateTime(2024, 4, 28, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6357) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 5, 2, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6360), new DateTime(2024, 5, 5, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6361) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 5, 2, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6362), new DateTime(2024, 5, 3, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6363) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 5, 5, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6364), new DateTime(2024, 5, 9, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6365) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 25, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6366), new DateTime(2024, 5, 9, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6370) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 25, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6373), new DateTime(2024, 5, 9, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6374) });
        }
    }
}
