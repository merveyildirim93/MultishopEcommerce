using Microsoft.AspNetCore.Mvc;

namespace MultishopEcommerce.WebUI.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
