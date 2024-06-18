using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Placely.Main.Migrations
{
    /// <inheritdoc />
    public partial class contract_fixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "contract_id",
                table: "reservations");

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
                table: "notifications",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateOnly(2024, 6, 18));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateOnly(2024, 6, 18));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateOnly(2024, 6, 18));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 4L,
                column: "date",
                value: new DateOnly(2024, 6, 18));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 5L,
                column: "date",
                value: new DateOnly(2024, 6, 18));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 6L,
                column: "date",
                value: new DateOnly(2024, 6, 18));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "contract_id",
                table: "reservations",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(2024, 6, 8, 6, 23, 52, 759, DateTimeKind.Utc).AddTicks(9664));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 6, 9, 6, 23, 52, 759, DateTimeKind.Utc).AddTicks(9668));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 6, 4, 6, 23, 52, 759, DateTimeKind.Utc).AddTicks(9669));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateOnly(2024, 6, 10));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateOnly(2024, 6, 10));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateOnly(2024, 6, 10));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 4L,
                column: "date",
                value: new DateOnly(2024, 6, 10));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 5L,
                column: "date",
                value: new DateOnly(2024, 6, 10));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 6L,
                column: "date",
                value: new DateOnly(2024, 6, 10));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 1L,
                column: "publication_date",
                value: new DateTime(2024, 6, 9, 6, 23, 52, 759, DateTimeKind.Utc).AddTicks(9460));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 2L,
                column: "publication_date",
                value: new DateTime(2024, 5, 11, 6, 23, 52, 759, DateTimeKind.Utc).AddTicks(9474));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 3L,
                column: "publication_date",
                value: new DateTime(2024, 4, 11, 6, 23, 52, 759, DateTimeKind.Utc).AddTicks(9476));

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "contract_id", "creation_date_time", "entry_date" },
                values: new object[] { null, new DateTime(2024, 5, 21, 6, 23, 52, 759, DateTimeKind.Utc).AddTicks(9575), new DateTime(2024, 6, 3, 6, 23, 52, 759, DateTimeKind.Utc).AddTicks(9579) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "contract_id", "creation_date_time", "entry_date" },
                values: new object[] { null, new DateTime(2024, 6, 7, 6, 23, 52, 759, DateTimeKind.Utc).AddTicks(9585), new DateTime(2024, 6, 10, 6, 23, 52, 759, DateTimeKind.Utc).AddTicks(9585) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "contract_id", "creation_date_time", "entry_date" },
                values: new object[] { null, new DateTime(2024, 6, 7, 6, 23, 52, 759, DateTimeKind.Utc).AddTicks(9587), new DateTime(2024, 6, 8, 6, 23, 52, 759, DateTimeKind.Utc).AddTicks(9588) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "contract_id", "creation_date_time", "entry_date" },
                values: new object[] { null, new DateTime(2024, 6, 10, 6, 23, 52, 759, DateTimeKind.Utc).AddTicks(9590), new DateTime(2024, 6, 14, 6, 23, 52, 759, DateTimeKind.Utc).AddTicks(9590) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "contract_id", "creation_date_time", "entry_date" },
                values: new object[] { null, new DateTime(2024, 5, 31, 6, 23, 52, 759, DateTimeKind.Utc).AddTicks(9596), new DateTime(2024, 6, 14, 6, 23, 52, 759, DateTimeKind.Utc).AddTicks(9597) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "contract_id", "creation_date_time", "entry_date" },
                values: new object[] { null, new DateTime(2024, 5, 31, 6, 23, 52, 759, DateTimeKind.Utc).AddTicks(9599), new DateTime(2024, 6, 14, 6, 23, 52, 759, DateTimeKind.Utc).AddTicks(9600) });

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(2024, 6, 10, 6, 23, 52, 759, DateTimeKind.Utc).AddTicks(9630));

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 6, 10, 6, 23, 52, 759, DateTimeKind.Utc).AddTicks(9632));

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 6, 10, 6, 23, 52, 759, DateTimeKind.Utc).AddTicks(9634));

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 4L,
                column: "date",
                value: new DateTime(2024, 6, 10, 6, 23, 52, 759, DateTimeKind.Utc).AddTicks(9635));

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 5L,
                column: "date",
                value: new DateTime(2024, 6, 10, 6, 23, 52, 759, DateTimeKind.Utc).AddTicks(9636));
        }
    }
}
