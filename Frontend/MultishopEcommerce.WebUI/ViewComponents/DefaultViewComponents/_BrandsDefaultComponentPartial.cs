using Microsoft.AspNetCore.Mvc;

namespace MultishopEcommerce.WebUI.ViewComponents.DefaultViewComponents
{
    public class _BrandsDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
