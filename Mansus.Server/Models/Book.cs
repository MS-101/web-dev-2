namespace Mansus.Server.Models
{
    public class Book
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string Description { get; set; } = "";

        public ICollection<Author> Authors { get; set; } = [];
    }
}
