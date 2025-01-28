using Microsoft.AspNetCore.Identity;
namespace SOFT40081_StarterCode.Models
{
    public class CartProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ProductImage { get; set; }

    }
}
