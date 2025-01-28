using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SOFT40081_StarterCode.Models;

namespace SOFT40081_StarterCode.Pages
{
    public class AddToCartModel : PageModel
    {
        private readonly AppDataContext _db;
        public List<CartProduct> CartProducts { get; set; } = new List<CartProduct>();

        public AddToCartModel(AppDataContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            LoadCartProducts();
        }

        private void LoadCartProducts()
        {
            var cartSession = HttpContext.Session.GetString("Cart");
            var productIds = string.IsNullOrEmpty(cartSession) ? new List<int>() : JsonConvert.DeserializeObject<List<int>>(cartSession);
            CartProducts = _db.Products
                .Where(p => productIds.Contains(p.Id))
                .Select(p => new CartProduct
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = productIds.Count(id => id == p.Id),
                    ProductImage = p.ProductImage
                }).ToList();
        }

        public IActionResult OnPostUpdateCart(int productId, int quantity)
        {
            var cartSession = HttpContext.Session.GetString("Cart");
            var productIds = string.IsNullOrEmpty(cartSession) ? new List<int>() : JsonConvert.DeserializeObject<List<int>>(cartSession);
            productIds.RemoveAll(id => id == productId); // Clear current product entries
            productIds.AddRange(Enumerable.Repeat(productId, quantity)); // Add new quantity
            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(productIds));
            return RedirectToPage();
        }

        public IActionResult OnPostRemoveFromCart(int productId)
        {
            var cartSession = HttpContext.Session.GetString("Cart");
            var productIds = string.IsNullOrEmpty(cartSession) ? new List<int>() : JsonConvert.DeserializeObject<List<int>>(cartSession);
            productIds.RemoveAll(id => id == productId); // Remove product entries
            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(productIds));
            return RedirectToPage();
        }

    }
}
