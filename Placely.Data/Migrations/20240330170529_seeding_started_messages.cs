using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Placely.Main.Migrations
{
    /// <inheritdoc />
    public partial class seeding_started_messages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "file_path",
                table: "messages",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 4, 29, 17, 5, 29, 513, DateTimeKind.Utc).AddTicks(7267), new DateTime(2024, 3, 23, 17, 5, 29, 513, DateTimeKind.Utc).AddTicks(7257) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 4, 13, 17, 5, 29, 513, DateTimeKind.Utc).AddTicks(7274), new DateTime(2024, 3, 30, 17, 5, 29, 513, DateTimeKind.Utc).AddTicks(7274) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 3, 31, 17, 5, 29, 513, DateTimeKind.Utc).AddTicks(7276), new DateTime(2024, 3, 28, 17, 5, 29, 513, DateTimeKind.Utc).AddTicks(7276) });

            migrationBuilder.InsertData(
                table: "messages",
                columns: new[] { "id", "author_id", "chat_id", "content", "date", "file_path" },
                values: new object[,]
                {
                    { 1L, 1L, 1L, "message 1", new DateTime(2024, 3, 28, 17, 5, 29, 513, DateTimeKind.Utc).AddTicks(7368), null },
                    { 2L, 4L, 1L, "message 2", new DateTime(2024, 3, 29, 17, 5, 29, 513, DateTimeKind.Utc).AddTicks(7371), null },
                    { 3L, 2L, 2L, "message with file", new DateTime(2024, 3, 24, 17, 5, 29, 513, DateTimeKind.Utc).AddTicks(7372), "smt" }
                });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 3, 10, 17, 5, 29, 513, DateTimeKind.Utc).AddTicks(7299), new DateTime(2024, 3, 23, 17, 5, 29, 513, DateTimeKind.Utc).AddTicks(7300) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 3, 27, 17, 5, 29, 513, DateTimeKind.Utc).AddTicks(7303), new DateTime(2024, 3, 30, 17, 5, 29, 513, DateTimeKind.Utc).AddTicks(7304) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 3, 27, 17, 5, 29, 513, DateTimeKind.Utc).AddTicks(7306), new DateTime(2024, 3, 28, 17, 5, 29, 513, DateTimeKind.Utc).AddTicks(7307) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 3, 30, 17, 5, 29, 513, DateTimeKind.Utc).AddTicks(7308), new DateTime(2024, 4, 3, 17, 5, 29, 513, DateTimeKind.Utc).AddTicks(7309) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 3, 20, 17, 5, 29, 513, DateTimeKind.Utc).AddTicks(7310), new DateTime(2024, 4, 3, 17, 5, 29, 513, DateTimeKind.Utc).AddTicks(7311) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "messages",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "messages",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "messages",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.AlterColumn<string>(
                name: "file_path",
                table: "messages",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 4, 29, 16, 59, 33, 591, DateTimeKind.Utc).AddTicks(8565), new DateTime(2024, 3, 23, 16, 59, 33, 591, DateTimeKind.Utc).AddTicks(8554) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 4, 13, 16, 59, 33, 591, DateTimeKind.Utc).AddTicks(8573), new DateTime(2024, 3, 30, 16, 59, 33, 591, DateTimeKind.Utc).AddTicks(8573) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 3, 31, 16, 59, 33, 591, DateTimeKind.Utc).AddTicks(8575), new DateTime(2024, 3, 28, 16, 59, 33, 591, DateTimeKind.Utc).AddTicks(8575) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 3, 10, 16, 59, 33, 591, DateTimeKind.Utc).AddTicks(8598), new DateTime(2024, 3, 23, 16, 59, 33, 591, DateTimeKind.Utc).AddTicks(8599) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 3, 27, 16, 59, 33, 591, DateTimeKind.Utc).AddTicks(8602), new DateTime(2024, 3, 30, 16, 59, 33, 591, DateTimeKind.Utc).AddTicks(8603) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 3, 27, 16, 59, 33, 591, DateTimeKind.Utc).AddTicks(8604), new DateTime(2024, 3, 28, 16, 59, 33, 591, DateTimeKind.Utc).AddTicks(8605) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 3, 30, 16, 59, 33, 591, DateTimeKind.Utc).AddTicks(8607), new DateTime(2024, 4, 3, 16, 59, 33, 591, DateTimeKind.Utc).AddTicks(8607) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 3, 20, 16, 59, 33, 591, DateTimeKind.Utc).AddTicks(8609), new DateTime(2024, 4, 3, 16, 59, 33, 591, DateTimeKind.Utc).AddTicks(8610) });
        }
    }
}
