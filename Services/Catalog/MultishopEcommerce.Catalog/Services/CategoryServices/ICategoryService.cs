using MultishopEcommerce.Catalog.Dtos.CategoryDtos;

namespace MultishopEcommerce.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategories();
        Task CreateCategory(CreateCategoryDto categoryDto);
        Task UpdateCategory(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategory(string categoryId);
        Task<List<GetByIdCategoryDto>> GetByIdCategory(string categoryId);

    }
}
