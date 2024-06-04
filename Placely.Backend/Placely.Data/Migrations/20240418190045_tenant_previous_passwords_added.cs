using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Placely.Main.Migrations
{
    /// <inheritdoc />
    public partial class tenant_previous_passwords_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "previous_passwords",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tenant_id = table.Column<long>(type: "bigint", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_previous_passwords", x => x.id);
                    table.ForeignKey(
                        name: "fk_previous_passwords_tenants_tenant_id",
                        column: x => x.tenant_id,
                        principalTable: "tenants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "ix_previous_passwords_tenant_id",
                table: "previous_passwords",
                column: "tenant_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "previous_passwords");

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
    }
}
