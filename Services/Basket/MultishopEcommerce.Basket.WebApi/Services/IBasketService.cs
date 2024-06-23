using MultishopEcommerce.Basket.Dtos;

namespace MultishopEcommerce.Basket.Services
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasket(string UserId);
        Task<bool> SaveBasket(BasketTotalDto dto);
        Task<bool> DeleteBasket(string UserId);
    }
}
