using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Placely.Main.Migrations
{
    /// <inheritdoc />
    public partial class reservation_fixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "reservation_status",
                table: "reservations",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "lease_end_date_time", "lease_start_date_time" },
                values: new object[] { new DateTime(2024, 6, 3, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(6964), new DateTime(2024, 4, 27, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(6960) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "lease_end_date_time", "lease_start_date_time" },
                values: new object[] { new DateTime(2024, 5, 18, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(6971), new DateTime(2024, 5, 4, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(6970) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "lease_end_date_time", "lease_start_date_time" },
                values: new object[] { new DateTime(2024, 5, 5, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(6973), new DateTime(2024, 5, 2, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(6972) });

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(2024, 5, 2, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(7181));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 5, 3, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(7184));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 4, 28, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(7186));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 1L,
                column: "publication_date",
                value: new DateTime(2024, 5, 3, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(6913));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 2L,
                column: "publication_date",
                value: new DateTime(2024, 4, 4, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(6925));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 3L,
                column: "publication_date",
                value: new DateTime(2024, 3, 5, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(6927));

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 14, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(7000), new DateTime(2024, 4, 27, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(7007) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 5, 1, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(7101), new DateTime(2024, 5, 4, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(7102) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 5, 1, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(7104), new DateTime(2024, 5, 2, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(7105) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(7106), new DateTime(2024, 5, 8, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(7107) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 24, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(7109), new DateTime(2024, 5, 8, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(7110) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 24, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(7113), new DateTime(2024, 5, 8, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(7113) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "reservation_status",
                table: "reservations",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "lease_end_date_time", "lease_start_date_time" },
                values: new object[] { new DateTime(2024, 6, 3, 9, 29, 59, 28, DateTimeKind.Utc).AddTicks(808), new DateTime(2024, 4, 27, 9, 29, 59, 28, DateTimeKind.Utc).AddTicks(804) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "lease_end_date_time", "lease_start_date_time" },
                values: new object[] { new DateTime(2024, 5, 18, 9, 29, 59, 28, DateTimeKind.Utc).AddTicks(814), new DateTime(2024, 5, 4, 9, 29, 59, 28, DateTimeKind.Utc).AddTicks(814) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "lease_end_date_time", "lease_start_date_time" },
                values: new object[] { new DateTime(2024, 5, 5, 9, 29, 59, 28, DateTimeKind.Utc).AddTicks(816), new DateTime(2024, 5, 2, 9, 29, 59, 28, DateTimeKind.Utc).AddTicks(816) });

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(2024, 5, 2, 9, 29, 59, 28, DateTimeKind.Utc).AddTicks(949));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 5, 3, 9, 29, 59, 28, DateTimeKind.Utc).AddTicks(953));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 4, 28, 9, 29, 59, 28, DateTimeKind.Utc).AddTicks(954));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 1L,
                column: "publication_date",
                value: new DateTime(2024, 5, 3, 9, 29, 59, 28, DateTimeKind.Utc).AddTicks(760));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 2L,
                column: "publication_date",
                value: new DateTime(2024, 4, 4, 9, 29, 59, 28, DateTimeKind.Utc).AddTicks(772));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 3L,
                column: "publication_date",
                value: new DateTime(2024, 3, 5, 9, 29, 59, 28, DateTimeKind.Utc).AddTicks(774));

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 14, 9, 29, 59, 28, DateTimeKind.Utc).AddTicks(838), new DateTime(2024, 4, 27, 9, 29, 59, 28, DateTimeKind.Utc).AddTicks(840) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 5, 1, 9, 29, 59, 28, DateTimeKind.Utc).AddTicks(876), new DateTime(2024, 5, 4, 9, 29, 59, 28, DateTimeKind.Utc).AddTicks(877) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 5, 1, 9, 29, 59, 28, DateTimeKind.Utc).AddTicks(878), new DateTime(2024, 5, 2, 9, 29, 59, 28, DateTimeKind.Utc).AddTicks(879) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 5, 4, 9, 29, 59, 28, DateTimeKind.Utc).AddTicks(882), new DateTime(2024, 5, 8, 9, 29, 59, 28, DateTimeKind.Utc).AddTicks(882) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 24, 9, 29, 59, 28, DateTimeKind.Utc).AddTicks(884), new DateTime(2024, 5, 8, 9, 29, 59, 28, DateTimeKind.Utc).AddTicks(885) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 24, 9, 29, 59, 28, DateTimeKind.Utc).AddTicks(888), new DateTime(2024, 5, 8, 9, 29, 59, 28, DateTimeKind.Utc).AddTicks(889) });
        }
    }
}
