using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultishopEcommerce.Catalog.Dtos.CategoryDtos;
using MultishopEcommerce.Catalog.Dtos.ProductDtos;
using MultishopEcommerce.Catalog.Services.ProductImageServices;

namespace MultishopEcommerce.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _productImageService;
        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductImageList()
        {
            var details = await _productImageService.GetAllProductImages();
            return Ok(details);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageById(string id)
        {
            var detail = await _productImageService.GetByIdProductImage(id);
            return Ok(detail);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto dto)
        {
            await _productImageService.CreateProductImage(dto);
            return Ok("Ürün resmi başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await _productImageService.DeleteProductImage(id);
            return Ok("Ürün resmi başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto dto)
        {
            await _productImageService.UpdateProductImage(dto);
            return Ok("Ürün resmi başarıyla güncellendi");
        }
    }
}
