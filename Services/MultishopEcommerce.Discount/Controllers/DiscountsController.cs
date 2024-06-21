using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultishopEcommerce.Discount.Dtos;
using MultishopEcommerce.Discount.Services;

namespace MultishopEcommerce.Discount.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<ActionResult> CouponList()
        {
            var coupons = await _discountService.GetAllCoupons();
            return Ok(coupons);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCouponById(int id)
        {
            var coupon = await _discountService.GetByIdCoupon(id);
            return Ok(coupon);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCoupon(CreateCouponDto dto)
        {
            await _discountService.CreateCoupon(dto);
            return Ok("Kupon başarıyla oluşturuldu");
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCoupon(int id)
        {
            await _discountService.DeleteCoupon(id);
            return Ok("Kupon başarıyla silindi");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCoupon(UpdateCouponDto dto)
        {
            await _discountService.UpdateCoupon(dto);
            return Ok("Kupon başarıyla güncellendi");
        }

    }
}
