using Mansus.Server.DTOs.Book;
using Mansus.Server.Models;

namespace Mansus.Server.Mappers
{
    public static class BookMapper
    {
        public static BookDTO ToDTO(this Book book)
        {
            if (book is null)
                return null!;

            return new BookDTO
            {
                Id = book.Id,
                Name = book.Name,
                Description = book.Description,
                Authors = book.Authors?.Select(author => author.ToDTO()).ToArray() ?? []
            };
        }

        public static IReadOnlyList<BookDTO> ToDTOs(this IEnumerable<Book> books)
        {
            return books?.Select(book => book.ToDTO()).ToList() ?? [];
        }
    }
}
