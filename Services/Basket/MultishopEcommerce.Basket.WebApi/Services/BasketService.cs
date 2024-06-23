using MultishopEcommerce.Basket.Dtos;
using MultishopEcommerce.Basket.Settings;
using System.Text.Json;

namespace MultishopEcommerce.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;
        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }
        public async Task<bool> DeleteBasket(string UserId)
        {
            var status = await _redisService.GetDb().KeyDeleteAsync(UserId);
            return status;
        }

        public async Task<BasketTotalDto> GetBasket(string UserId)
        {
            var existBasket = await _redisService.GetDb().StringGetAsync(UserId);
            return JsonSerializer.Deserialize<BasketTotalDto>(existBasket);
        }

        public async Task<bool> SaveBasket(BasketTotalDto dto)
        {
            var save = await _redisService.GetDb().StringSetAsync(dto.UserId, JsonSerializer.Serialize(dto));
            return save;
        }
    }
}
