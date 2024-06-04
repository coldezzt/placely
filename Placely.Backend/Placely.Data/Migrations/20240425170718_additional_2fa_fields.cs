using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Placely.Main.Migrations
{
    /// <inheritdoc />
    public partial class additional_2fa_fields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "manual_entry_key",
                table: "tenants",
                type: "text",
                nullable: true);

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

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 1L,
                column: "manual_entry_key",
                value: null);

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 2L,
                column: "manual_entry_key",
                value: null);

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 3L,
                column: "manual_entry_key",
                value: null);

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 4L,
                column: "manual_entry_key",
                value: null);

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 5L,
                column: "manual_entry_key",
                value: null);

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 6L,
                column: "manual_entry_key",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "manual_entry_key",
                table: "tenants");

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
        }
    }
}
