namespace Mansus.Server.DTOs
{
    public class ProductDTO
    {
        public required string Name { get; set; }
        public string Description { get; set; } = "";

        public required decimal Price { get; set; }
        public required decimal Discount { get; set; }
    }
}
