using Microsoft.AspNetCore.Mvc;

namespace Real_Estate.WebUI.ViewComponents.LayoutComponents
{
	public class _LayoutScriptComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
