using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using MvcApp.Data;
using System.Threading.Tasks;

// In C#, when an object is called via Console.WriteLine(object) this always calls the ToString() method of the class
namespace Ronnier.AmazonProduct.Query {
    
    [ApiController]
    [Route("api/amazon-products")]
    public class AmazonProductSales: ControllerBase {

        private readonly ApplicationDbContext _context;
        private readonly ILogger<AmazonProductSales> _logger;

        public AmazonProductSales (ApplicationDbContext context, ILogger<AmazonProductSales> logger) {
            this._context = context; 
            this._logger = logger;
        }
        
        [HttpGet("amazon-query")]
        public async Task<IActionResult> AmazonQuery () {
            
            // this returns a class List
            var product_sales = await _context.AmazonProducts.ToListAsync();
            
            _logger.LogInformation("Product Sales Count: {Count}", product_sales.Count);
            foreach(var row in product_sales) {
                Console.WriteLine(row); // or Console.WriteLine(row.ToString());
            }
       
            return Ok(product_sales);
        }
          


    }
}