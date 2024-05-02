using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Placely.Main.Migrations
{
    /// <inheritdoc />
    public partial class corrections_to_chat_and_message : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "avatar_path",
                table: "tenants");

            migrationBuilder.DropColumn(
                name: "file_path",
                table: "messages");

            migrationBuilder.RenameColumn(
                name: "directory_path",
                table: "chats",
                newName: "directory_name");

            migrationBuilder.AddColumn<string>(
                name: "file_name",
                table: "messages",
                type: "text",
                nullable: false,
                defaultValue: "");

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
                columns: new[] { "date", "file_name" },
                values: new object[] { new DateTime(2024, 4, 30, 17, 32, 17, 714, DateTimeKind.Utc).AddTicks(3414), "" });

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "date", "file_name" },
                values: new object[] { new DateTime(2024, 5, 1, 17, 32, 17, 714, DateTimeKind.Utc).AddTicks(3417), "" });

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "date", "file_name" },
                values: new object[] { new DateTime(2024, 4, 26, 17, 32, 17, 714, DateTimeKind.Utc).AddTicks(3419), "smt.txt" });

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
                columns: new[] { "creation_date_time", "entry_date", "reservation_status" },
                values: new object[] { new DateTime(2024, 4, 12, 17, 32, 17, 714, DateTimeKind.Utc).AddTicks(3334), new DateTime(2024, 4, 25, 17, 32, 17, 714, DateTimeKind.Utc).AddTicks(3336), 3 });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "creation_date_time", "entry_date", "reservation_status" },
                values: new object[] { new DateTime(2024, 4, 29, 17, 32, 17, 714, DateTimeKind.Utc).AddTicks(3339), new DateTime(2024, 5, 2, 17, 32, 17, 714, DateTimeKind.Utc).AddTicks(3340), 3 });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "creation_date_time", "entry_date", "reservation_status" },
                values: new object[] { new DateTime(2024, 4, 29, 17, 32, 17, 714, DateTimeKind.Utc).AddTicks(3341), new DateTime(2024, 4, 30, 17, 32, 17, 714, DateTimeKind.Utc).AddTicks(3343), 3 });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "creation_date_time", "entry_date", "reservation_status" },
                values: new object[] { new DateTime(2024, 5, 2, 17, 32, 17, 714, DateTimeKind.Utc).AddTicks(3344), new DateTime(2024, 5, 6, 17, 32, 17, 714, DateTimeKind.Utc).AddTicks(3345), 1 });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "creation_date_time", "entry_date", "reservation_status" },
                values: new object[] { new DateTime(2024, 4, 22, 17, 32, 17, 714, DateTimeKind.Utc).AddTicks(3346), new DateTime(2024, 5, 6, 17, 32, 17, 714, DateTimeKind.Utc).AddTicks(3347), 4 });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "creation_date_time", "entry_date", "reservation_status" },
                values: new object[] { new DateTime(2024, 4, 22, 17, 32, 17, 714, DateTimeKind.Utc).AddTicks(3350), new DateTime(2024, 5, 6, 17, 32, 17, 714, DateTimeKind.Utc).AddTicks(3351), 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "file_name",
                table: "messages");

            migrationBuilder.RenameColumn(
                name: "directory_name",
                table: "chats",
                newName: "directory_path");

            migrationBuilder.AddColumn<string>(
                name: "avatar_path",
                table: "tenants",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "file_path",
                table: "messages",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "lease_end_date_time", "lease_start_date_time" },
                values: new object[] { new DateTime(2024, 5, 30, 9, 32, 23, 526, DateTimeKind.Utc).AddTicks(875), new DateTime(2024, 4, 23, 9, 32, 23, 526, DateTimeKind.Utc).AddTicks(873) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "lease_end_date_time", "lease_start_date_time" },
                values: new object[] { new DateTime(2024, 5, 14, 9, 32, 23, 526, DateTimeKind.Utc).AddTicks(928), new DateTime(2024, 4, 30, 9, 32, 23, 526, DateTimeKind.Utc).AddTicks(927) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "lease_end_date_time", "lease_start_date_time" },
                values: new object[] { new DateTime(2024, 5, 1, 9, 32, 23, 526, DateTimeKind.Utc).AddTicks(930), new DateTime(2024, 4, 28, 9, 32, 23, 526, DateTimeKind.Utc).AddTicks(929) });

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "date", "file_path" },
                values: new object[] { new DateTime(2024, 4, 28, 9, 32, 23, 526, DateTimeKind.Utc).AddTicks(1026), null });

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "date", "file_path" },
                values: new object[] { new DateTime(2024, 4, 29, 9, 32, 23, 526, DateTimeKind.Utc).AddTicks(1028), null });

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "date", "file_path" },
                values: new object[] { new DateTime(2024, 4, 24, 9, 32, 23, 526, DateTimeKind.Utc).AddTicks(1030), "smt" });

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateOnly(2024, 4, 30));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateOnly(2024, 4, 30));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateOnly(2024, 4, 30));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 4L,
                column: "date",
                value: new DateOnly(2024, 4, 30));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 5L,
                column: "date",
                value: new DateOnly(2024, 4, 30));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 6L,
                column: "date",
                value: new DateOnly(2024, 4, 30));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 1L,
                column: "publication_date",
                value: new DateTime(2024, 4, 29, 9, 32, 23, 526, DateTimeKind.Utc).AddTicks(841));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 2L,
                column: "publication_date",
                value: new DateTime(2024, 3, 31, 9, 32, 23, 526, DateTimeKind.Utc).AddTicks(849));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 3L,
                column: "publication_date",
                value: new DateTime(2024, 3, 1, 9, 32, 23, 526, DateTimeKind.Utc).AddTicks(851));

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "creation_date_time", "entry_date", "reservation_status" },
                values: new object[] { new DateTime(2024, 4, 10, 9, 32, 23, 526, DateTimeKind.Utc).AddTicks(955), new DateTime(2024, 4, 23, 9, 32, 23, 526, DateTimeKind.Utc).AddTicks(956), 2 });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "creation_date_time", "entry_date", "reservation_status" },
                values: new object[] { new DateTime(2024, 4, 27, 9, 32, 23, 526, DateTimeKind.Utc).AddTicks(959), new DateTime(2024, 4, 30, 9, 32, 23, 526, DateTimeKind.Utc).AddTicks(960), 2 });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "creation_date_time", "entry_date", "reservation_status" },
                values: new object[] { new DateTime(2024, 4, 27, 9, 32, 23, 526, DateTimeKind.Utc).AddTicks(961), new DateTime(2024, 4, 28, 9, 32, 23, 526, DateTimeKind.Utc).AddTicks(962), 2 });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "creation_date_time", "entry_date", "reservation_status" },
                values: new object[] { new DateTime(2024, 4, 30, 9, 32, 23, 526, DateTimeKind.Utc).AddTicks(963), new DateTime(2024, 5, 4, 9, 32, 23, 526, DateTimeKind.Utc).AddTicks(964), 0 });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "creation_date_time", "entry_date", "reservation_status" },
                values: new object[] { new DateTime(2024, 4, 20, 9, 32, 23, 526, DateTimeKind.Utc).AddTicks(965), new DateTime(2024, 5, 4, 9, 32, 23, 526, DateTimeKind.Utc).AddTicks(966), 3 });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "creation_date_time", "entry_date", "reservation_status" },
                values: new object[] { new DateTime(2024, 4, 20, 9, 32, 23, 526, DateTimeKind.Utc).AddTicks(969), new DateTime(2024, 5, 4, 9, 32, 23, 526, DateTimeKind.Utc).AddTicks(969), 1 });

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 1L,
                column: "avatar_path",
                value: "");

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 2L,
                column: "avatar_path",
                value: "");

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 3L,
                column: "avatar_path",
                value: "");

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 4L,
                column: "avatar_path",
                value: "");

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 5L,
                column: "avatar_path",
                value: "");

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 6L,
                column: "avatar_path",
                value: "");
        }
    }
}
