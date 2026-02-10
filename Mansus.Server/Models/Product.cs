namespace Mansus.Server.Models
{
    public class Product
    {
        public int Id { get; set; }

        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;

        public required decimal Price { get; set; } = 0;
        public required decimal Discount { get; set; } = 0;
    }
}
