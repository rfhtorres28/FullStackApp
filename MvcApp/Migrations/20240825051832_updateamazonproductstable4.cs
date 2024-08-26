using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcApp.Migrations
{
    /// <inheritdoc />
    public partial class updateamazonproductstable4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "product_availability",
                table: "amazon_product",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "unit_count",
                table: "amazon_product",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<decimal>(
                name: "unit_price",
                table: "amazon_product",
                type: "money",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "product_availability",
                table: "amazon_product");

            migrationBuilder.DropColumn(
                name: "unit_count",
                table: "amazon_product");

            migrationBuilder.DropColumn(
                name: "unit_price",
                table: "amazon_product");
        }
    }
}
