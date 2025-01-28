using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using SOFT40081_StarterCode.Models;
using System.IO;
using System;
using Microsoft.Extensions.Logging;

namespace SOFT40081_StarterCode.Pages
{
    public class AddProductsModel : PageModel
    {
        private readonly AppDataContext _db;
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<AddProductsModel> _logger;

        public AddProductsModel(AppDataContext db, IWebHostEnvironment environment, ILogger<AddProductsModel> logger)
        {
            _db = db;
            _environment = environment;
            _logger = logger;
        }

        [BindProperty]
        public Product Product { get; set; }

        public void OnGet()
        { }

        public IActionResult OnPost(IFormFile image, string name, string description, decimal price, int rating, string securityImpact)
        {
            try
            {
                if (image != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(image.FileName);
                    string extension = Path.GetExtension(image.FileName);
                    string imageFileName = fileName + DateTime.Now.ToString("yyyyMMddHHmmssfff") + extension;
                    // Ensure the file path is correctly formatted and relative to wwwroot
                    string filePath = Path.Combine(_environment.WebRootPath, "images", imageFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        image.CopyTo(fileStream);
                    }

                    // Save relative path from wwwroot to ensure it's correctly served
                    Product.ProductImage = "images/" + imageFileName;
                }
                else
                {
                    // Default image if none is specified
                    Product.ProductImage = "images/default.png";
                }

                Product.Name = name;
                Product.Description = description;
                Product.Price = price;
                Product.Rating = rating;
                Product.SecurityImpact = securityImpact;

                _db.Products.Add(Product);
                _db.SaveChanges();

                return RedirectToPage("./ManageProduct");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to add product: {ProductName}", name);
                ModelState.AddModelError(string.Empty, "An error occurred while adding the product.");
                return Page();
            }
        }
    }
}
