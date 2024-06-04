using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Placely.Main.Migrations
{
    /// <inheritdoc />
    public partial class _2fa_fields_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_two_factor_enabled",
                table: "tenants",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "qr_image_url",
                table: "tenants",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "two_factor_account_secret_key",
                table: "tenants",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 5, 25, 15, 32, 2, 195, DateTimeKind.Utc).AddTicks(5551), new DateTime(2024, 4, 18, 15, 32, 2, 195, DateTimeKind.Utc).AddTicks(5548) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 5, 9, 15, 32, 2, 195, DateTimeKind.Utc).AddTicks(5566), new DateTime(2024, 4, 25, 15, 32, 2, 195, DateTimeKind.Utc).AddTicks(5566) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 4, 26, 15, 32, 2, 195, DateTimeKind.Utc).AddTicks(5568), new DateTime(2024, 4, 23, 15, 32, 2, 195, DateTimeKind.Utc).AddTicks(5568) });

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(2024, 4, 23, 15, 32, 2, 195, DateTimeKind.Utc).AddTicks(5680));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 4, 24, 15, 32, 2, 195, DateTimeKind.Utc).AddTicks(5684));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 4, 19, 15, 32, 2, 195, DateTimeKind.Utc).AddTicks(5686));

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
                value: new DateTime(2024, 4, 24, 15, 32, 2, 195, DateTimeKind.Utc).AddTicks(5495));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 2L,
                column: "publication_date",
                value: new DateTime(2024, 3, 26, 15, 32, 2, 195, DateTimeKind.Utc).AddTicks(5515));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 3L,
                column: "publication_date",
                value: new DateTime(2024, 2, 25, 15, 32, 2, 195, DateTimeKind.Utc).AddTicks(5517));

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 5, 15, 32, 2, 195, DateTimeKind.Utc).AddTicks(5597), new DateTime(2024, 4, 18, 15, 32, 2, 195, DateTimeKind.Utc).AddTicks(5599) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 22, 15, 32, 2, 195, DateTimeKind.Utc).AddTicks(5603), new DateTime(2024, 4, 25, 15, 32, 2, 195, DateTimeKind.Utc).AddTicks(5603) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 22, 15, 32, 2, 195, DateTimeKind.Utc).AddTicks(5605), new DateTime(2024, 4, 23, 15, 32, 2, 195, DateTimeKind.Utc).AddTicks(5605) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 25, 15, 32, 2, 195, DateTimeKind.Utc).AddTicks(5607), new DateTime(2024, 4, 29, 15, 32, 2, 195, DateTimeKind.Utc).AddTicks(5607) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 15, 15, 32, 2, 195, DateTimeKind.Utc).AddTicks(5609), new DateTime(2024, 4, 29, 15, 32, 2, 195, DateTimeKind.Utc).AddTicks(5610) });

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "qr_image_url", "two_factor_account_secret_key" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "qr_image_url", "two_factor_account_secret_key" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "qr_image_url", "two_factor_account_secret_key" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "qr_image_url", "two_factor_account_secret_key" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "qr_image_url", "two_factor_account_secret_key" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "qr_image_url", "two_factor_account_secret_key" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_two_factor_enabled",
                table: "tenants");

            migrationBuilder.DropColumn(
                name: "qr_image_url",
                table: "tenants");

            migrationBuilder.DropColumn(
                name: "two_factor_account_secret_key",
                table: "tenants");

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 5, 24, 20, 21, 13, 983, DateTimeKind.Utc).AddTicks(3399), new DateTime(2024, 4, 17, 20, 21, 13, 983, DateTimeKind.Utc).AddTicks(3397) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 5, 8, 20, 21, 13, 983, DateTimeKind.Utc).AddTicks(3406), new DateTime(2024, 4, 24, 20, 21, 13, 983, DateTimeKind.Utc).AddTicks(3406) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 4, 25, 20, 21, 13, 983, DateTimeKind.Utc).AddTicks(3409), new DateTime(2024, 4, 22, 20, 21, 13, 983, DateTimeKind.Utc).AddTicks(3408) });

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(2024, 4, 22, 20, 21, 13, 983, DateTimeKind.Utc).AddTicks(3502));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 4, 23, 20, 21, 13, 983, DateTimeKind.Utc).AddTicks(3505));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 4, 18, 20, 21, 13, 983, DateTimeKind.Utc).AddTicks(3507));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateOnly(2024, 4, 24));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateOnly(2024, 4, 24));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateOnly(2024, 4, 24));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 4L,
                column: "date",
                value: new DateOnly(2024, 4, 24));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 5L,
                column: "date",
                value: new DateOnly(2024, 4, 24));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 6L,
                column: "date",
                value: new DateOnly(2024, 4, 24));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 1L,
                column: "publication_date",
                value: new DateTime(2024, 4, 23, 20, 21, 13, 983, DateTimeKind.Utc).AddTicks(3351));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 2L,
                column: "publication_date",
                value: new DateTime(2024, 3, 25, 20, 21, 13, 983, DateTimeKind.Utc).AddTicks(3373));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 3L,
                column: "publication_date",
                value: new DateTime(2024, 2, 24, 20, 21, 13, 983, DateTimeKind.Utc).AddTicks(3375));

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 4, 20, 21, 13, 983, DateTimeKind.Utc).AddTicks(3436), new DateTime(2024, 4, 17, 20, 21, 13, 983, DateTimeKind.Utc).AddTicks(3438) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 21, 20, 21, 13, 983, DateTimeKind.Utc).AddTicks(3441), new DateTime(2024, 4, 24, 20, 21, 13, 983, DateTimeKind.Utc).AddTicks(3442) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 21, 20, 21, 13, 983, DateTimeKind.Utc).AddTicks(3443), new DateTime(2024, 4, 22, 20, 21, 13, 983, DateTimeKind.Utc).AddTicks(3444) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 24, 20, 21, 13, 983, DateTimeKind.Utc).AddTicks(3445), new DateTime(2024, 4, 28, 20, 21, 13, 983, DateTimeKind.Utc).AddTicks(3446) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 14, 20, 21, 13, 983, DateTimeKind.Utc).AddTicks(3447), new DateTime(2024, 4, 28, 20, 21, 13, 983, DateTimeKind.Utc).AddTicks(3448) });
        }
    }
}
