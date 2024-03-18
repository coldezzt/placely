using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BL.Migrations
{
    /// <inheritdoc />
    public partial class seeding_started_priceLists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "prices",
                columns: new[] { "id", "period_long", "period_medium", "period_short" },
                values: new object[,]
                {
                    { 1L, 11, 111, 1111 },
                    { 2L, 22, 222, 2222 },
                    { 3L, 33, 333, 3333 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "prices",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "prices",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "prices",
                keyColumn: "id",
                keyValue: 3L);
        }
    }
}
