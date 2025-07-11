using Microsoft.AspNetCore.Mvc;

namespace MultishopEcommerce.WebUI.ViewComponents.ShoppingCardViewComponents
{
    public class _ShoppingCardProductListComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
