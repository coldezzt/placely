using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Placely.Main.Migrations
{
    /// <inheritdoc />
    public partial class some_property_fixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "landlord_id",
                table: "properties",
                type: "bigint",
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
                column: "date",
                value: new DateTime(2024, 4, 28, 9, 32, 23, 526, DateTimeKind.Utc).AddTicks(1026));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 4, 29, 9, 32, 23, 526, DateTimeKind.Utc).AddTicks(1028));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 4, 24, 9, 32, 23, 526, DateTimeKind.Utc).AddTicks(1030));

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
                columns: new[] { "landlord_id", "publication_date" },
                values: new object[] { null, new DateTime(2024, 4, 29, 9, 32, 23, 526, DateTimeKind.Utc).AddTicks(841) });

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "landlord_id", "publication_date" },
                values: new object[] { null, new DateTime(2024, 3, 31, 9, 32, 23, 526, DateTimeKind.Utc).AddTicks(849) });

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "landlord_id", "publication_date" },
                values: new object[] { null, new DateTime(2024, 3, 1, 9, 32, 23, 526, DateTimeKind.Utc).AddTicks(851) });

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
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 30, 9, 32, 23, 526, DateTimeKind.Utc).AddTicks(963), new DateTime(2024, 5, 4, 9, 32, 23, 526, DateTimeKind.Utc).AddTicks(964) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "creation_date_time", "entry_date", "reservation_status" },
                values: new object[] { new DateTime(2024, 4, 20, 9, 32, 23, 526, DateTimeKind.Utc).AddTicks(965), new DateTime(2024, 5, 4, 9, 32, 23, 526, DateTimeKind.Utc).AddTicks(966), 3 });

            migrationBuilder.InsertData(
                table: "reservations",
                columns: new[] { "id", "creation_date_time", "decline_reason", "duration", "entry_date", "guests_amount", "landlord_id", "property_id", "reservation_status", "tenant_id" },
                values: new object[] { 6L, new DateTime(2024, 4, 20, 9, 32, 23, 526, DateTimeKind.Utc).AddTicks(969), null, new TimeSpan(10, 0, 0, 0, 0), new DateTime(2024, 5, 4, 9, 32, 23, 526, DateTimeKind.Utc).AddTicks(969), (byte)2, 2L, 3L, 1, 1L });

            migrationBuilder.CreateIndex(
                name: "ix_properties_landlord_id",
                table: "properties",
                column: "landlord_id");

            migrationBuilder.AddForeignKey(
                name: "fk_properties_landlords_landlord_id",
                table: "properties",
                column: "landlord_id",
                principalTable: "landlords",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_properties_landlords_landlord_id",
                table: "properties");

            migrationBuilder.DropIndex(
                name: "ix_properties_landlord_id",
                table: "properties");

            migrationBuilder.DeleteData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 6L);

            migrationBuilder.DropColumn(
                name: "landlord_id",
                table: "properties");

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "lease_end_date_time", "lease_start_date_time" },
                values: new object[] { new DateTime(2024, 5, 28, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5669), new DateTime(2024, 4, 21, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5665) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "lease_end_date_time", "lease_start_date_time" },
                values: new object[] { new DateTime(2024, 5, 12, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5683), new DateTime(2024, 4, 28, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5683) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "lease_end_date_time", "lease_start_date_time" },
                values: new object[] { new DateTime(2024, 4, 29, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5685), new DateTime(2024, 4, 26, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5684) });

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(2024, 4, 26, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5783));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 4, 27, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5786));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 4, 22, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5788));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateOnly(2024, 4, 28));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateOnly(2024, 4, 28));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateOnly(2024, 4, 28));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 4L,
                column: "date",
                value: new DateOnly(2024, 4, 28));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 5L,
                column: "date",
                value: new DateOnly(2024, 4, 28));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 6L,
                column: "date",
                value: new DateOnly(2024, 4, 28));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 1L,
                column: "publication_date",
                value: new DateTime(2024, 4, 27, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5622));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 2L,
                column: "publication_date",
                value: new DateTime(2024, 3, 29, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5636));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 3L,
                column: "publication_date",
                value: new DateTime(2024, 2, 28, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5638));

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "creation_date_time", "entry_date", "reservation_status" },
                values: new object[] { new DateTime(2024, 4, 8, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5709), new DateTime(2024, 4, 21, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5710), 1 });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "creation_date_time", "entry_date", "reservation_status" },
                values: new object[] { new DateTime(2024, 4, 25, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5713), new DateTime(2024, 4, 28, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5714), 1 });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "creation_date_time", "entry_date", "reservation_status" },
                values: new object[] { new DateTime(2024, 4, 25, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5715), new DateTime(2024, 4, 26, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5716), 1 });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 28, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5718), new DateTime(2024, 5, 2, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5718) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "creation_date_time", "entry_date", "reservation_status" },
                values: new object[] { new DateTime(2024, 4, 18, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5720), new DateTime(2024, 5, 2, 15, 51, 34, 743, DateTimeKind.Utc).AddTicks(5721), 2 });
        }
    }
}
