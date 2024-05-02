using MultishopEcommerce.Discount.Dtos;

namespace MultishopEcommerce.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDto>> GetAllCoupons();
        Task CreateCoupon(CreateCouponDto couponDto);
        Task UpdateCoupon(UpdateCouponDto couponDto);
        Task DeleteCoupon(int id);
        Task<GetByIdCouponDto> GetByIdCoupon(int id);
    }
}
