using MultishopEcommerce.Discount.Dtos;

namespace MultishopEcommerce.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        public Task CreateCoupon(CreateCouponDto couponDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCoupon(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultCouponDto>> GetAllCoupons()
        {
            throw new NotImplementedException();
        }

        public Task<GetByIdCouponDto> GetByIdCoupon(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCoupon(UpdateCouponDto couponDto)
        {
            throw new NotImplementedException();
        }
    }
}
