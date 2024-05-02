using Dapper;
using MultishopEcommerce.Discount.Context;
using MultishopEcommerce.Discount.Dtos;

namespace MultishopEcommerce.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _context;
        public DiscountService(DapperContext context)
        {
            _context = context;
        }
        public async Task CreateCoupon(CreateCouponDto couponDto)
        {
            string query = "insert into coupons (Code, Rate, IsActive, ValidDate) values (@Code, @Rate, @IsActive, @ValidDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@Code", couponDto.Code);
            parameters.Add("@Rate", couponDto.Rate);
            parameters.Add("@IsActive", couponDto.IsActive);
            parameters.Add("@ValidDate", couponDto.ValidDate);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteCoupon(int id)
        {
            string query = "delete from Coupons where CouponId = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultCouponDto>> GetAllCoupons()
        {
            string query = "select * from Coupons";
            using (var connection = _context.CreateConnection())
            {
              var coupons =  await connection.QueryAsync<ResultCouponDto>(query);
                return coupons.ToList();
            }
        }

        public async Task<GetByIdCouponDto> GetByIdCoupon(int id)
        {
            string query = "select * from Coupons where CouponId = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var coupon = await connection.QueryFirstAsync<GetByIdCouponDto>(query, parameters);
                return coupon;
            }
        }

        public async Task UpdateCoupon(UpdateCouponDto couponDto)
        {
            string query = "update coupons set Code = @Code, Rate = @Rate, IsActive = @IsActive, ValidDate = @ValidDate where CouponId = @CouponId";
            var parameters = new DynamicParameters();
            parameters.Add("@CouponId", couponDto.CouponId);
            parameters.Add("@Code", couponDto.Code);
            parameters.Add("@Rate", couponDto.Rate);
            parameters.Add("@IsActive", couponDto.IsActive);
            parameters.Add("@ValidDate", couponDto.ValidDate);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
