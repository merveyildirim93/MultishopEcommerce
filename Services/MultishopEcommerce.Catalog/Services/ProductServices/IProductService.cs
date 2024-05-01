using MultishopEcommerce.Catalog.Dtos.CategoryDtos;
using MultishopEcommerce.Catalog.Dtos.ProductDtos;

namespace MultishopEcommerce.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProducts();
        Task CreateProduct(CreateProductDto productDto);
        Task UpdateProduct(UpdateProductDto updateProductDto);
        Task DeleteProduct(string productId);
        Task<GetByIdProductDto> GetByIdProduct(string productId);
    }
}
