using Microsoft.AspNetCore.Mvc;

namespace MultishopEcommerce.WebUI.Controllers
{
    public class ShoppingCardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
