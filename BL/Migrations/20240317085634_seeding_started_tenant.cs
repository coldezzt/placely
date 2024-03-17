using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BL.Migrations
{
    /// <inheritdoc />
    public partial class seeding_started_tenant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tenants",
                columns: new[] { "id", "about", "avatar_path", "creation_year", "email", "name", "password", "phone_number", "work" },
                values: new object[,]
                {
                    { 1L, "I'm test tenant 1", "", 2024L, "test.tenant.1@email.domen", "Test tenant 1", "test.tenant.1@email.domen", "111 1111 11 11", "I'm working nowhere" },
                    { 2L, "I'm test tenant 2", "", 2024L, "test.tenant.2@email.domen", "Test tenant 2", "test.tenant.2@email.domen", "222 2222 22 22", "I'm working nowhere" },
                    { 3L, "I'm test tenant 3", "", 2024L, "test.tenant.3@email.domen", "Test tenant 3", "test.tenant.3@email.domen", "333 3333 33 33", "I'm working nowhere" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "tenants",
                keyColumn: "id",
                keyValue: 3L);
        }
    }
}
