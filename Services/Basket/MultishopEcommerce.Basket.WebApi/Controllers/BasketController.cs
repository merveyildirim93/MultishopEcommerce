using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultishopEcommerce.Basket.Dtos;
using MultishopEcommerce.Basket.LoginServices;
using MultishopEcommerce.Basket.Services;

namespace MultishopEcommerce.Basket.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;

        public BasketController(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasketDetail()
        {
            var basket = await _basketService.GetBasket(_loginService.GetUserId);
            return Ok(basket);
        }

        [HttpPost]
        public async Task<IActionResult> SaveMyBasket(BasketTotalDto dto)
        {
            dto.UserId = _loginService.GetUserId;
            bool basketStatu = await _basketService.SaveBasket(dto);
            if (basketStatu)
            {
                return Ok("Sepetteki değişiklikler kaydedildi");
            }
            else
            {
                return BadRequest("Bir hata oluştu");
            }
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteMyBasket()
        {
            string UserId = _loginService.GetUserId;
            bool basketStatu = await _basketService.DeleteBasket(UserId);
            if (basketStatu)
            {
                return Ok("Sepet silindi");
            }
            else
            {
                return BadRequest("Bir hata oluştu");
            }
        }

    }
}
