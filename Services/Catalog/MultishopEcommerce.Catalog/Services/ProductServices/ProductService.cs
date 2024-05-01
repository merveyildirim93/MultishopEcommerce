using AutoMapper;
using MongoDB.Driver;
using MultishopEcommerce.Catalog.Dtos.CategoryDtos;
using MultishopEcommerce.Catalog.Dtos.ProductDtos;
using MultishopEcommerce.Catalog.Entities;
using MultishopEcommerce.Catalog.Settings;

namespace MultishopEcommerce.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;
        public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
        }
        public async Task CreateProduct(CreateProductDto productDto)
        {
            var value = _mapper.Map<Product>(productDto);
            await _productCollection.InsertOneAsync(value);
        }

        public async Task DeleteProduct(string productId)
        {
            await _productCollection.DeleteOneAsync(x => x.ProductID == productId);
        }

        public async Task<List<ResultProductDto>> GetAllProducts()
        {
            var products = await _productCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(products);
        }

        public async Task<GetByIdProductDto> GetByIdProduct(string productId)
        {
            var product = await _productCollection.Find<Product>(x => x.CategoryID == productId).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(product);
        }

        public async Task UpdateProduct(UpdateProductDto updateProductDto)
        {
            var value = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x => x.CategoryID == updateProductDto.ProductID, value);
        }
    }
}
