namespace Mansus.Server.Models
{
    public class BookCategory
    {
        public int Id { get; set; }

        public required string Name { get; set; }
        public BookCategory? Parent { get; set; }
    }
}
