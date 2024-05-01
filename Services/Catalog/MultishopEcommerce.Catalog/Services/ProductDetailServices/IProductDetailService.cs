using MultishopEcommerce.Catalog.Dtos.ProductDtos;

namespace MultishopEcommerce.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetails();
        Task CreateProductDetail(CreateProductDetailDto productDetailDto);
        Task UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto);
        Task DeleteProductDetail(string id);
        Task<GetByIdProductDetailDto> GetByIdProductDetail(string id);
    }
}
