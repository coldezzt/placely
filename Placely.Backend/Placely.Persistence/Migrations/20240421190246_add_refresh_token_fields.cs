using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Placely.Main.Migrations
{
    /// <inheritdoc />
    public partial class add_refresh_token_fields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "user_role",
                table: "tenants",
                type: "integer",
                nullable: true,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "refresh_token",
                table: "tenants",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "refresh_token_expiration_date",
                table: "tenants",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 5, 21, 19, 2, 45, 848, DateTimeKind.Utc).AddTicks(4931), new DateTime(2024, 4, 14, 19, 2, 45, 848, DateTimeKind.Utc).AddTicks(4928) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 5, 5, 19, 2, 45, 848, DateTimeKind.Utc).AddTicks(4938), new DateTime(2024, 4, 21, 19, 2, 45, 848, DateTimeKind.Utc).AddTicks(4938) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 4, 22, 19, 2, 45, 848, DateTimeKind.Utc).AddTicks(4941), new DateTime(2024, 4, 19, 19, 2, 45, 848, DateTimeKind.Utc).AddTicks(4940) });

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(2024, 4, 19, 19, 2, 45, 848, DateTimeKind.Utc).AddTicks(5043));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 4, 20, 19, 2, 45, 848, DateTimeKind.Utc).AddTicks(5052));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 4, 15, 19, 2, 45, 848, DateTimeKind.Utc).AddTicks(5054));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 1L,
                column: "publication_date",
                value: new DateTime(2024, 4, 20, 19, 2, 45, 848, DateTimeKind.Utc).AddTicks(4880));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 2L,
                column: "publication_date",
                value: new DateTime(2024, 3, 22, 19, 2, 45, 848, DateTimeKind.Utc).AddTicks(4898));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 3L,
                column: "publication_date",
                value: new DateTime(2024, 2, 21, 19, 2, 45, 848, DateTimeKind.Utc).AddTicks(4900));

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 1, 19, 2, 45, 848, DateTimeKind.Utc).AddTicks(4966), new DateTime(2024, 4, 14, 19, 2, 45, 848, DateTimeKind.Utc).AddTicks(4974) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 18, 19, 2, 45, 848, DateTimeKind.Utc).AddTicks(4976), new DateTime(2024, 4, 21, 19, 2, 45, 848, DateTimeKind.Utc).AddTicks(4977) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 18, 19, 2, 45, 848, DateTimeKind.Utc).AddTicks(4978), new DateTime(2024, 4, 19, 19, 2, 45, 848, DateTimeKind.Utc).AddTicks(4979) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 21, 19, 2, 45, 848, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 4, 25, 19, 2, 45, 848, DateTimeKind.Utc).AddTicks(4981) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 11, 19, 2, 45, 848, DateTimeKind.Utc).AddTicks(4983), new DateTime(2024, 4, 25, 19, 2, 45, 848, DateTimeKind.Utc).AddTicks(4984) });

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "refresh_token", "refresh_token_expiration_date" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "refresh_token", "refresh_token_expiration_date" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "refresh_token", "refresh_token_expiration_date" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "refresh_token", "refresh_token_expiration_date" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "refresh_token", "refresh_token_expiration_date" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "refresh_token", "refresh_token_expiration_date" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "refresh_token",
                table: "tenants");

            migrationBuilder.DropColumn(
                name: "refresh_token_expiration_date",
                table: "tenants");

            migrationBuilder.AlterColumn<int>(
                name: "user_role",
                table: "tenants",
                type: "integer",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true,
                oldDefaultValue: 1);

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
        }
    }
}
