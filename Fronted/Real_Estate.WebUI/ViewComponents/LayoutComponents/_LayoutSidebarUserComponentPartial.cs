using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Real_Estate.WebUI.ViewComponents.LayoutComponents
{
	public class _LayoutSidebarUserComponentPartial : ViewComponent
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public _LayoutSidebarUserComponentPartial(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		public IViewComponentResult Invoke()
		{
			// Giriş yapan kullanıcının ismini alıyoruz
			var userName = _httpContextAccessor.HttpContext.User.FindFirstValue("Username");
		
			// Burada kullanıcı bilgilerini View'a göndererek kullanılabilir hale getiriyoruz
			ViewBag.UserName = userName;

			return View();
		}
	}
}
