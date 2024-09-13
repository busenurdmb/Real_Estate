using Microsoft.AspNetCore.Mvc;

namespace Real_Estate.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult _Layout()
        {
            return View();
        }
    }
}
