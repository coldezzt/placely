using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BL.Migrations
{
    /// <inheritdoc />
    public partial class seeding_started_chats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "chats",
                columns: new[] { "id", "directory_path", "landlord_id", "tenant_id" },
                values: new object[,]
                {
                    { 1L, "/chat-t-1-l-1", 1L, 1L },
                    { 2L, "/chat-t-2-l-1", 1L, 2L },
                    { 3L, "/chat-t-2-l-2", 2L, 2L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "chats",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "chats",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "chats",
                keyColumn: "id",
                keyValue: 3L);
        }
    }
}
