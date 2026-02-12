using Mansus.Server.DTOs.Language;
using Mansus.Server.Models;

namespace Mansus.Server.Mappers
{
    public static class LanguageMapper
    {
        public static LanguageDTO ToDTO(this Language language)
        {
            if (language is null)
                return null!;

            return new LanguageDTO
            {
                Id = language.Id,
                Name = language.Name
            };
        }

        public static IReadOnlyList<LanguageDTO> ToDTOs(this IEnumerable<Language> languages)
        {
            return languages?.Select(language => language.ToDTO()).ToList() ?? [];
        }
    }
}
