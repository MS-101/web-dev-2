namespace Mansus.Server.DTOs.Product
{
    public class UpdateProductDTO
    {
        public required string Name { get; set; }
        public string Description { get; set; } = "";

        public required decimal Price { get; set; }
        public required decimal Discount { get; set; }
    }
}
