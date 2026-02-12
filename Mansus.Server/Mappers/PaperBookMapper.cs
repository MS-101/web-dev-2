using Mansus.Server.DTOs.Product.BookPublication.PaperBook;
using Mansus.Server.Models;

namespace Mansus.Server.Mappers
{
    public static class PaperBookMapper
    {
        public static PaperBookDTO ToDTO(this PaperBook paperBook)
        {
            if (paperBook is null)
                return null!;

            return new PaperBookDTO
            {
                Id = paperBook.Id,
                Name = paperBook.Name,
                Description = paperBook.Description,
                Price = paperBook.Price,
                Discount = paperBook.Discount,
                Book = paperBook.Book.ToDTO(),
                Publisher = paperBook.Publisher.ToDTO(),
                PublishedAt= paperBook.PublishedAt,
                Language = paperBook.Language.ToDTO()
            };
        }

        public static IReadOnlyList<PaperBookDTO> ToDTOs(this IEnumerable<PaperBook> paperBooks)
        {
            return paperBooks?.Select(paperBook => paperBook.ToDTO()).ToList() ?? [];
        }
    }
}
