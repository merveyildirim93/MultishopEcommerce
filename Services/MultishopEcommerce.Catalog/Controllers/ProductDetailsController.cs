using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultishopEcommerce.Catalog.Dtos.ProductDtos;
using MultishopEcommerce.Catalog.Services.ProductDetailServices;

namespace MultishopEcommerce.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;
        public ProductDetailsController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetailList()
        {
            var details = await _productDetailService.GetAllProductDetails();
            return Ok(details);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            var detail = await _productDetailService.GetByIdProductDetail(id);
            return Ok(detail);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto dto)
        {
            await _productDetailService.CreateProductDetail(dto);
            return Ok("Ürün detayı başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await _productDetailService.DeleteProductDetail(id);
            return Ok("Ürün detayı başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto dto)
        {
            await _productDetailService.UpdateProductDetail(dto);
            return Ok("Ürün detayı başarıyla güncellendi");
        }
    }
}
