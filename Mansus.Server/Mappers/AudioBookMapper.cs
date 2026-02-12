using Mansus.Server.DTOs.Product.BookPublication.AudioBook;
using Mansus.Server.Models;

namespace Mansus.Server.Mappers
{
    public static class AudioEBookMapper
    {
        public static AudioBookDTO ToDTO(this AudioBook audioBook)
        {
            if (audioBook is null)
                return null!;

            return new AudioBookDTO
            {
                Id = audioBook.Id,
                Name = audioBook.Name,
                Description = audioBook.Description,
                Price = audioBook.Price,
                Discount = audioBook.Discount,
                Book = audioBook.Book.ToDTO(),
                Publisher = audioBook.Publisher.ToDTO(),
                PublishedAt= audioBook.PublishedAt,
                Language = audioBook.Language.ToDTO()
            };
        }

        public static IReadOnlyList<AudioBookDTO> ToDTOs(this IEnumerable<AudioBook> audioBooks)
        {
            return audioBooks?.Select(audioBook => audioBook.ToDTO()).ToList() ?? [];
        }
    }
}
