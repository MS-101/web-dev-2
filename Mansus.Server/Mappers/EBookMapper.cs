using Mansus.Server.DTOs.Product.BookPublication.EBook;
using Mansus.Server.Models;

namespace Mansus.Server.Mappers
{
    public static class EBookMapper
    {
        public static EBookDTO ToDTO(this EBook eBook)
        {
            if (eBook is null)
                return null!;

            return new EBookDTO
            {
                Id = eBook.Id,
                Name = eBook.Name,
                Description = eBook.Description,
                Price = eBook.Price,
                Discount = eBook.Discount,
                Book = eBook.Book.ToDTO(),
                Publisher = eBook.Publisher.ToDTO(),
                PublishedAt= eBook.PublishedAt,
                Language = eBook.Language.ToDTO()
            };
        }

        public static IReadOnlyList<EBookDTO> ToDTOs(this IEnumerable<EBook> eBooks)
        {
            return eBooks?.Select(eBook => eBook.ToDTO()).ToList() ?? [];
        }
    }
}
