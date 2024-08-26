using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ronnier.AmazonProduct.Models {
   
   // all created classes in C# inherits from the 'object' base class that provides methods like ToString(), etc..
   // it doesnt have a name, like in the example below, AmazonProducts class inherits from the root object base class
   public class AmazonProducts {
     
     
     [Key]
     [Column("column1", TypeName = "tinyint")]
     public byte? column1 {get; set;} = null;
     
     [Column("asin", TypeName = "nvarchar(50)")]
     public string? asin {get; set;} = string.Empty;

     [Column("product_title", TypeName = "nvarchar(250)")]
     public string? product_title {get; set;} = string.Empty;

     [Column("product_price", TypeName = "money")]
     public decimal?  product_price {get; set;} = 0m;

     [Column("product_original_price", TypeName = "money")]
     public decimal?  product_original_price {get; set;} = 0m;

     [Column("currency", TypeName = "nvarchar(50)")]
     public string? currency {get; set;} = string.Empty;

     [Column("product_star_rating", TypeName = "float")]
     public double? product_star_rating {get; set;} = 0.0;

     [Column("product_num_ratings", TypeName = "int")]
     public int? product_num_ratings {get; set;} = 0;

     [Column("product_url", TypeName = "nvarchar(50)")]
     public string? product_url {get; set;} = string.Empty;

     [Column("product_photo", TypeName = "nvarchar(100)")]
     public string? product_photo {get; set;} = string.Empty;

     [Column("product_num_offers", TypeName = "tinyint")]
     public byte? product_num_offers {get; set;} = null;

     [Column("product_minimum_offer_price", TypeName = "money")]
     public decimal? product_minimum_offer_price {get; set;} = 0m;

     [Column("is_best_seller", TypeName = "bit")]
     public bool?  is_best_seller {get; set;} = false;
     
     [Column("is_amazon_choice", TypeName = "bit")]
     public bool?  is_amazon_choice {get; set;} = false;
     
     [Column("is_prime", TypeName = "bit")]
     public bool?  is_prime {get; set;} = false;

     [Column("climate_pledge_friendly", TypeName = "bit")]
     public bool?  climate_pledge_friendly {get; set;} = false;

     [Column("sales_volume", TypeName = "nvarchar(50)")]
     public string?  sales_volume {get; set;} = string.Empty;

     [Column("delivery", TypeName = "nvarchar(150)")]
     public string? delivery {get; set;} = string.Empty;

     [Column("has_variations", TypeName = "bit")]
     public bool? has_variations {get; set;} = false;

     [Column("product_availability", TypeName = "nvarchar(50)")]
     public string? product_availability {get; set;} = string.Empty;

     [Column("unit_price", TypeName = "money")]
     public decimal? unit_price {get; set;} = 0m;

     [Column("unit_count", TypeName = "float")]
     public double? unit_count {get; set;} = 0.0;
     

     public override string ToString() {
        return $"ID: {column1}, ASIN: {asin}, Product Title: {product_title}, Product Price: {product_price}";
     }


    }
}