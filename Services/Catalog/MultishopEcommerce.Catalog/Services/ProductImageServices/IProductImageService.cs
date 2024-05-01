using MultishopEcommerce.Catalog.Dtos.ProductDtos;

namespace MultishopEcommerce.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImages();
        Task CreateProductImage(CreateProductImageDto productImageDto);
        Task UpdateProductImage(UpdateProductImageDto updateProductImageDto);
        Task DeleteProductImage(string id);
        Task<GetByIdProductImageDto> GetByIdProductImage(string id);
    }
}
