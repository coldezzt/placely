using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Placely.Main.Migrations
{
    /// <inheritdoc />
    public partial class add_unique_constraint_on_priceListId_in_property : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_properties_price_list_id",
                table: "properties");

            migrationBuilder.CreateIndex(
                name: "ix_properties_price_list_id",
                table: "properties",
                column: "price_list_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_properties_price_list_id",
                table: "properties");

            migrationBuilder.CreateIndex(
                name: "ix_properties_price_list_id",
                table: "properties",
                column: "price_list_id");
        }
    }
}
