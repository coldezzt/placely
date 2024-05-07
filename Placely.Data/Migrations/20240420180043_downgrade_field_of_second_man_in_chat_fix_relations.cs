using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Placely.Main.Migrations
{
    /// <inheritdoc />
    public partial class downgrade_field_of_second_man_in_chat_fix_relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_chats_landlords_second_user_id",
                table: "chats");

            migrationBuilder.AlterColumn<int>(
                name: "user_role",
                table: "tenants",
                type: "integer",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<long>(
                name: "landlord_id",
                table: "chats",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "tenant_id",
                table: "chats",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "chats",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "landlord_id", "tenant_id" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "chats",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "landlord_id", "tenant_id" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "chats",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "landlord_id", "tenant_id" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 5, 20, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(6852), new DateTime(2024, 4, 13, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(6849) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 5, 4, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(6859), new DateTime(2024, 4, 20, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(6859) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "lease_end_date", "lease_start_date" },
                values: new object[] { new DateTime(2024, 4, 21, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(6862), new DateTime(2024, 4, 18, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(6861) });

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(2024, 4, 18, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(6968));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 4, 19, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(7011));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 4, 14, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(7013));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 1L,
                column: "publication_date",
                value: new DateTime(2024, 4, 19, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(6739));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 2L,
                column: "publication_date",
                value: new DateTime(2024, 3, 21, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(6783));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 3L,
                column: "publication_date",
                value: new DateTime(2024, 2, 20, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(6786));

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 3, 31, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(6890), new DateTime(2024, 4, 13, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(6892) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 17, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(6894), new DateTime(2024, 4, 20, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(6895) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 17, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(6896), new DateTime(2024, 4, 18, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(6897) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 20, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(6899), new DateTime(2024, 4, 24, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(6899) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 10, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(6901), new DateTime(2024, 4, 24, 18, 0, 42, 906, DateTimeKind.Utc).AddTicks(6902) });

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 1L,
                column: "user_role",
                value: 1);

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 2L,
                column: "user_role",
                value: 1);

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 3L,
                column: "user_role",
                value: 1);

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 4L,
                column: "user_role",
                value: 1);

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 5L,
                column: "user_role",
                value: 1);

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 6L,
                column: "user_role",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "ix_chats_landlord_id",
                table: "chats",
                column: "landlord_id");

            migrationBuilder.CreateIndex(
                name: "ix_chats_tenant_id",
                table: "chats",
                column: "tenant_id");

            migrationBuilder.AddForeignKey(
                name: "fk_chats_landlords_landlord_id",
                table: "chats",
                column: "landlord_id",
                principalTable: "landlords",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_chats_tenants_second_user_id",
                table: "chats",
                column: "second_user_id",
                principalTable: "tenants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_chats_tenants_tenant_id",
                table: "chats",
                column: "tenant_id",
                principalTable: "tenants",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_chats_landlords_landlord_id",
                table: "chats");

            migrationBuilder.DropForeignKey(
                name: "fk_chats_tenants_second_user_id",
                table: "chats");

            migrationBuilder.DropForeignKey(
                name: "fk_chats_tenants_tenant_id",
                table: "chats");

            migrationBuilder.DropIndex(
                name: "ix_chats_landlord_id",
                table: "chats");

            migrationBuilder.DropIndex(
                name: "ix_chats_tenant_id",
                table: "chats");

            migrationBuilder.DropColumn(
                name: "landlord_id",
                table: "chats");

            migrationBuilder.DropColumn(
                name: "tenant_id",
                table: "chats");

            migrationBuilder.AlterColumn<int>(
                name: "user_role",
                table: "tenants",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 1);

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

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 1L,
                column: "user_role",
                value: 0);

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 2L,
                column: "user_role",
                value: 0);

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 3L,
                column: "user_role",
                value: 0);

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 4L,
                column: "user_role",
                value: 0);

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 5L,
                column: "user_role",
                value: 0);

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 6L,
                column: "user_role",
                value: 0);

            migrationBuilder.AddForeignKey(
                name: "fk_chats_landlords_second_user_id",
                table: "chats",
                column: "second_user_id",
                principalTable: "landlords",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
