using Mansus.Server.DTOs.Publisher;
using Mansus.Server.Models;

namespace Mansus.Server.Mappers
{
    public static class PublisherMapper
    {
        public static PublisherDTO ToDTO(this Publisher publisher)
        {
            if (publisher is null)
                return null!;

            return new PublisherDTO
            {
                Id = publisher.Id,
                Name = publisher.Name
            };
        }

        public static IReadOnlyList<PublisherDTO> ToDTOs(this IEnumerable<Publisher> publishers)
        {
            return publishers?.Select(publisher => publisher.ToDTO()).ToList() ?? [];
        }
    }
}
