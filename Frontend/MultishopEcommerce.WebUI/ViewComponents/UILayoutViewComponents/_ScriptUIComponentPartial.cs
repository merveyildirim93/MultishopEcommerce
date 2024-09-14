using Microsoft.AspNetCore.Mvc;

namespace MultishopEcommerce.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _ScriptUIComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
