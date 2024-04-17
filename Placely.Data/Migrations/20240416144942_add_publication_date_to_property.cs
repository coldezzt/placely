using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Placely.Main.Migrations
{
    /// <inheritdoc />
    public partial class add_publication_date_to_property : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "property_property_option");

            migrationBuilder.DropTable(
                name: "property_options");

            migrationBuilder.DropColumn(
                name: "tenant_paid_utilies",
                table: "contracts");

            migrationBuilder.AddColumn<DateTime>(
                name: "publication_date",
                table: "properties",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "rating",
                table: "properties",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "finalized_path_docx",
                table: "contracts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "finalized_path_pdf",
                table: "contracts",
                type: "text",
                nullable: true);

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

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "finalized_path_docx", "finalized_path_pdf", "lease_end_date", "lease_start_date" },
                values: new object[] { null, null, new DateTime(2024, 5, 16, 14, 49, 41, 849, DateTimeKind.Utc).AddTicks(31), new DateTime(2024, 4, 9, 14, 49, 41, 849, DateTimeKind.Utc).AddTicks(27) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "finalized_path_docx", "finalized_path_pdf", "lease_end_date", "lease_start_date" },
                values: new object[] { null, null, new DateTime(2024, 4, 30, 14, 49, 41, 849, DateTimeKind.Utc).AddTicks(37), new DateTime(2024, 4, 16, 14, 49, 41, 849, DateTimeKind.Utc).AddTicks(37) });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "finalized_path_docx", "finalized_path_pdf", "lease_end_date", "lease_start_date" },
                values: new object[] { null, null, new DateTime(2024, 4, 17, 14, 49, 41, 849, DateTimeKind.Utc).AddTicks(40), new DateTime(2024, 4, 14, 14, 49, 41, 849, DateTimeKind.Utc).AddTicks(39) });

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(2024, 4, 14, 14, 49, 41, 849, DateTimeKind.Utc).AddTicks(142));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 4, 15, 14, 49, 41, 849, DateTimeKind.Utc).AddTicks(145));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 4, 10, 14, 49, 41, 849, DateTimeKind.Utc).AddTicks(147));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateOnly(2024, 4, 16));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateOnly(2024, 4, 16));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateOnly(2024, 4, 16));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 4L,
                column: "date",
                value: new DateOnly(2024, 4, 16));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 5L,
                column: "date",
                value: new DateOnly(2024, 4, 16));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 6L,
                column: "date",
                value: new DateOnly(2024, 4, 16));

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "publication_date", "rating" },
                values: new object[] { new DateTime(2024, 4, 15, 14, 49, 41, 848, DateTimeKind.Utc).AddTicks(9952), 0.0 });

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "publication_date", "rating" },
                values: new object[] { new DateTime(2024, 3, 17, 14, 49, 41, 848, DateTimeKind.Utc).AddTicks(9996), 0.0 });

            migrationBuilder.UpdateData(
                table: "properties",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "publication_date", "rating" },
                values: new object[] { new DateTime(2024, 2, 16, 14, 49, 41, 848, DateTimeKind.Utc).AddTicks(9999), 0.0 });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 3, 27, 14, 49, 41, 849, DateTimeKind.Utc).AddTicks(65), new DateTime(2024, 4, 9, 14, 49, 41, 849, DateTimeKind.Utc).AddTicks(66) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 13, 14, 49, 41, 849, DateTimeKind.Utc).AddTicks(69), new DateTime(2024, 4, 16, 14, 49, 41, 849, DateTimeKind.Utc).AddTicks(70) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 13, 14, 49, 41, 849, DateTimeKind.Utc).AddTicks(71), new DateTime(2024, 4, 14, 14, 49, 41, 849, DateTimeKind.Utc).AddTicks(72) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 16, 14, 49, 41, 849, DateTimeKind.Utc).AddTicks(73), new DateTime(2024, 4, 20, 14, 49, 41, 849, DateTimeKind.Utc).AddTicks(74) });

            migrationBuilder.UpdateData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "creation_date_time", "entry_date" },
                values: new object[] { new DateTime(2024, 4, 6, 14, 49, 41, 849, DateTimeKind.Utc).AddTicks(76), new DateTime(2024, 4, 20, 14, 49, 41, 849, DateTimeKind.Utc).AddTicks(77) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "publication_date",
                table: "properties");

            migrationBuilder.DropColumn(
                name: "rating",
                table: "properties");

            migrationBuilder.DropColumn(
                name: "finalized_path_docx",
                table: "contracts");

            migrationBuilder.DropColumn(
                name: "finalized_path_pdf",
                table: "contracts");

            migrationBuilder.DropColumn(
                name: "template_fields_path",
                table: "contracts");

            migrationBuilder.DropColumn(
                name: "template_path",
                table: "contracts");

            migrationBuilder.AddColumn<string>(
                name: "tenant_paid_utilies",
                table: "contracts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "property_options",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_property_options", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "property_property_option",
                columns: table => new
                {
                    options_id = table.Column<long>(type: "bigint", nullable: false),
                    properties_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_property_property_option", x => new { x.options_id, x.properties_id });
                    table.ForeignKey(
                        name: "fk_property_property_option_properties_properties_id",
                        column: x => x.properties_id,
                        principalTable: "properties",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_property_property_option_property_options_options_id",
                        column: x => x.options_id,
                        principalTable: "property_options",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "lease_end_date", "lease_start_date", "tenant_paid_utilies" },
                values: new object[] { new DateTime(2024, 4, 29, 17, 5, 29, 513, DateTimeKind.Utc).AddTicks(7267), new DateTime(2024, 3, 23, 17, 5, 29, 513, DateTimeKind.Utc).AddTicks(7257), "some paid utils in contract between tenant1 and landlord1 in flat property" });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "lease_end_date", "lease_start_date", "tenant_paid_utilies" },
                values: new object[] { new DateTime(2024, 4, 13, 17, 5, 29, 513, DateTimeKind.Utc).AddTicks(7274), new DateTime(2024, 3, 30, 17, 5, 29, 513, DateTimeKind.Utc).AddTicks(7274), "some paid utils in contract between tenant2 and landlord2 in hostel property" });

            migrationBuilder.UpdateData(
                table: "contracts",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "lease_end_date", "lease_start_date", "tenant_paid_utilies" },
                values: new object[] { new DateTime(2024, 3, 31, 17, 5, 29, 513, DateTimeKind.Utc).AddTicks(7276), new DateTime(2024, 3, 28, 17, 5, 29, 513, DateTimeKind.Utc).AddTicks(7276), "some paid utils in contract between tenant1 and landlord3 in villa property" });

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateTime(2024, 3, 28, 17, 5, 29, 513, DateTimeKind.Utc).AddTicks(7368));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateTime(2024, 3, 29, 17, 5, 29, 513, DateTimeKind.Utc).AddTicks(7371));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateTime(2024, 3, 24, 17, 5, 29, 513, DateTimeKind.Utc).AddTicks(7372));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 1L,
                column: "date",
                value: new DateOnly(2024, 3, 30));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 2L,
                column: "date",
                value: new DateOnly(2024, 3, 30));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 3L,
                column: "date",
                value: new DateOnly(2024, 3, 30));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 4L,
                column: "date",
                value: new DateOnly(2024, 3, 30));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 5L,
                column: "date",
                value: new DateOnly(2024, 3, 30));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 6L,
                column: "date",
                value: new DateOnly(2024, 3, 30));

            migrationBuilder.InsertData(
                table: "property_options",
                columns: new[] { "id", "name", "value" },
                values: new object[,]
                {
                    { 1L, "Option1", "Value1" },
                    { 2L, "Option2", "Value2" },
                    { 3L, "Option3", "Value3" }
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

            migrationBuilder.CreateIndex(
                name: "ix_property_property_option_properties_id",
                table: "property_property_option",
                column: "properties_id");
        }
    }
}
