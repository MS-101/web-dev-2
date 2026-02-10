namespace Mansus.Server.Models
{
    public class BookPublication: Product
    {
        public required Book Book { get; set; }
        public required Publisher Publisher { get; set; }
        public DateTime? PublishedAt { get; set; } = null;
        public required Language Language { get; set; }
    }
}
