using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Placely.Main.Migrations
{
    /// <inheritdoc />
    public partial class add_field_for_registration_new_user_via_oauth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_additional_registration_required",
                table: "tenants",
                type: "boolean",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_additional_registration_required",
                table: "tenants");

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
        }
    }
}
