namespace SOFT40081_StarterCode.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? Rating { get; set; }
        public string ProductImage { get; set; }
        public string SecurityImpact { get; set; }
    }
}
