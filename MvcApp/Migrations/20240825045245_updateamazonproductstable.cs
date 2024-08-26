using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcApp.Migrations
{
    /// <inheritdoc />
    public partial class updateamazonproductstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "amazon_product",
                columns: table => new
                {
                    column1 = table.Column<byte>(type: "tinyint", nullable: false),
                    asin = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    product_title = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    product_price = table.Column<decimal>(type: "money", nullable: false),
                    product_original_price = table.Column<decimal>(type: "money", nullable: false),
                    currency = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    product_star_rating = table.Column<double>(type: "float", nullable: false),
                    product_num_ratings = table.Column<int>(type: "int", nullable: false),
                    product_url = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    product_photo = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    product_num_offers = table.Column<byte>(type: "tinyint", nullable: false),
                    product_minimum_offer_price = table.Column<decimal>(type: "money", nullable: false),
                    is_best_seller = table.Column<bool>(type: "bit", nullable: false),
                    is_amazon_choice = table.Column<bool>(type: "bit", nullable: false),
                    is_prime = table.Column<bool>(type: "bit", nullable: false),
                    climate_pledge_friendly = table.Column<bool>(type: "bit", nullable: false),
                    sales_volume = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    delivery = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    has_variations = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_amazon_product", x => x.column1);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "amazon_product");
        }
    }
}
