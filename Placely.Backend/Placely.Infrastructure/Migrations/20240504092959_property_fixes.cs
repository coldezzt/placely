using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Placely.Main.Migrations
{
    /// <inheritdoc />
    public partial class property_fixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_properties_landlords_owner_id",
                table: "properties");

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
                table: "notifications",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateOnly(2024, 5, 4));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateOnly(2024, 5, 4));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateOnly(2024, 5, 4));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 4L,
                column: "date",
                value: new DateOnly(2024, 5, 4));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 5L,
                column: "date",
                value: new DateOnly(2024, 5, 4));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 6L,
                column: "date",
                value: new DateOnly(2024, 5, 4));

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

            migrationBuilder.AddForeignKey(
                name: "fk_properties_tenants_owner_id",
                table: "properties",
                column: "owner_id",
                principalTable: "tenants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_properties_tenants_owner_id",
                table: "properties");

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "lease_end_date_time", "lease_start_date_time" },
                values: new object[] { new DateTime(2024, 6, 1, 17, 32, 17, 714, DateTimeKind.Utc).AddTicks(3249), new DateTime(2024, 4, 25, 17, 32, 17, 714, DateTimeKind.Utc).AddTicks(3241) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "lease_end_date_time", "lease_start_date_time" },
                values: new object[] { new DateTime(2024, 5, 16, 17, 32, 17, 714, DateTimeKind.Utc).AddTicks(3256), new DateTime(2024, 5, 2, 17, 32, 17, 714, DateTimeKind.Utc).AddTicks(3255) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "lease_end_date_time", "lease_start_date_time" },
                values: new object[] { new DateTime(2024, 5, 3, 17, 32, 17, 714, DateTimeKind.Utc).AddTicks(3258), new DateTime(2024, 4, 30, 17, 32, 17, 714, DateTimeKind.Utc).AddTicks(3257) });

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(2024, 4, 30, 17, 32, 17, 714, DateTimeKind.Utc).AddTicks(3414));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 5, 1, 17, 32, 17, 714, DateTimeKind.Utc).AddTicks(3417));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 4, 26, 17, 32, 17, 714, DateTimeKind.Utc).AddTicks(3419));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateOnly(2024, 5, 2));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateOnly(2024, 5, 2));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateOnly(2024, 5, 2));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 4L,
                column: "date",
                value: new DateOnly(2024, 5, 2));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 5L,
                column: "date",
                value: new DateOnly(2024, 5, 2));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 6L,
                column: "date",
                value: new DateOnly(2024, 5, 2));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 1L,
                column: "publication_date",
                value: new DateTime(2024, 5, 1, 17, 32, 17, 714, DateTimeKind.Utc).AddTicks(3200));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 2L,
                column: "publication_date",
                value: new DateTime(2024, 4, 2, 17, 32, 17, 714, DateTimeKind.Utc).AddTicks(3214));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 3L,
                column: "publication_date",
                value: new DateTime(2024, 3, 3, 17, 32, 17, 714, DateTimeKind.Utc).AddTicks(3216));

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 12, 17, 32, 17, 714, DateTimeKind.Utc).AddTicks(3334), new DateTime(2024, 4, 25, 17, 32, 17, 714, DateTimeKind.Utc).AddTicks(3336) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 29, 17, 32, 17, 714, DateTimeKind.Utc).AddTicks(3339), new DateTime(2024, 5, 2, 17, 32, 17, 714, DateTimeKind.Utc).AddTicks(3340) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 29, 17, 32, 17, 714, DateTimeKind.Utc).AddTicks(3341), new DateTime(2024, 4, 30, 17, 32, 17, 714, DateTimeKind.Utc).AddTicks(3343) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 5, 2, 17, 32, 17, 714, DateTimeKind.Utc).AddTicks(3344), new DateTime(2024, 5, 6, 17, 32, 17, 714, DateTimeKind.Utc).AddTicks(3345) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 22, 17, 32, 17, 714, DateTimeKind.Utc).AddTicks(3346), new DateTime(2024, 5, 6, 17, 32, 17, 714, DateTimeKind.Utc).AddTicks(3347) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 22, 17, 32, 17, 714, DateTimeKind.Utc).AddTicks(3350), new DateTime(2024, 5, 6, 17, 32, 17, 714, DateTimeKind.Utc).AddTicks(3351) });

            migrationBuilder.AddForeignKey(
                name: "fk_properties_landlords_owner_id",
                table: "properties",
                column: "owner_id",
                principalTable: "landlords",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
