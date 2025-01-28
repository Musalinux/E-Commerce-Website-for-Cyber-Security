using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using SOFT40081_StarterCode.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace SOFT40081_StarterCode.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly AppDataContext _db;
        private readonly ILogger<ProductsModel> _logger;

        public ProductsModel(AppDataContext db, ILogger<ProductsModel> logger)
        {
            _db = db;
            _logger = logger;
        }

        public List<Product> Products { get; set; }

        public void OnGet()  // Changed this to handle null values due to issues while adding SecurityImpact column in db.
        {
            Products = _db.Products.Select(p => new Product
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description ?? "No description provided", // Default if NULL
                Price = p.Price,
                Rating = p.Rating ?? 0, // Default if NULL
                SecurityImpact = p.SecurityImpact ?? "No impact noted", // Default if NULL
                ProductImage = p.ProductImage
            }).ToList();
        }


        public class ProductId
        {
            public int Id { get; set; }
        }

        public IActionResult OnPostAddToCart([FromBody] ProductId productId)
        {
            _logger.LogInformation("Received add to cart request for product ID: {ProductId}", productId?.Id);

            if (productId == null || productId.Id <= 0)
            {
                _logger.LogError("Invalid product ID received: {ProductId}", productId?.Id);
                return BadRequest("Invalid product ID.");
            }

            var cart = HttpContext.Session.GetString("Cart");
            var cartList = string.IsNullOrEmpty(cart) ? new List<int>() : JsonConvert.DeserializeObject<List<int>>(cart);

            if (!cartList.Contains(productId.Id))
            {
                cartList.Add(productId.Id);
                HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cartList));
                return new JsonResult(new { success = true });
            }

            return new JsonResult(new { success = false, message = "Product already in cart." });
        }


    }
}
