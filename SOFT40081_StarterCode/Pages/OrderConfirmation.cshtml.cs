using Microsoft.AspNetCore.Mvc.RazorPages;
using SOFT40081_StarterCode.Models;
using System.Collections.Generic;

namespace SOFT40081_StarterCode.Pages
{
    public class OrderConfirmationModel : PageModel
    {
        public List<CartProduct> CartProducts { get; set; } = new List<CartProduct>();

        public void OnGet()
        {
            CartProducts = new List<CartProduct>(); 
            // Simple form of adding the cart products here and then delete them. 
            // The products are deleted from the cart in the payment step itself.
            // This page just thanks the user for purchase and redirects them home.
        }
    }
}
