using AutoMapper;
using MongoDB.Driver;
using MultishopEcommerce.Catalog.Dtos.ProductDtos;
using MultishopEcommerce.Catalog.Entities;
using MultishopEcommerce.Catalog.Settings;

namespace MultishopEcommerce.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> _productDetailCollection;
        private readonly IMapper _mapper;
        public ProductDetailService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productDetailCollection = database.GetCollection<ProductDetail>(databaseSettings.ProductDetailCollectionName);
        }
        public async Task CreateProductDetail(CreateProductDetailDto productDetailDto)
        {
            var value = _mapper.Map<ProductDetail>(productDetailDto);
            await _productDetailCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductDetail(string id)
        {
            await _productDetailCollection.DeleteOneAsync(x => x.ProductDetailID == id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetails()
        {
            var productDetails = await _productDetailCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDto>>(productDetails);
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetail(string id)
        {
            var product = await _productDetailCollection.Find<ProductDetail>(x => x.ProductDetailID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDto>(product);
        }

        public async Task UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            var value = _mapper.Map<ProductDetail>(updateProductDetailDto);
            await _productDetailCollection.FindOneAndReplaceAsync(x => x.ProductDetailID == updateProductDetailDto.ProductDetailID, value);
        }
    }
}
