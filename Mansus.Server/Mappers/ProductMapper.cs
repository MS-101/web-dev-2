using Mansus.Server.DTOs.Product;
using Mansus.Server.Models;

namespace Mansus.Server.Mappers
{
    public static class ProductMapper
    {
        public static ProductDTO ToDTO(this Product product)
        {
            if (product is null)
                return null!;

            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Discount = product.Discount
            };
        }

        public static IReadOnlyList<ProductDTO> ToDTOs(this IEnumerable<Product> products)
        {
            return products?.Select(product => product.ToDTO()).ToList() ?? [];
        }
    }
}
