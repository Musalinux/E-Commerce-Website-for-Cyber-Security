using Microsoft.AspNetCore.Mvc.RazorPages;
using SOFT40081_StarterCode.Models;
using System.Collections.Generic;
using System.Linq;

namespace SOFT40081_StarterCode.Pages
{
    public class HomePageModel : PageModel
    {
        private readonly AppDataContext _db;

        public List<Product> FeaturedProducts { get; set; }

        public HomePageModel(AppDataContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            FeaturedProducts = _db.Products
                                  .Where(p => p.Rating >= 4)
                                  .Select(p => new Product
                                  {
                                      Id = p.Id,
                                      Name = p.Name,
                                      Description = p.Description ?? "No description provided",
                                      Price = p.Price,
                                      Rating = p.Rating ?? 0, // Provide a default value if null
                                      // Ensure the image path is correctly referenced
                                      ProductImage = String.IsNullOrWhiteSpace(p.ProductImage) ? "images/default.png" : p.ProductImage.StartsWith("images/") ? p.ProductImage : "images/" + p.ProductImage,
                                      SecurityImpact = p.SecurityImpact ?? "No impact noted" // Handling NULL
                                  })
                                  .ToList();
        }
    }
}
