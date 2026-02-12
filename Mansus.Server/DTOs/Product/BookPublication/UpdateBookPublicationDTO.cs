namespace Mansus.Server.DTOs.Product.BookPublication
{
    public class UpdateBookPublicatinDTO : UpdateProductDTO
    {
        public required int BookId { get; set; }
        public required int PublisherId { get; set; }
        public DateTime? PublishedAt { get; set; } = null;
        public required int LanguageId { get; set; }
    }
}
