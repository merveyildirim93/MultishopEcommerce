using Microsoft.AspNetCore.Mvc;

namespace MultishopEcommerce.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
