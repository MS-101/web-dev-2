namespace Mansus.Server.DTOs
{
    public class BookPublicatinDTO : ProductDTO
    {
        public required int BookId { get; set; }
        public required int PublisherId { get; set; }
        public DateTime? PublishedAt { get; set; } = null;
        public required int LanguageId { get; set; }
    }
}
