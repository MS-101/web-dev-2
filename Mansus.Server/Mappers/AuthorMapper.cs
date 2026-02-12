using Mansus.Server.DTOs.Author;
using Mansus.Server.Models;

namespace Mansus.Server.Mappers
{
    public static class AuthorMapper
    {
        public static AuthorDTO ToDTO(this Author author)
        {
            if (author is null) return null!;

            return new AuthorDTO
            {
                Id = author.Id,
                Name = author.Name
            };
        }

        public static IReadOnlyList<AuthorDTO> ToDTOs(this IEnumerable<Author> authors)
        {
            return authors?.Select(author => author.ToDTO()).ToList() ?? [];
        }
    }
}
