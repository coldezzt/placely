using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Placely.Main.Migrations
{
    /// <inheritdoc />
    public partial class replace_role_enum_with_strings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "reservations",
                newName: "status_type");

            migrationBuilder.AlterColumn<string>(
                name: "user_role",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "Tenant",
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 1);

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
                columns: new[] { "creation_date_time", "entry_date", "status_type" },
                values: new object[] { new DateTime(2024, 5, 21, 6, 23, 52, 759, DateTimeKind.Utc).AddTicks(9575), new DateTime(2024, 6, 3, 6, 23, 52, 759, DateTimeKind.Utc).AddTicks(9579), 3 });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "creation_date_time", "entry_date", "status_type" },
                values: new object[] { new DateTime(2024, 6, 7, 6, 23, 52, 759, DateTimeKind.Utc).AddTicks(9585), new DateTime(2024, 6, 10, 6, 23, 52, 759, DateTimeKind.Utc).AddTicks(9585), 3 });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "creation_date_time", "entry_date", "status_type" },
                values: new object[] { new DateTime(2024, 6, 7, 6, 23, 52, 759, DateTimeKind.Utc).AddTicks(9587), new DateTime(2024, 6, 8, 6, 23, 52, 759, DateTimeKind.Utc).AddTicks(9588), 3 });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "creation_date_time", "entry_date", "status_type" },
                values: new object[] { new DateTime(2024, 6, 10, 6, 23, 52, 759, DateTimeKind.Utc).AddTicks(9590), new DateTime(2024, 6, 14, 6, 23, 52, 759, DateTimeKind.Utc).AddTicks(9590), 1 });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "creation_date_time", "entry_date", "status_type" },
                values: new object[] { new DateTime(2024, 5, 31, 6, 23, 52, 759, DateTimeKind.Utc).AddTicks(9596), new DateTime(2024, 6, 14, 6, 23, 52, 759, DateTimeKind.Utc).AddTicks(9597), 4 });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "creation_date_time", "entry_date", "status_type" },
                values: new object[] { new DateTime(2024, 5, 31, 6, 23, 52, 759, DateTimeKind.Utc).AddTicks(9599), new DateTime(2024, 6, 14, 6, 23, 52, 759, DateTimeKind.Utc).AddTicks(9600), 2 });

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

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1L,
                column: "user_role",
                value: "Tenant");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 2L,
                column: "user_role",
                value: "Tenant");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 3L,
                column: "user_role",
                value: "Tenant");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 4L,
                column: "user_role",
                value: "Landlord");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 5L,
                column: "user_role",
                value: "Landlord");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 6L,
                column: "user_role",
                value: "Landlord");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status_type",
                table: "reservations",
                newName: "status");

            migrationBuilder.AlterColumn<int>(
                name: "user_role",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "Tenant");

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(2024, 6, 4, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2477));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 6, 5, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2479));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 5, 31, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2481));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateOnly(2024, 6, 6));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateOnly(2024, 6, 6));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateOnly(2024, 6, 6));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 4L,
                column: "date",
                value: new DateOnly(2024, 6, 6));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 5L,
                column: "date",
                value: new DateOnly(2024, 6, 6));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 6L,
                column: "date",
                value: new DateOnly(2024, 6, 6));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 1L,
                column: "publication_date",
                value: new DateTime(2024, 6, 5, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2346));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 2L,
                column: "publication_date",
                value: new DateTime(2024, 5, 7, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2358));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 3L,
                column: "publication_date",
                value: new DateTime(2024, 4, 7, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2360));

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "creation_date_time", "entry_date", "status" },
                values: new object[] { new DateTime(2024, 5, 17, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2400), new DateTime(2024, 5, 30, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2403), 2 });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "creation_date_time", "entry_date", "status" },
                values: new object[] { new DateTime(2024, 6, 3, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2408), new DateTime(2024, 6, 6, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2409), 2 });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "creation_date_time", "entry_date", "status" },
                values: new object[] { new DateTime(2024, 6, 3, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2410), new DateTime(2024, 6, 4, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2411), 2 });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "creation_date_time", "entry_date", "status" },
                values: new object[] { new DateTime(2024, 6, 6, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2413), new DateTime(2024, 6, 10, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2413), 0 });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "creation_date_time", "entry_date", "status" },
                values: new object[] { new DateTime(2024, 5, 27, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2418), new DateTime(2024, 6, 10, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2419), 3 });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "creation_date_time", "entry_date", "status" },
                values: new object[] { new DateTime(2024, 5, 27, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2421), new DateTime(2024, 6, 10, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2422), 1 });

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(2024, 6, 6, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2447));

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 6, 6, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2450));

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 6, 6, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2451));

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 4L,
                column: "date",
                value: new DateTime(2024, 6, 6, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2452));

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 5L,
                column: "date",
                value: new DateTime(2024, 6, 6, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2453));

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1L,
                column: "user_role",
                value: 1);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 2L,
                column: "user_role",
                value: 1);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 3L,
                column: "user_role",
                value: 1);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 4L,
                column: "user_role",
                value: 2);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 5L,
                column: "user_role",
                value: 2);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 6L,
                column: "user_role",
                value: 2);
        }
    }
}
