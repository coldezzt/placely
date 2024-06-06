using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Placely.Main.Migrations
{
    /// <inheritdoc />
    public partial class fix_properties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_chat_user_tenants_participants_id",
                table: "chat_user");

            migrationBuilder.DropForeignKey(
                name: "fk_messages_tenants_author_id",
                table: "messages");

            migrationBuilder.DropForeignKey(
                name: "fk_notifications_tenants_receiver_id",
                table: "notifications");

            migrationBuilder.DropForeignKey(
                name: "fk_previous_passwords_tenants_tenant_id",
                table: "previous_passwords");

            migrationBuilder.DropForeignKey(
                name: "fk_properties_tenants_owner_id",
                table: "properties");

            migrationBuilder.DropForeignKey(
                name: "fk_property_user_tenants_favourites_id",
                table: "property_user");

            migrationBuilder.DropForeignKey(
                name: "fk_reservation_user_tenants_participants_id",
                table: "reservation_user");

            migrationBuilder.DropForeignKey(
                name: "fk_reviews_tenants_author_id",
                table: "reviews");

            migrationBuilder.DropPrimaryKey(
                name: "pk_tenants",
                table: "tenants");

            migrationBuilder.RenameTable(
                name: "tenants",
                newName: "users");

            migrationBuilder.RenameColumn(
                name: "tenant_id",
                table: "previous_passwords",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "ix_previous_passwords_tenant_id",
                table: "previous_passwords",
                newName: "ix_previous_passwords_user_id");

            migrationBuilder.AlterColumn<string>(
                name: "content",
                table: "reviews",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "reservations",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "content",
                table: "notifications",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "file_name",
                table: "messages",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "user_role",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true,
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "phone_number",
                table: "users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "pk_users",
                table: "users",
                column: "id");

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(2024, 6, 4, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2477));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 6, 5, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2479));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 5, 31, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2481));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateOnly(2024, 6, 6));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateOnly(2024, 6, 6));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateOnly(2024, 6, 6));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 4L,
                column: "date",
                value: new DateOnly(2024, 6, 6));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 5L,
                column: "date",
                value: new DateOnly(2024, 6, 6));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 6L,
                column: "date",
                value: new DateOnly(2024, 6, 6));

            migrationBuilder.UpdateData(
                table: "prices",
                keyColumn: "id",
                keyValue: 1L,
                column: "property_id",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "prices",
                keyColumn: "id",
                keyValue: 2L,
                column: "property_id",
                value: 2L);

            migrationBuilder.UpdateData(
                table: "prices",
                keyColumn: "id",
                keyValue: 3L,
                column: "property_id",
                value: 3L);

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 1L,
                column: "publication_date",
                value: new DateTime(2024, 6, 5, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2346));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 2L,
                column: "publication_date",
                value: new DateTime(2024, 5, 7, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2358));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 3L,
                column: "publication_date",
                value: new DateTime(2024, 4, 7, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2360));

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 5, 17, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2400), new DateTime(2024, 5, 30, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2403) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 6, 3, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2408), new DateTime(2024, 6, 6, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2409) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 6, 3, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2410), new DateTime(2024, 6, 4, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2411) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 6, 6, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2413), new DateTime(2024, 6, 10, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2413) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 5, 27, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2418), new DateTime(2024, 6, 10, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2419) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 5, 27, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2421), new DateTime(2024, 6, 10, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2422) });

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(2024, 6, 6, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2447));

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 6, 6, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2450));

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 6, 6, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2451));

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 4L,
                column: "date",
                value: new DateTime(2024, 6, 6, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2452));

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 5L,
                column: "date",
                value: new DateTime(2024, 6, 6, 4, 47, 49, 625, DateTimeKind.Utc).AddTicks(2453));

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 4L,
                column: "user_role",
                value: 2);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 5L,
                column: "user_role",
                value: 2);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 6L,
                column: "user_role",
                value: 2);

            migrationBuilder.AddForeignKey(
                name: "fk_chat_user_users_participants_id",
                table: "chat_user",
                column: "participants_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_messages_users_author_id",
                table: "messages",
                column: "author_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_notifications_users_receiver_id",
                table: "notifications",
                column: "receiver_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_previous_passwords_users_user_id",
                table: "previous_passwords",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_properties_users_owner_id",
                table: "properties",
                column: "owner_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_property_user_users_favourites_id",
                table: "property_user",
                column: "favourites_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_reservation_user_users_participants_id",
                table: "reservation_user",
                column: "participants_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_reviews_users_author_id",
                table: "reviews",
                column: "author_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_chat_user_users_participants_id",
                table: "chat_user");

            migrationBuilder.DropForeignKey(
                name: "fk_messages_users_author_id",
                table: "messages");

            migrationBuilder.DropForeignKey(
                name: "fk_notifications_users_receiver_id",
                table: "notifications");

            migrationBuilder.DropForeignKey(
                name: "fk_previous_passwords_users_user_id",
                table: "previous_passwords");

            migrationBuilder.DropForeignKey(
                name: "fk_properties_users_owner_id",
                table: "properties");

            migrationBuilder.DropForeignKey(
                name: "fk_property_user_users_favourites_id",
                table: "property_user");

            migrationBuilder.DropForeignKey(
                name: "fk_reservation_user_users_participants_id",
                table: "reservation_user");

            migrationBuilder.DropForeignKey(
                name: "fk_reviews_users_author_id",
                table: "reviews");

            migrationBuilder.DropPrimaryKey(
                name: "pk_users",
                table: "users");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "tenants");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "previous_passwords",
                newName: "tenant_id");

            migrationBuilder.RenameIndex(
                name: "ix_previous_passwords_user_id",
                table: "previous_passwords",
                newName: "ix_previous_passwords_tenant_id");

            migrationBuilder.AlterColumn<string>(
                name: "content",
                table: "reviews",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "reservations",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "content",
                table: "notifications",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "file_name",
                table: "messages",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "user_role",
                table: "tenants",
                type: "integer",
                nullable: true,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "phone_number",
                table: "tenants",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "tenants",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "tenants",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "tenants",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_tenants",
                table: "tenants",
                column: "id");

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(2024, 6, 3, 8, 14, 5, 602, DateTimeKind.Utc).AddTicks(704));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 6, 4, 8, 14, 5, 602, DateTimeKind.Utc).AddTicks(713));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 5, 30, 8, 14, 5, 602, DateTimeKind.Utc).AddTicks(715));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateOnly(2024, 6, 5));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateOnly(2024, 6, 5));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateOnly(2024, 6, 5));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 4L,
                column: "date",
                value: new DateOnly(2024, 6, 5));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 5L,
                column: "date",
                value: new DateOnly(2024, 6, 5));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 6L,
                column: "date",
                value: new DateOnly(2024, 6, 5));

            migrationBuilder.UpdateData(
                table: "prices",
                keyColumn: "id",
                keyValue: 1L,
                column: "property_id",
                value: 0L);

            migrationBuilder.UpdateData(
                table: "prices",
                keyColumn: "id",
                keyValue: 2L,
                column: "property_id",
                value: 0L);

            migrationBuilder.UpdateData(
                table: "prices",
                keyColumn: "id",
                keyValue: 3L,
                column: "property_id",
                value: 0L);

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 1L,
                column: "publication_date",
                value: new DateTime(2024, 6, 4, 8, 14, 5, 602, DateTimeKind.Utc).AddTicks(482));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 2L,
                column: "publication_date",
                value: new DateTime(2024, 5, 6, 8, 14, 5, 602, DateTimeKind.Utc).AddTicks(493));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 3L,
                column: "publication_date",
                value: new DateTime(2024, 4, 6, 8, 14, 5, 602, DateTimeKind.Utc).AddTicks(495));

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 5, 16, 8, 14, 5, 602, DateTimeKind.Utc).AddTicks(545), new DateTime(2024, 5, 29, 8, 14, 5, 602, DateTimeKind.Utc).AddTicks(548) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 6, 2, 8, 14, 5, 602, DateTimeKind.Utc).AddTicks(560), new DateTime(2024, 6, 5, 8, 14, 5, 602, DateTimeKind.Utc).AddTicks(561) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 6, 2, 8, 14, 5, 602, DateTimeKind.Utc).AddTicks(562), new DateTime(2024, 6, 3, 8, 14, 5, 602, DateTimeKind.Utc).AddTicks(563) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 6, 5, 8, 14, 5, 602, DateTimeKind.Utc).AddTicks(566), new DateTime(2024, 6, 9, 8, 14, 5, 602, DateTimeKind.Utc).AddTicks(566) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 5, 26, 8, 14, 5, 602, DateTimeKind.Utc).AddTicks(572), new DateTime(2024, 6, 9, 8, 14, 5, 602, DateTimeKind.Utc).AddTicks(572) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 5, 26, 8, 14, 5, 602, DateTimeKind.Utc).AddTicks(575), new DateTime(2024, 6, 9, 8, 14, 5, 602, DateTimeKind.Utc).AddTicks(576) });

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 4L,
                column: "date",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "reviews",
                keyColumn: "id",
                keyValue: 5L,
                column: "date",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

            migrationBuilder.AddForeignKey(
                name: "fk_chat_user_tenants_participants_id",
                table: "chat_user",
                column: "participants_id",
                principalTable: "tenants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_messages_tenants_author_id",
                table: "messages",
                column: "author_id",
                principalTable: "tenants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_notifications_tenants_receiver_id",
                table: "notifications",
                column: "receiver_id",
                principalTable: "tenants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_previous_passwords_tenants_tenant_id",
                table: "previous_passwords",
                column: "tenant_id",
                principalTable: "tenants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_properties_tenants_owner_id",
                table: "properties",
                column: "owner_id",
                principalTable: "tenants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_property_user_tenants_favourites_id",
                table: "property_user",
                column: "favourites_id",
                principalTable: "tenants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_reservation_user_tenants_participants_id",
                table: "reservation_user",
                column: "participants_id",
                principalTable: "tenants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_reviews_tenants_author_id",
                table: "reviews",
                column: "author_id",
                principalTable: "tenants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
