using Mansus.Server.DTOs.Author;

namespace Mansus.Server.DTOs.Book
{
    public class BookDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; } = "";
        public AuthorDTO[] Authors { get; set; } = [];
    }
}
