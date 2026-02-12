namespace Mansus.Server.DTOs.Book
{
    public class BookDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; } = "";
    }
}
