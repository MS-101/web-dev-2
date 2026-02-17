using Mansus.Server.DTOs.Book;
using Mansus.Server.DTOs.Publisher;
using Mansus.Server.DTOs.Language;


namespace Mansus.Server.DTOs.Product.BookPublication
{
    public class BookPublicationDTO : ProductDTO
    {
        public required BookDTO Book { get; set; }
        public required PublisherDTO Publisher { get; set; }
        public DateTime? PublishedAt { get; set; } = null;
        public required LanguageDTO Language { get; set; }
    }
}
