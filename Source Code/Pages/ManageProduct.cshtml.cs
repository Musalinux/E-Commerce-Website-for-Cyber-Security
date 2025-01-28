using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Hosting;
using SOFT40081_StarterCode.Models;
using System.Collections.Generic;
using System.IO;
using System;
using Microsoft.Extensions.Logging;

namespace SOFT40081_StarterCode.Pages
{
    public class ManageProductsModel : PageModel
    {
        private readonly AppDataContext _db;
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<ManageProductsModel> _logger;

        public List<Product> Products { get; set; }

        public ManageProductsModel(AppDataContext db, IWebHostEnvironment environment, ILogger<ManageProductsModel> logger)
        {
            _db = db;
            _environment = environment;
            _logger = logger;
        }

        public void OnGet()
        {
            Products = _db.Products.Select(p => new Product
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description ?? "No description provided",
                SecurityImpact = p.SecurityImpact ?? "No security impact data",
                Rating = p.Rating ?? 0, // Default to 0 if null
                Price = p.Price,
                ProductImage = p.ProductImage ?? "images/default.png"
            }).ToList();
        }

        public IActionResult OnPostDelete(int id)
        {
            var product = _db.Products.Find(id);
            if (product == null)
            {
                _logger.LogWarning("Attempted to delete non-existent product: {ProductId}", id);
                return BadRequest("Product not found.");
            }

            _db.Products.Remove(product);
            _db.SaveChanges();
            _logger.LogInformation("Product deleted successfully: {ProductId}", id);
            return RedirectToPage();
        }

        public IActionResult OnPostUpdate(int id, string name, string description, string securityImpact, decimal price, int rating, IFormFile image)
        {
            var product = _db.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                _logger.LogError("Product with ID {ProductId} not found for update.", id);
                return BadRequest("Product not found.");
            }

            _logger.LogInformation("Updating product: {ProductId}", id);
            product.Name = name;
            product.Description = description;
            product.SecurityImpact = securityImpact;
            product.Price = price;
            product.Rating = rating;

            if (image != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(image.FileName);
                string extension = Path.GetExtension(image.FileName);
                string imageFileName = fileName + DateTime.Now.ToString("yyyyMMddHHmmssfff") + extension;
                string filePath = Path.Combine(_environment.WebRootPath, "images", imageFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }

                product.ProductImage = "images/" + imageFileName;
            }

            _db.SaveChanges();
            _logger.LogInformation("Product updated successfully: {ProductName}", name);

            return RedirectToPage("./ManageProduct");
        }
    }
}
