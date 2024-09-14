using Microsoft.AspNetCore.Mvc;

namespace MultishopEcommerce.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
