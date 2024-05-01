using AutoMapper;
using MongoDB.Driver;
using MultishopEcommerce.Catalog.Dtos.CategoryDtos;
using MultishopEcommerce.Catalog.Entities;
using MultishopEcommerce.Catalog.Settings;

namespace MultishopEcommerce.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;
        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        }
        
        public async Task CreateCategory(CreateCategoryDto categoryDto)
        {
            var value = _mapper.Map<Category>(categoryDto);
            await _categoryCollection.InsertOneAsync(value);
        }

        public async Task DeleteCategory(string categoryId)
        {
            await _categoryCollection.DeleteOneAsync(x => x.CategoryID == categoryId);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategories()
        {
            var categories = await _categoryCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultCategoryDto>>(categories);
        }

        public async Task<GetByIdCategoryDto> GetByIdCategory(string categoryId)
        {
          var category =  await _categoryCollection.Find<Category>(x => x.CategoryID == categoryId).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCategoryDto>(category);
        }

        public async Task UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var value = _mapper.Map<Category>(updateCategoryDto);
            await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryID == updateCategoryDto.CategoryID, value);
        }
    }
}
