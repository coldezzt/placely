using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Placely.Main.Migrations
{
    /// <inheritdoc />
    public partial class auth_fixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "work",
                table: "tenants",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "avatar_path",
                table: "tenants",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "about",
                table: "tenants",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 5, 18, 17, 1, 25, 143, DateTimeKind.Utc).AddTicks(6236), new DateTime(2024, 4, 11, 17, 1, 25, 143, DateTimeKind.Utc).AddTicks(6233) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 5, 2, 17, 1, 25, 143, DateTimeKind.Utc).AddTicks(6243), new DateTime(2024, 4, 18, 17, 1, 25, 143, DateTimeKind.Utc).AddTicks(6242) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 4, 19, 17, 1, 25, 143, DateTimeKind.Utc).AddTicks(6245), new DateTime(2024, 4, 16, 17, 1, 25, 143, DateTimeKind.Utc).AddTicks(6244) });

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(2024, 4, 16, 17, 1, 25, 143, DateTimeKind.Utc).AddTicks(6340));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 4, 17, 17, 1, 25, 143, DateTimeKind.Utc).AddTicks(6343));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 4, 12, 17, 1, 25, 143, DateTimeKind.Utc).AddTicks(6344));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateOnly(2024, 4, 18));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateOnly(2024, 4, 18));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateOnly(2024, 4, 18));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 4L,
                column: "date",
                value: new DateOnly(2024, 4, 18));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 5L,
                column: "date",
                value: new DateOnly(2024, 4, 18));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 6L,
                column: "date",
                value: new DateOnly(2024, 4, 18));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 1L,
                column: "publication_date",
                value: new DateTime(2024, 4, 17, 17, 1, 25, 143, DateTimeKind.Utc).AddTicks(6166));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 2L,
                column: "publication_date",
                value: new DateTime(2024, 3, 19, 17, 1, 25, 143, DateTimeKind.Utc).AddTicks(6207));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 3L,
                column: "publication_date",
                value: new DateTime(2024, 2, 18, 17, 1, 25, 143, DateTimeKind.Utc).AddTicks(6209));

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 3, 29, 17, 1, 25, 143, DateTimeKind.Utc).AddTicks(6267), new DateTime(2024, 4, 11, 17, 1, 25, 143, DateTimeKind.Utc).AddTicks(6269) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 15, 17, 1, 25, 143, DateTimeKind.Utc).AddTicks(6271), new DateTime(2024, 4, 18, 17, 1, 25, 143, DateTimeKind.Utc).AddTicks(6272) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 15, 17, 1, 25, 143, DateTimeKind.Utc).AddTicks(6273), new DateTime(2024, 4, 16, 17, 1, 25, 143, DateTimeKind.Utc).AddTicks(6274) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 18, 17, 1, 25, 143, DateTimeKind.Utc).AddTicks(6276), new DateTime(2024, 4, 22, 17, 1, 25, 143, DateTimeKind.Utc).AddTicks(6276) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 8, 17, 1, 25, 143, DateTimeKind.Utc).AddTicks(6278), new DateTime(2024, 4, 22, 17, 1, 25, 143, DateTimeKind.Utc).AddTicks(6279) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "work",
                table: "tenants",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "avatar_path",
                table: "tenants",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "about",
                table: "tenants",
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
                values: new object[] { new DateTime(2024, 5, 17, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6099), new DateTime(2024, 4, 10, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6096) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 5, 1, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6105), new DateTime(2024, 4, 17, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6105) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 4, 18, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6107), new DateTime(2024, 4, 15, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6106) });

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(2024, 4, 15, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6249));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 4, 16, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6251));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 4, 11, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6253));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateOnly(2024, 4, 17));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateOnly(2024, 4, 17));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateOnly(2024, 4, 17));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 4L,
                column: "date",
                value: new DateOnly(2024, 4, 17));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 5L,
                column: "date",
                value: new DateOnly(2024, 4, 17));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 6L,
                column: "date",
                value: new DateOnly(2024, 4, 17));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 1L,
                column: "publication_date",
                value: new DateTime(2024, 4, 16, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6024));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 2L,
                column: "publication_date",
                value: new DateTime(2024, 3, 18, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6067));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 3L,
                column: "publication_date",
                value: new DateTime(2024, 2, 17, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6070));

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 3, 28, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6133), new DateTime(2024, 4, 10, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6136) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 14, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6138), new DateTime(2024, 4, 17, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6139) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 14, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6180), new DateTime(2024, 4, 15, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6180) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 17, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6182), new DateTime(2024, 4, 21, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6183) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 7, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6185), new DateTime(2024, 4, 21, 16, 59, 56, 540, DateTimeKind.Utc).AddTicks(6186) });
        }
    }
}
