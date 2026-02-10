namespace Mansus.Server.Models
{
    public class UserCart
    {
        public int Id { get; set; }

        public required User User { get; set; }
        public required Product Product { get; set; }

        public required int Quantity { get; set; } = 1;
    }
}
