using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Placely.Main.Migrations
{
    /// <inheritdoc />
    public partial class add_field_to_review : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "rating",
                table: "reviews",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "reviews",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 5, 21, 8, 43, 26, 47, DateTimeKind.Utc).AddTicks(3499), new DateTime(2024, 4, 14, 8, 43, 26, 47, DateTimeKind.Utc).AddTicks(3497) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 5, 5, 8, 43, 26, 47, DateTimeKind.Utc).AddTicks(3506), new DateTime(2024, 4, 21, 8, 43, 26, 47, DateTimeKind.Utc).AddTicks(3505) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 4, 22, 8, 43, 26, 47, DateTimeKind.Utc).AddTicks(3508), new DateTime(2024, 4, 19, 8, 43, 26, 47, DateTimeKind.Utc).AddTicks(3507) });

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(2024, 4, 19, 8, 43, 26, 47, DateTimeKind.Utc).AddTicks(3653));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 4, 20, 8, 43, 26, 47, DateTimeKind.Utc).AddTicks(3655));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 4, 15, 8, 43, 26, 47, DateTimeKind.Utc).AddTicks(3657));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateOnly(2024, 4, 21));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateOnly(2024, 4, 21));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateOnly(2024, 4, 21));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 4L,
                column: "date",
                value: new DateOnly(2024, 4, 21));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 5L,
                column: "date",
                value: new DateOnly(2024, 4, 21));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 6L,
                column: "date",
                value: new DateOnly(2024, 4, 21));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 1L,
                column: "publication_date",
                value: new DateTime(2024, 4, 20, 8, 43, 26, 47, DateTimeKind.Utc).AddTicks(3394));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 2L,
                column: "publication_date",
                value: new DateTime(2024, 3, 22, 8, 43, 26, 47, DateTimeKind.Utc).AddTicks(3430));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 3L,
                column: "publication_date",
                value: new DateTime(2024, 2, 21, 8, 43, 26, 47, DateTimeKind.Utc).AddTicks(3433));

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 1, 8, 43, 26, 47, DateTimeKind.Utc).AddTicks(3567), new DateTime(2024, 4, 14, 8, 43, 26, 47, DateTimeKind.Utc).AddTicks(3569) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 18, 8, 43, 26, 47, DateTimeKind.Utc).AddTicks(3572), new DateTime(2024, 4, 21, 8, 43, 26, 47, DateTimeKind.Utc).AddTicks(3573) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 18, 8, 43, 26, 47, DateTimeKind.Utc).AddTicks(3574), new DateTime(2024, 4, 19, 8, 43, 26, 47, DateTimeKind.Utc).AddTicks(3575) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 21, 8, 43, 26, 47, DateTimeKind.Utc).AddTicks(3576), new DateTime(2024, 4, 25, 8, 43, 26, 47, DateTimeKind.Utc).AddTicks(3577) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 11, 8, 43, 26, 47, DateTimeKind.Utc).AddTicks(3579), new DateTime(2024, 4, 25, 8, 43, 26, 47, DateTimeKind.Utc).AddTicks(3579) });

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "date", "rating" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0 });

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "date", "rating" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.0 });

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "date", "rating" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.0 });

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "date", "rating" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.0 });

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "date", "rating" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date",
                table: "reviews");

            migrationBuilder.AlterColumn<long>(
                name: "rating",
                table: "reviews",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 5, 20, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(6852), new DateTime(2024, 4, 13, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(6849) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 5, 4, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(6859), new DateTime(2024, 4, 20, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(6859) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 4, 21, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(6862), new DateTime(2024, 4, 18, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(6861) });

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(2024, 4, 18, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(6968));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 4, 19, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(7011));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 4, 14, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(7013));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateOnly(2024, 4, 20));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateOnly(2024, 4, 20));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateOnly(2024, 4, 20));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 4L,
                column: "date",
                value: new DateOnly(2024, 4, 20));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 5L,
                column: "date",
                value: new DateOnly(2024, 4, 20));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 6L,
                column: "date",
                value: new DateOnly(2024, 4, 20));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 1L,
                column: "publication_date",
                value: new DateTime(2024, 4, 19, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(6739));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 2L,
                column: "publication_date",
                value: new DateTime(2024, 3, 21, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(6783));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 3L,
                column: "publication_date",
                value: new DateTime(2024, 2, 20, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(6786));

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 3, 31, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(6890), new DateTime(2024, 4, 13, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(6892) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 17, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(6894), new DateTime(2024, 4, 20, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(6895) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 17, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(6896), new DateTime(2024, 4, 18, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(6897) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 20, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(6899), new DateTime(2024, 4, 24, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(6899) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 10, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(6901), new DateTime(2024, 4, 24, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(6902) });

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 1L,
                column: "rating",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 2L,
                column: "rating",
                value: 2L);

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 3L,
                column: "rating",
                value: 3L);

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 4L,
                column: "rating",
                value: 4L);

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 5L,
                column: "rating",
                value: 5L);
        }
    }
}
