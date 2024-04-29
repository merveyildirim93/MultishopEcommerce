using AutoMapper;
using MongoDB.Driver;
using MultishopEcommerce.Catalog.Dtos.CategoryDtos;
using MultishopEcommerce.Catalog.Entities;

namespace MultishopEcommerce.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;
        public Task CreateCategory(CreateCategoryDto categoryDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCategory(string categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultCategoryDto>> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Task<List<GetByIdCategoryDto>> GetByIdCategory(string categoryId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            throw new NotImplementedException();
        }
    }
}
