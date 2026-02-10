namespace Mansus.Server.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public ICollection<BookPublication> BookPublications { get; set; } = [];
    }
}
