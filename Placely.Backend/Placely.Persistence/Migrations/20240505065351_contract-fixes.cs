using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Placely.Main.Migrations
{
    /// <inheritdoc />
    public partial class contractfixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "finalized_path_pdf",
                table: "contracts",
                newName: "finalized_pdf_file_name");

            migrationBuilder.RenameColumn(
                name: "finalized_path_docx",
                table: "contracts",
                newName: "finalized_docx_file_name");

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "lease_end_date_time", "lease_start_date_time" },
                values: new object[] { new DateTime(2024, 6, 4, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6294), new DateTime(2024, 4, 28, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6291) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "lease_end_date_time", "lease_start_date_time" },
                values: new object[] { new DateTime(2024, 5, 19, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6300), new DateTime(2024, 5, 5, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6300) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "lease_end_date_time", "lease_start_date_time" },
                values: new object[] { new DateTime(2024, 5, 6, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6303), new DateTime(2024, 5, 3, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6302) });

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(2024, 5, 3, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6439));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 5, 4, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6443));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 4, 29, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6445));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateOnly(2024, 5, 5));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateOnly(2024, 5, 5));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateOnly(2024, 5, 5));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 4L,
                column: "date",
                value: new DateOnly(2024, 5, 5));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 5L,
                column: "date",
                value: new DateOnly(2024, 5, 5));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 6L,
                column: "date",
                value: new DateOnly(2024, 5, 5));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 1L,
                column: "publication_date",
                value: new DateTime(2024, 5, 4, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6249));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 2L,
                column: "publication_date",
                value: new DateTime(2024, 4, 5, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6259));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 3L,
                column: "publication_date",
                value: new DateTime(2024, 3, 6, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6260));

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "creation_date_time", "entry_date", "reservation_status" },
                values: new object[] { new DateTime(2024, 4, 15, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6356), new DateTime(2024, 4, 28, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6357), 2 });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "creation_date_time", "entry_date", "reservation_status" },
                values: new object[] { new DateTime(2024, 5, 2, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6360), new DateTime(2024, 5, 5, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6361), 2 });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "creation_date_time", "entry_date", "reservation_status" },
                values: new object[] { new DateTime(2024, 5, 2, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6362), new DateTime(2024, 5, 3, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6363), 2 });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "creation_date_time", "entry_date", "reservation_status" },
                values: new object[] { new DateTime(2024, 5, 5, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6364), new DateTime(2024, 5, 9, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6365), 0 });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "creation_date_time", "entry_date", "reservation_status" },
                values: new object[] { new DateTime(2024, 4, 25, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6366), new DateTime(2024, 5, 9, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6370), 3 });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "creation_date_time", "entry_date", "reservation_status" },
                values: new object[] { new DateTime(2024, 4, 25, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6373), new DateTime(2024, 5, 9, 6, 53, 51, 360, DateTimeKind.Utc).AddTicks(6374), 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "finalized_pdf_file_name",
                table: "contracts",
                newName: "finalized_path_pdf");

            migrationBuilder.RenameColumn(
                name: "finalized_docx_file_name",
                table: "contracts",
                newName: "finalized_path_docx");

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "lease_end_date_time", "lease_start_date_time" },
                values: new object[] { new DateTime(2024, 6, 3, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(6964), new DateTime(2024, 4, 27, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(6960) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "lease_end_date_time", "lease_start_date_time" },
                values: new object[] { new DateTime(2024, 5, 18, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(6971), new DateTime(2024, 5, 4, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(6970) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "lease_end_date_time", "lease_start_date_time" },
                values: new object[] { new DateTime(2024, 5, 5, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(6973), new DateTime(2024, 5, 2, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(6972) });

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(2024, 5, 2, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(7181));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 5, 3, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(7184));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 4, 28, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(7186));

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
                value: new DateTime(2024, 5, 3, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(6913));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 2L,
                column: "publication_date",
                value: new DateTime(2024, 4, 4, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(6925));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 3L,
                column: "publication_date",
                value: new DateTime(2024, 3, 5, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(6927));

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "creation_date_time", "entry_date", "reservation_status" },
                values: new object[] { new DateTime(2024, 4, 14, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(7000), new DateTime(2024, 4, 27, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(7007), 3 });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "creation_date_time", "entry_date", "reservation_status" },
                values: new object[] { new DateTime(2024, 5, 1, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(7101), new DateTime(2024, 5, 4, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(7102), 3 });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "creation_date_time", "entry_date", "reservation_status" },
                values: new object[] { new DateTime(2024, 5, 1, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(7104), new DateTime(2024, 5, 2, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(7105), 3 });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "creation_date_time", "entry_date", "reservation_status" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(7106), new DateTime(2024, 5, 8, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(7107), 1 });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "creation_date_time", "entry_date", "reservation_status" },
                values: new object[] { new DateTime(2024, 4, 24, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(7109), new DateTime(2024, 5, 8, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(7110), 4 });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "creation_date_time", "entry_date", "reservation_status" },
                values: new object[] { new DateTime(2024, 4, 24, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(7113), new DateTime(2024, 5, 8, 15, 27, 54, 93, DateTimeKind.Utc).AddTicks(7113), 2 });
        }
    }
}
