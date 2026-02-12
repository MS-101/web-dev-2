namespace Mansus.Server.DTOs.Book
{
    public class UpdateBookDTO
    {
        public required string Name { get; set; }
        public string Description { get; set; } = "";
        public required int BookCategoryId { get; set; }
    }
}
