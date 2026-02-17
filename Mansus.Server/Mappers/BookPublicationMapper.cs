using Mansus.Server.DTOs.Product.BookPublication;
using Mansus.Server.Models;

namespace Mansus.Server.Mappers
{
    public static class BookPublicationMapper
    {
        public static BookPublicationDTO ToDTO(this BookPublication bookPublication)
        {
            if (bookPublication is null)
                return null!;

            return new BookPublicationDTO
            {
                Id = bookPublication.Id,
                Name = bookPublication.Name,
                Description = bookPublication.Description,
                Price = bookPublication.Price,
                Discount = bookPublication.Discount,
                Book = bookPublication.Book.ToDTO(),
                Publisher = bookPublication.Publisher.ToDTO(),
                PublishedAt = bookPublication.PublishedAt,
                Language = bookPublication.Language.ToDTO()
            };
        }

        public static IReadOnlyList<BookPublicationDTO> ToDTOs(this IEnumerable<BookPublication> bookPublications)
        {
            return bookPublications?.Select(bookPublication => bookPublication.ToDTO()).ToList() ?? [];
        }
    }
}
