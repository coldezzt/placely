using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Placely.Main.Migrations
{
    /// <inheritdoc />
    public partial class price_list_fixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "property_id",
                table: "prices");

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(2024, 6, 16, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(7112));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 6, 17, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(7117));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 6, 12, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(7119));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 1L,
                column: "publication_date",
                value: new DateTime(2024, 6, 17, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(6941));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 2L,
                column: "publication_date",
                value: new DateTime(2024, 5, 19, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(6956));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 3L,
                column: "publication_date",
                value: new DateTime(2024, 4, 19, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(6958));

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 5, 29, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(7011), new DateTime(2024, 6, 11, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(7020) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 6, 15, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(7026), new DateTime(2024, 6, 18, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(7027) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 6, 15, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(7029), new DateTime(2024, 6, 16, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(7030) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 6, 18, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(7032), new DateTime(2024, 6, 22, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(7033) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 6, 8, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(7039), new DateTime(2024, 6, 22, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(7039) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 6, 8, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(7042), new DateTime(2024, 6, 22, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(7043) });

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(2024, 6, 18, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(7072));

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 6, 18, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(7075));

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 6, 18, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(7076));

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 4L,
                column: "date",
                value: new DateTime(2024, 6, 18, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(7077));

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 5L,
                column: "date",
                value: new DateTime(2024, 6, 18, 3, 32, 31, 475, DateTimeKind.Utc).AddTicks(7079));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "property_id",
                table: "prices",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(2024, 6, 16, 3, 29, 50, 631, DateTimeKind.Utc).AddTicks(630));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 6, 17, 3, 29, 50, 631, DateTimeKind.Utc).AddTicks(634));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 6, 12, 3, 29, 50, 631, DateTimeKind.Utc).AddTicks(636));

            migrationBuilder.UpdateData(
                table: "prices",
                keyColumn: "id",
                keyValue: 1L,
                column: "property_id",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "prices",
                keyColumn: "id",
                keyValue: 2L,
                column: "property_id",
                value: 2L);

            migrationBuilder.UpdateData(
                table: "prices",
                keyColumn: "id",
                keyValue: 3L,
                column: "property_id",
                value: 3L);

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 1L,
                column: "publication_date",
                value: new DateTime(2024, 6, 17, 3, 29, 50, 631, DateTimeKind.Utc).AddTicks(375));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 2L,
                column: "publication_date",
                value: new DateTime(2024, 5, 19, 3, 29, 50, 631, DateTimeKind.Utc).AddTicks(390));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 3L,
                column: "publication_date",
                value: new DateTime(2024, 4, 19, 3, 29, 50, 631, DateTimeKind.Utc).AddTicks(392));

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 5, 29, 3, 29, 50, 631, DateTimeKind.Utc).AddTicks(496), new DateTime(2024, 6, 11, 3, 29, 50, 631, DateTimeKind.Utc).AddTicks(521) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 6, 15, 3, 29, 50, 631, DateTimeKind.Utc).AddTicks(528), new DateTime(2024, 6, 18, 3, 29, 50, 631, DateTimeKind.Utc).AddTicks(529) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 6, 15, 3, 29, 50, 631, DateTimeKind.Utc).AddTicks(531), new DateTime(2024, 6, 16, 3, 29, 50, 631, DateTimeKind.Utc).AddTicks(532) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 6, 18, 3, 29, 50, 631, DateTimeKind.Utc).AddTicks(534), new DateTime(2024, 6, 22, 3, 29, 50, 631, DateTimeKind.Utc).AddTicks(535) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 6, 8, 3, 29, 50, 631, DateTimeKind.Utc).AddTicks(542), new DateTime(2024, 6, 22, 3, 29, 50, 631, DateTimeKind.Utc).AddTicks(543) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 6, 8, 3, 29, 50, 631, DateTimeKind.Utc).AddTicks(546), new DateTime(2024, 6, 22, 3, 29, 50, 631, DateTimeKind.Utc).AddTicks(547) });

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(2024, 6, 18, 3, 29, 50, 631, DateTimeKind.Utc).AddTicks(591));

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 6, 18, 3, 29, 50, 631, DateTimeKind.Utc).AddTicks(594));

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 6, 18, 3, 29, 50, 631, DateTimeKind.Utc).AddTicks(595));

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 4L,
                column: "date",
                value: new DateTime(2024, 6, 18, 3, 29, 50, 631, DateTimeKind.Utc).AddTicks(597));

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 5L,
                column: "date",
                value: new DateTime(2024, 6, 18, 3, 29, 50, 631, DateTimeKind.Utc).AddTicks(598));
        }
    }
}
