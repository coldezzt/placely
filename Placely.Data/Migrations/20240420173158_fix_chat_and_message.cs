using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Placely.Main.Migrations
{
    /// <inheritdoc />
    public partial class fix_chat_and_message : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_chats_landlords_landlord_id",
                table: "chats");

            migrationBuilder.DropForeignKey(
                name: "fk_chats_tenants_tenant_id",
                table: "chats");

            migrationBuilder.RenameColumn(
                name: "tenant_id",
                table: "chats",
                newName: "second_user_id");

            migrationBuilder.RenameColumn(
                name: "landlord_id",
                table: "chats",
                newName: "first_user_id");

            migrationBuilder.RenameIndex(
                name: "ix_chats_tenant_id",
                table: "chats",
                newName: "ix_chats_second_user_id");

            migrationBuilder.RenameIndex(
                name: "ix_chats_landlord_id",
                table: "chats",
                newName: "ix_chats_first_user_id");

            migrationBuilder.UpdateData(
                table: "chats",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "first_user_id", "second_user_id" },
                values: new object[] { 2L, 1L });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 5, 20, 17, 31, 57, 891, DateTimeKind.Utc).AddTicks(7982), new DateTime(2024, 4, 13, 17, 31, 57, 891, DateTimeKind.Utc).AddTicks(7980) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 5, 4, 17, 31, 57, 891, DateTimeKind.Utc).AddTicks(7990), new DateTime(2024, 4, 20, 17, 31, 57, 891, DateTimeKind.Utc).AddTicks(7989) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 4, 21, 17, 31, 57, 891, DateTimeKind.Utc).AddTicks(7992), new DateTime(2024, 4, 18, 17, 31, 57, 891, DateTimeKind.Utc).AddTicks(7991) });

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(2024, 4, 18, 17, 31, 57, 891, DateTimeKind.Utc).AddTicks(8091));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 4, 19, 17, 31, 57, 891, DateTimeKind.Utc).AddTicks(8094));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 4, 14, 17, 31, 57, 891, DateTimeKind.Utc).AddTicks(8096));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateOnly(2024, 4, 20));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateOnly(2024, 4, 20));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateOnly(2024, 4, 20));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 4L,
                column: "date",
                value: new DateOnly(2024, 4, 20));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 5L,
                column: "date",
                value: new DateOnly(2024, 4, 20));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 6L,
                column: "date",
                value: new DateOnly(2024, 4, 20));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 1L,
                column: "publication_date",
                value: new DateTime(2024, 4, 19, 17, 31, 57, 891, DateTimeKind.Utc).AddTicks(7902));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 2L,
                column: "publication_date",
                value: new DateTime(2024, 3, 21, 17, 31, 57, 891, DateTimeKind.Utc).AddTicks(7947));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 3L,
                column: "publication_date",
                value: new DateTime(2024, 2, 20, 17, 31, 57, 891, DateTimeKind.Utc).AddTicks(7949));

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 3, 31, 17, 31, 57, 891, DateTimeKind.Utc).AddTicks(8014), new DateTime(2024, 4, 13, 17, 31, 57, 891, DateTimeKind.Utc).AddTicks(8016) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 17, 17, 31, 57, 891, DateTimeKind.Utc).AddTicks(8019), new DateTime(2024, 4, 20, 17, 31, 57, 891, DateTimeKind.Utc).AddTicks(8020) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 17, 17, 31, 57, 891, DateTimeKind.Utc).AddTicks(8021), new DateTime(2024, 4, 18, 17, 31, 57, 891, DateTimeKind.Utc).AddTicks(8022) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 20, 17, 31, 57, 891, DateTimeKind.Utc).AddTicks(8023), new DateTime(2024, 4, 24, 17, 31, 57, 891, DateTimeKind.Utc).AddTicks(8024) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 10, 17, 31, 57, 891, DateTimeKind.Utc).AddTicks(8026), new DateTime(2024, 4, 24, 17, 31, 57, 891, DateTimeKind.Utc).AddTicks(8026) });

            migrationBuilder.AddForeignKey(
                name: "fk_chats_landlords_second_user_id",
                table: "chats",
                column: "second_user_id",
                principalTable: "landlords",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_chats_tenants_first_user_id",
                table: "chats",
                column: "first_user_id",
                principalTable: "tenants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_chats_landlords_second_user_id",
                table: "chats");

            migrationBuilder.DropForeignKey(
                name: "fk_chats_tenants_first_user_id",
                table: "chats");

            migrationBuilder.RenameColumn(
                name: "second_user_id",
                table: "chats",
                newName: "tenant_id");

            migrationBuilder.RenameColumn(
                name: "first_user_id",
                table: "chats",
                newName: "landlord_id");

            migrationBuilder.RenameIndex(
                name: "ix_chats_second_user_id",
                table: "chats",
                newName: "ix_chats_tenant_id");

            migrationBuilder.RenameIndex(
                name: "ix_chats_first_user_id",
                table: "chats",
                newName: "ix_chats_landlord_id");

            migrationBuilder.UpdateData(
                table: "chats",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "landlord_id", "tenant_id" },
                values: new object[] { 1L, 2L });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 5, 18, 19, 0, 44, 626, DateTimeKind.Utc).AddTicks(910), new DateTime(2024, 4, 11, 19, 0, 44, 626, DateTimeKind.Utc).AddTicks(907) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 5, 2, 19, 0, 44, 626, DateTimeKind.Utc).AddTicks(916), new DateTime(2024, 4, 18, 19, 0, 44, 626, DateTimeKind.Utc).AddTicks(916) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 4, 19, 19, 0, 44, 626, DateTimeKind.Utc).AddTicks(919), new DateTime(2024, 4, 16, 19, 0, 44, 626, DateTimeKind.Utc).AddTicks(918) });

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(2024, 4, 16, 19, 0, 44, 626, DateTimeKind.Utc).AddTicks(1013));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 4, 17, 19, 0, 44, 626, DateTimeKind.Utc).AddTicks(1016));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 4, 12, 19, 0, 44, 626, DateTimeKind.Utc).AddTicks(1018));

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
                value: new DateTime(2024, 4, 17, 19, 0, 44, 626, DateTimeKind.Utc).AddTicks(832));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 2L,
                column: "publication_date",
                value: new DateTime(2024, 3, 19, 19, 0, 44, 626, DateTimeKind.Utc).AddTicks(873));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 3L,
                column: "publication_date",
                value: new DateTime(2024, 2, 18, 19, 0, 44, 626, DateTimeKind.Utc).AddTicks(875));

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 3, 29, 19, 0, 44, 626, DateTimeKind.Utc).AddTicks(942), new DateTime(2024, 4, 11, 19, 0, 44, 626, DateTimeKind.Utc).AddTicks(943) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 15, 19, 0, 44, 626, DateTimeKind.Utc).AddTicks(946), new DateTime(2024, 4, 18, 19, 0, 44, 626, DateTimeKind.Utc).AddTicks(947) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 15, 19, 0, 44, 626, DateTimeKind.Utc).AddTicks(948), new DateTime(2024, 4, 16, 19, 0, 44, 626, DateTimeKind.Utc).AddTicks(949) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 18, 19, 0, 44, 626, DateTimeKind.Utc).AddTicks(951), new DateTime(2024, 4, 22, 19, 0, 44, 626, DateTimeKind.Utc).AddTicks(952) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 8, 19, 0, 44, 626, DateTimeKind.Utc).AddTicks(953), new DateTime(2024, 4, 22, 19, 0, 44, 626, DateTimeKind.Utc).AddTicks(954) });

            migrationBuilder.AddForeignKey(
                name: "fk_chats_landlords_landlord_id",
                table: "chats",
                column: "landlord_id",
                principalTable: "landlords",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_chats_tenants_tenant_id",
                table: "chats",
                column: "tenant_id",
                principalTable: "tenants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
