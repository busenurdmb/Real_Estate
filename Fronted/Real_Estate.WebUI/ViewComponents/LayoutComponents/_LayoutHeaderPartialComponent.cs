using Microsoft.AspNetCore.Mvc;

namespace Real_Estate.WebUI.ViewComponents.LayoutComponents
{
    public class _LayoutHeaderPartialComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
