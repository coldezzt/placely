using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BL.Migrations
{
    /// <inheritdoc />
    public partial class seeding_started_property : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "properties",
                columns: new[] { "id", "address", "description", "owner_id", "price_list_id", "type" },
                values: new object[,]
                {
                    { 1L, "Flat property address", "Flat property description", 1L, 1L, 2 },
                    { 2L, "Hostel property address", "Hostel property description", 1L, 2L, 0 },
                    { 3L, "Villa property address", "Villa property description", 2L, 3L, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "properties",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "properties",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "properties",
                keyColumn: "id",
                keyValue: 3L);
        }
    }
}
