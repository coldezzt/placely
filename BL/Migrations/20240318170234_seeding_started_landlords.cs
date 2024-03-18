using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BL.Migrations
{
    /// <inheritdoc />
    public partial class seeding_started_landlords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "landlords",
                columns: new[] { "id", "contact_address", "tenant_id" },
                values: new object[,]
                {
                    { 1L, "some address 1", 4L },
                    { 2L, "some address 2", 5L },
                    { 3L, "some address 3", 6L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "landlords",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "landlords",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "landlords",
                keyColumn: "id",
                keyValue: 3L);
        }
    }
}
