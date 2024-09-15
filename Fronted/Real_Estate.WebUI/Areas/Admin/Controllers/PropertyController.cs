using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Real_Estate.WebUI.Services.Property;
using X.PagedList.Extensions;

namespace Real_Estate.WebUI.Areas.Admin.Controllers
{
	[Authorize(Roles = "Admin")]
	[Area("Admin")]
	[Route("Admin/Property")]
	public class PropertyController : Controller
	{
		private readonly IPropertyService _propertyService;

		public PropertyController(IPropertyService propertyService)
		{
			_propertyService = propertyService;
		}

		[Route("Details/{id}")]
		public async Task<IActionResult> Details(int id)
		{
			var propertyDetails = await _propertyService.GetPropertyDetailsAsync(id);
			return View(propertyDetails);
		}

		[Route("GetAll")]
		public async Task<IActionResult> GetAll()
		{
			var properties = await _propertyService.GetAllApprovePropertiesAsync();
			return View(properties);
		}

    

        [Route("GetAllStatus")]
        public async Task<IActionResult> GetAllStatus(int? page, string statusFilter, DateTime? startDate, DateTime? endDate)
        {
            // Filtreleme ve sayfalama işlemleri için servis kullanımı
            var properties = await _propertyService.FilterPropertiesAsync(statusFilter, startDate, endDate);
            int pageNumber = page ?? 1;
            var pagedList = properties.ToPagedList(pageNumber, 10);

            // View'a gönder
            return View(pagedList);
        }
        [Route("RemoveProperty/{id}")]
        public async Task<IActionResult> RemoveProperty(int id)
        {
            var isRemoved = await _propertyService.RemovePropertyAsync(id);
            if (isRemoved)
            {
                return RedirectToAction("GetAllStatus", "Property", new { area = "Admin" });
            }
            return View();
        }

        [Route("ApproveProperty/{id}")]
        public async Task<IActionResult> ApproveProperty(int id)
        {
            var result = await _propertyService.ApprovePropertyAsync(id);
            if (result)
            {
                return RedirectToAction("GetAllStatus");
            }

            return NotFound();
        }
        [Route("TakedownProperty/{id}")]
        public async Task<IActionResult> TakedownProperty(int id)
        {
            var result = await _propertyService.TakedownPropertyAsync(id);
            if (result)
            {
                return RedirectToAction("GetAllStatus");
            }

            return NotFound();
        }
        // İlanı Reddet

        [Route("RejectProperty/{id}")]
        public async Task<IActionResult> RejectProperty(int id)
        {
            var result = await _propertyService.RejectPropertyAsync(id);
            if (result)
            {
                return RedirectToAction("GetAllStatus");
            }

            return NotFound();
        }
    }
}
