using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Placely.Main.Migrations
{
    /// <inheritdoc />
    public partial class deleted_propertyIdProperty_fields_from_priceList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_properties_prices_id",
                table: "properties");

            migrationBuilder.DropColumn(
                name: "property_id",
                table: "prices");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "properties",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "ix_properties_price_list_id",
                table: "properties",
                column: "price_list_id");

            migrationBuilder.AddForeignKey(
                name: "fk_properties_prices_price_list_id",
                table: "properties",
                column: "price_list_id",
                principalTable: "prices",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_properties_prices_price_list_id",
                table: "properties");

            migrationBuilder.DropIndex(
                name: "ix_properties_price_list_id",
                table: "properties");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "properties",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "property_id",
                table: "prices",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "fk_properties_prices_id",
                table: "properties",
                column: "id",
                principalTable: "prices",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
