using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Placely.Main.Migrations
{
    /// <inheritdoc />
    public partial class configure_relationships_manually : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_chats_landlords_landlord_id",
                table: "chats");

            migrationBuilder.DropForeignKey(
                name: "fk_chats_tenants_first_user_id",
                table: "chats");

            migrationBuilder.DropForeignKey(
                name: "fk_chats_tenants_second_user_id",
                table: "chats");

            migrationBuilder.DropForeignKey(
                name: "fk_chats_tenants_tenant_id",
                table: "chats");

            migrationBuilder.DropForeignKey(
                name: "fk_contracts_landlords_landlord_id",
                table: "contracts");

            migrationBuilder.DropForeignKey(
                name: "fk_contracts_properties_property_id",
                table: "contracts");

            migrationBuilder.DropForeignKey(
                name: "fk_contracts_tenants_tenant_id",
                table: "contracts");

            migrationBuilder.DropForeignKey(
                name: "fk_properties_landlords_landlord_id",
                table: "properties");

            migrationBuilder.DropForeignKey(
                name: "fk_reservations_landlords_landlord_id",
                table: "reservations");

            migrationBuilder.DropForeignKey(
                name: "fk_reservations_tenants_tenant_id",
                table: "reservations");

            migrationBuilder.DropTable(
                name: "landlords");

            migrationBuilder.DropTable(
                name: "property_tenant");

            migrationBuilder.DropIndex(
                name: "ix_reservations_landlord_id",
                table: "reservations");

            migrationBuilder.DropIndex(
                name: "ix_reservations_tenant_id",
                table: "reservations");

            migrationBuilder.DropIndex(
                name: "ix_properties_landlord_id",
                table: "properties");

            migrationBuilder.DropIndex(
                name: "ix_contracts_landlord_id",
                table: "contracts");

            migrationBuilder.DropIndex(
                name: "ix_contracts_property_id",
                table: "contracts");

            migrationBuilder.DropIndex(
                name: "ix_contracts_tenant_id",
                table: "contracts");

            migrationBuilder.DropIndex(
                name: "ix_chats_first_user_id",
                table: "chats");

            migrationBuilder.DropIndex(
                name: "ix_chats_landlord_id",
                table: "chats");

            migrationBuilder.DropIndex(
                name: "ix_chats_second_user_id",
                table: "chats");

            migrationBuilder.DropIndex(
                name: "ix_chats_tenant_id",
                table: "chats");

            migrationBuilder.DropColumn(
                name: "landlord_id",
                table: "reservations");

            migrationBuilder.DropColumn(
                name: "tenant_id",
                table: "reservations");

            migrationBuilder.DropColumn(
                name: "landlord_id",
                table: "properties");

            migrationBuilder.DropColumn(
                name: "landlord_id",
                table: "contracts");

            migrationBuilder.DropColumn(
                name: "lease_end_date_time",
                table: "contracts");

            migrationBuilder.DropColumn(
                name: "lease_start_date_time",
                table: "contracts");

            migrationBuilder.DropColumn(
                name: "property_id",
                table: "contracts");

            migrationBuilder.DropColumn(
                name: "template_fields_path",
                table: "contracts");

            migrationBuilder.DropColumn(
                name: "template_path",
                table: "contracts");

            migrationBuilder.DropColumn(
                name: "first_user_id",
                table: "chats");

            migrationBuilder.DropColumn(
                name: "landlord_id",
                table: "chats");

            migrationBuilder.DropColumn(
                name: "second_user_id",
                table: "chats");

            migrationBuilder.DropColumn(
                name: "tenant_id",
                table: "chats");

            migrationBuilder.RenameColumn(
                name: "status_type",
                table: "reservations",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "tenant_id",
                table: "contracts",
                newName: "reservation_id");

            migrationBuilder.AddColumn<string>(
                name: "contact_address",
                table: "tenants",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "contract_id",
                table: "reservations",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "payment_amount",
                table: "reservations",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "payment_frequency",
                table: "reservations",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "period_short",
                table: "prices",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "period_medium",
                table: "prices",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "period_long",
                table: "prices",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<long>(
                name: "property_id",
                table: "prices",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "chat_user",
                columns: table => new
                {
                    chats_id = table.Column<long>(type: "bigint", nullable: false),
                    participants_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_chat_user", x => new { x.chats_id, x.participants_id });
                    table.ForeignKey(
                        name: "fk_chat_user_chats_chats_id",
                        column: x => x.chats_id,
                        principalTable: "chats",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_chat_user_tenants_participants_id",
                        column: x => x.participants_id,
                        principalTable: "tenants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "property_user",
                columns: table => new
                {
                    favourites_id = table.Column<long>(type: "bigint", nullable: false),
                    favourites_id1 = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_property_user", x => new { x.favourites_id, x.favourites_id1 });
                    table.ForeignKey(
                        name: "fk_property_user_properties_favourites_id1",
                        column: x => x.favourites_id1,
                        principalTable: "properties",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_property_user_tenants_favourites_id",
                        column: x => x.favourites_id,
                        principalTable: "tenants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reservation_user",
                columns: table => new
                {
                    participants_id = table.Column<long>(type: "bigint", nullable: false),
                    reservations_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_reservation_user", x => new { x.participants_id, x.reservations_id });
                    table.ForeignKey(
                        name: "fk_reservation_user_reservations_reservations_id",
                        column: x => x.reservations_id,
                        principalTable: "reservations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_reservation_user_tenants_participants_id",
                        column: x => x.participants_id,
                        principalTable: "tenants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "chats",
                keyColumn: "id",
                keyValue: 1L,
                column: "directory_name",
                value: "/chat-1-2");

            migrationBuilder.UpdateData(
                table: "chats",
                keyColumn: "id",
                keyValue: 2L,
                column: "directory_name",
                value: "/chat-1-3");

            migrationBuilder.UpdateData(
                table: "chats",
                keyColumn: "id",
                keyValue: 3L,
                column: "directory_name",
                value: "/chat-2-4");

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
                columns: new[] { "period_long", "period_medium", "period_short", "property_id" },
                values: new object[] { 11m, 111m, 1111m, 0L });

            migrationBuilder.UpdateData(
                table: "prices",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "period_long", "period_medium", "period_short", "property_id" },
                values: new object[] { 22m, 222m, 2222m, 0L });

            migrationBuilder.UpdateData(
                table: "prices",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "period_long", "period_medium", "period_short", "property_id" },
                values: new object[] { 33m, 333m, 3333m, 0L });

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
                columns: new[] { "contract_id", "creation_date_time", "entry_date", "payment_amount", "payment_frequency" },
                values: new object[] { null, new DateTime(2024, 5, 16, 8, 14, 5, 602, DateTimeKind.Utc).AddTicks(545), new DateTime(2024, 5, 29, 8, 14, 5, 602, DateTimeKind.Utc).AddTicks(548), 250000m, "2 раза в год" });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "contract_id", "creation_date_time", "entry_date", "payment_amount", "payment_frequency" },
                values: new object[] { null, new DateTime(2024, 6, 2, 8, 14, 5, 602, DateTimeKind.Utc).AddTicks(560), new DateTime(2024, 6, 5, 8, 14, 5, 602, DateTimeKind.Utc).AddTicks(561), 3000m, "2 раза в неделю" });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "contract_id", "creation_date_time", "entry_date", "payment_amount", "payment_frequency" },
                values: new object[] { null, new DateTime(2024, 6, 2, 8, 14, 5, 602, DateTimeKind.Utc).AddTicks(562), new DateTime(2024, 6, 3, 8, 14, 5, 602, DateTimeKind.Utc).AddTicks(563), 40000m, "1 раз в месяц" });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "contract_id", "creation_date_time", "entry_date", "payment_amount", "payment_frequency" },
                values: new object[] { null, new DateTime(2024, 6, 5, 8, 14, 5, 602, DateTimeKind.Utc).AddTicks(566), new DateTime(2024, 6, 9, 8, 14, 5, 602, DateTimeKind.Utc).AddTicks(566), null, null });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "contract_id", "creation_date_time", "entry_date", "payment_amount", "payment_frequency" },
                values: new object[] { null, new DateTime(2024, 5, 26, 8, 14, 5, 602, DateTimeKind.Utc).AddTicks(572), new DateTime(2024, 6, 9, 8, 14, 5, 602, DateTimeKind.Utc).AddTicks(572), null, null });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "contract_id", "creation_date_time", "entry_date", "payment_amount", "payment_frequency" },
                values: new object[] { null, new DateTime(2024, 5, 26, 8, 14, 5, 602, DateTimeKind.Utc).AddTicks(575), new DateTime(2024, 6, 9, 8, 14, 5, 602, DateTimeKind.Utc).AddTicks(576), null, null });

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 1L,
                column: "contact_address",
                value: null);

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 2L,
                column: "contact_address",
                value: null);

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 3L,
                column: "contact_address",
                value: null);

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 4L,
                column: "contact_address",
                value: null);

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 5L,
                column: "contact_address",
                value: null);

            migrationBuilder.UpdateData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 6L,
                column: "contact_address",
                value: null);

            migrationBuilder.CreateIndex(
                name: "ix_contracts_reservation_id",
                table: "contracts",
                column: "reservation_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_chat_user_participants_id",
                table: "chat_user",
                column: "participants_id");

            migrationBuilder.CreateIndex(
                name: "ix_property_user_favourites_id1",
                table: "property_user",
                column: "favourites_id1");

            migrationBuilder.CreateIndex(
                name: "ix_reservation_user_reservations_id",
                table: "reservation_user",
                column: "reservations_id");

            migrationBuilder.AddForeignKey(
                name: "fk_contracts_reservations_reservation_id",
                table: "contracts",
                column: "reservation_id",
                principalTable: "reservations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_contracts_reservations_reservation_id",
                table: "contracts");

            migrationBuilder.DropTable(
                name: "chat_user");

            migrationBuilder.DropTable(
                name: "property_user");

            migrationBuilder.DropTable(
                name: "reservation_user");

            migrationBuilder.DropIndex(
                name: "ix_contracts_reservation_id",
                table: "contracts");

            migrationBuilder.DropColumn(
                name: "contact_address",
                table: "tenants");

            migrationBuilder.DropColumn(
                name: "contract_id",
                table: "reservations");

            migrationBuilder.DropColumn(
                name: "payment_amount",
                table: "reservations");

            migrationBuilder.DropColumn(
                name: "payment_frequency",
                table: "reservations");

            migrationBuilder.DropColumn(
                name: "property_id",
                table: "prices");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "reservations",
                newName: "status_type");

            migrationBuilder.RenameColumn(
                name: "reservation_id",
                table: "contracts",
                newName: "tenant_id");

            migrationBuilder.AddColumn<long>(
                name: "landlord_id",
                table: "reservations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "tenant_id",
                table: "reservations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "landlord_id",
                table: "properties",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "period_short",
                table: "prices",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "period_medium",
                table: "prices",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "period_long",
                table: "prices",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddColumn<long>(
                name: "landlord_id",
                table: "contracts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "lease_end_date_time",
                table: "contracts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "lease_start_date_time",
                table: "contracts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "property_id",
                table: "contracts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "template_fields_path",
                table: "contracts",
                type: "text",
                nullable: false,
                defaultValue: "Data/contracts/default/default_fields.json");

            migrationBuilder.AddColumn<string>(
                name: "template_path",
                table: "contracts",
                type: "text",
                nullable: false,
                defaultValue: "Data/contracts/default/default_template.docx");

            migrationBuilder.AddColumn<long>(
                name: "first_user_id",
                table: "chats",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "landlord_id",
                table: "chats",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "second_user_id",
                table: "chats",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "tenant_id",
                table: "chats",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "landlords",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tenant_id = table.Column<long>(type: "bigint", nullable: false),
                    contact_address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_landlords", x => x.id);
                    table.ForeignKey(
                        name: "fk_landlords_tenants_tenant_id",
                        column: x => x.tenant_id,
                        principalTable: "tenants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "property_tenant",
                columns: table => new
                {
                    favourite_id = table.Column<long>(type: "bigint", nullable: false),
                    in_favourites_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_property_tenant", x => new { x.favourite_id, x.in_favourites_id });
                    table.ForeignKey(
                        name: "fk_property_tenant_properties_favourite_id",
                        column: x => x.favourite_id,
                        principalTable: "properties",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_property_tenant_tenants_in_favourites_id",
                        column: x => x.in_favourites_id,
                        principalTable: "tenants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "chats",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "directory_name", "first_user_id", "landlord_id", "second_user_id", "tenant_id" },
                values: new object[] { "/chat-t-1-l-1", 1L, null, 1L, null });

            migrationBuilder.UpdateData(
                table: "chats",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "directory_name", "first_user_id", "landlord_id", "second_user_id", "tenant_id" },
                values: new object[] { "/chat-t-2-l-1", 2L, null, 1L, null });

            migrationBuilder.UpdateData(
                table: "chats",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "directory_name", "first_user_id", "landlord_id", "second_user_id", "tenant_id" },
                values: new object[] { "/chat-t-2-l-2", 2L, null, 2L, null });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "landlord_id", "lease_end_date_time", "lease_start_date_time", "property_id" },
                values: new object[] { 1L, new DateTime(2024, 7, 4, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(380), new DateTime(2024, 5, 28, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(376), 1L });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "landlord_id", "lease_end_date_time", "lease_start_date_time", "property_id" },
                values: new object[] { 1L, new DateTime(2024, 6, 18, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(387), new DateTime(2024, 6, 4, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(387), 2L });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "landlord_id", "lease_end_date_time", "lease_start_date_time", "property_id" },
                values: new object[] { 2L, new DateTime(2024, 6, 5, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(390), new DateTime(2024, 6, 2, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(389), 3L });

            migrationBuilder.InsertData(
                table: "landlords",
                columns: new[] { "id", "contact_address", "tenant_id" },
                values: new object[,]
                {
                    { 1L, "some address 1", 4L },
                    { 2L, "some address 2", 5L },
                    { 3L, "some address 3", 6L }
                });

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(2024, 6, 2, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(525));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 6, 3, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(529));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 5, 29, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(531));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateOnly(2024, 6, 4));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateOnly(2024, 6, 4));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateOnly(2024, 6, 4));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 4L,
                column: "date",
                value: new DateOnly(2024, 6, 4));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 5L,
                column: "date",
                value: new DateOnly(2024, 6, 4));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 6L,
                column: "date",
                value: new DateOnly(2024, 6, 4));

            migrationBuilder.UpdateData(
                table: "prices",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "period_long", "period_medium", "period_short" },
                values: new object[] { 11, 111, 1111 });

            migrationBuilder.UpdateData(
                table: "prices",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "period_long", "period_medium", "period_short" },
                values: new object[] { 22, 222, 2222 });

            migrationBuilder.UpdateData(
                table: "prices",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "period_long", "period_medium", "period_short" },
                values: new object[] { 33, 333, 3333 });

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "landlord_id", "publication_date" },
                values: new object[] { null, new DateTime(2024, 6, 3, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(325) });

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "landlord_id", "publication_date" },
                values: new object[] { null, new DateTime(2024, 5, 5, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(336) });

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "landlord_id", "publication_date" },
                values: new object[] { null, new DateTime(2024, 4, 5, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(339) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "creation_date_time", "entry_date", "landlord_id", "tenant_id" },
                values: new object[] { new DateTime(2024, 5, 15, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(422), new DateTime(2024, 5, 28, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(424), 1L, 1L });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "creation_date_time", "entry_date", "landlord_id", "tenant_id" },
                values: new object[] { new DateTime(2024, 6, 1, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(431), new DateTime(2024, 6, 4, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(432), 1L, 2L });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "creation_date_time", "entry_date", "landlord_id", "tenant_id" },
                values: new object[] { new DateTime(2024, 6, 1, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(434), new DateTime(2024, 6, 2, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(435), 2L, 3L });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "creation_date_time", "entry_date", "landlord_id", "tenant_id" },
                values: new object[] { new DateTime(2024, 6, 4, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(437), new DateTime(2024, 6, 8, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(437), 1L, 1L });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "creation_date_time", "entry_date", "landlord_id", "tenant_id" },
                values: new object[] { new DateTime(2024, 5, 25, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(440), new DateTime(2024, 6, 8, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(441), 2L, 3L });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "creation_date_time", "entry_date", "landlord_id", "tenant_id" },
                values: new object[] { new DateTime(2024, 5, 25, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(444), new DateTime(2024, 6, 8, 7, 8, 44, 315, DateTimeKind.Utc).AddTicks(445), 2L, 1L });

            migrationBuilder.CreateIndex(
                name: "ix_reservations_landlord_id",
                table: "reservations",
                column: "landlord_id");

            migrationBuilder.CreateIndex(
                name: "ix_reservations_tenant_id",
                table: "reservations",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_properties_landlord_id",
                table: "properties",
                column: "landlord_id");

            migrationBuilder.CreateIndex(
                name: "ix_contracts_landlord_id",
                table: "contracts",
                column: "landlord_id");

            migrationBuilder.CreateIndex(
                name: "ix_contracts_property_id",
                table: "contracts",
                column: "property_id");

            migrationBuilder.CreateIndex(
                name: "ix_contracts_tenant_id",
                table: "contracts",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_chats_first_user_id",
                table: "chats",
                column: "first_user_id");

            migrationBuilder.CreateIndex(
                name: "ix_chats_landlord_id",
                table: "chats",
                column: "landlord_id");

            migrationBuilder.CreateIndex(
                name: "ix_chats_second_user_id",
                table: "chats",
                column: "second_user_id");

            migrationBuilder.CreateIndex(
                name: "ix_chats_tenant_id",
                table: "chats",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_landlords_tenant_id",
                table: "landlords",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_property_tenant_in_favourites_id",
                table: "property_tenant",
                column: "in_favourites_id");

            migrationBuilder.AddForeignKey(
                name: "fk_chats_landlords_landlord_id",
                table: "chats",
                column: "landlord_id",
                principalTable: "landlords",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_chats_tenants_first_user_id",
                table: "chats",
                column: "first_user_id",
                principalTable: "tenants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "fk_contracts_landlords_landlord_id",
                table: "contracts",
                column: "landlord_id",
                principalTable: "landlords",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_contracts_properties_property_id",
                table: "contracts",
                column: "property_id",
                principalTable: "properties",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_contracts_tenants_tenant_id",
                table: "contracts",
                column: "tenant_id",
                principalTable: "tenants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_properties_landlords_landlord_id",
                table: "properties",
                column: "landlord_id",
                principalTable: "landlords",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_reservations_landlords_landlord_id",
                table: "reservations",
                column: "landlord_id",
                principalTable: "landlords",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_reservations_tenants_tenant_id",
                table: "reservations",
                column: "tenant_id",
                principalTable: "tenants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
