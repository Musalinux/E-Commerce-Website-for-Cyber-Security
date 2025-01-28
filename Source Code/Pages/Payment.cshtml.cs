using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using SOFT40081_StarterCode.Models; 

namespace SOFT40081_StarterCode.Pages
{
    public class PaymentModel : PageModel
    {
        private readonly AppDataContext _db; // Injecting the current DbContext 

        public PaymentModel(AppDataContext db)
        {
            _db = db;
        }

        public decimal TotalAmount { get; set; }

        public void OnGet()
        {
            var productIds = HttpContext.Session.GetObjectFromJson<List<int>>("Cart");
            if (productIds != null)
            {
                TotalAmount = _db.Products
                                .Where(p => productIds.Contains(p.Id))
                                .Sum(p => p.Price); 
            }
        }

        public IActionResult OnPost(string cardNumber, string expiryDate, string cvc)
        {
            // Simulate payment processing
            HttpContext.Session.Remove("Cart");  // Clear the cart after processing
            return RedirectToPage("OrderConfirmation");
        }
    }
}
