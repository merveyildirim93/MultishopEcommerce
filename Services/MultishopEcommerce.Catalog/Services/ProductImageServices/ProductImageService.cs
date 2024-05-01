using AutoMapper;
using MongoDB.Driver;
using MultishopEcommerce.Catalog.Dtos.ProductDtos;
using MultishopEcommerce.Catalog.Entities;
using MultishopEcommerce.Catalog.Settings;

namespace MultishopEcommerce.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMongoCollection<ProductImage> _productImageCollection;
        private readonly IMapper _mapper;
        public ProductImageService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productImageCollection = database.GetCollection<ProductImage>(databaseSettings.ProductImageCollectionName);
        }

        public async Task CreateProductImage(CreateProductImageDto productImageDto)
        {
            var value = _mapper.Map<ProductImage>(productImageDto);
            await _productImageCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductImage(string id)
        {
            await _productImageCollection.DeleteOneAsync(x => x.ProductImageID == id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImages()
        {
            var images = await _productImageCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(images);
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImage(string id)
        {
            var image = await _productImageCollection.Find<ProductImage>(x => x.ProductImageID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDto>(image);
        }

        public async Task UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            var value = _mapper.Map<ProductImage>(updateProductImageDto);
            await _productImageCollection.FindOneAndReplaceAsync(x => x.ProductImageID == updateProductImageDto.ProductImageID, value);
        }
    }
}
