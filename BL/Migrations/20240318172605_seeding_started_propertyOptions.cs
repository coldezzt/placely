using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BL.Migrations
{
    /// <inheritdoc />
    public partial class seeding_started_propertyOptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "property_options",
                columns: new[] { "id", "name", "value" },
                values: new object[,]
                {
                    { 1L, "Option1", "Value1" },
                    { 2L, "Option2", "Value2" },
                    { 3L, "Option3", "Value3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "property_options",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "property_options",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "property_options",
                keyColumn: "id",
                keyValue: 3L);
        }
    }
}
