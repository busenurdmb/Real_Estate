using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Real_Estate.Dto.PropertyDtos;
using Real_Estate.WebUI.Services.Property;
using System.Security.Claims;
using X.PagedList.Extensions;


namespace Real_Estate.WebUI.Areas.Users.Controllers
{
	[Authorize(Roles = "User")]
	[Area("Users")]
	[Route("Users/Property")]
	public class PropertyController : Controller
	{
		private readonly IPropertyService _propertyService;
        private readonly IValidator<CreatePropertyDto> _validator;



        public PropertyController(IPropertyService propertyService, IValidator<CreatePropertyDto> validator)
        {
            _propertyService = propertyService;
            _validator = validator;
        }

        [Route("Details/{id}")]
		public async Task<IActionResult> Details(int id)
		{
			var propertyDetails = await _propertyService.GetPropertyDetailsAsync(id);
			return View(propertyDetails);
		}

		[Route("GetAll")]
		public async Task<IActionResult> GetAll(int? page)
		{
			var properties = await _propertyService.GetAllApprovePropertiesAsync();
            int pageNumber = page ?? 1;
            var pagedList = properties.ToPagedList(pageNumber, 6);

            return View(pagedList);
		}

		[Route("GetMyPropertyList")]
		public async Task<IActionResult> GetMyPropertyList(int? page)
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var properties = await _propertyService.GetUserPropertiesAsync(userId);
            int pageNumber = page ?? 1;
            var pagedList = properties.ToPagedList(pageNumber, 6);

            return View(pagedList);
          
		}

		[HttpGet]
		[Route("CreateProperty")]
		public IActionResult CreateProperty()
		{
			return View();
		}

		[HttpPost]
		[Route("CreateProperty")]
		public async Task<IActionResult> CreateProperty(CreatePropertyDto createPropertyDto)
		{
			createPropertyDto.Status = "Onay Bekliyor";
			createPropertyDto.Image = "Onay Bekliyor";
            createPropertyDto.AddedDate = DateTime.UtcNow;

            // Validate DTO
            var validationResult = await _validator.ValidateAsync(createPropertyDto);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(createPropertyDto);
            }
			var isCreated = await _propertyService.CreatePropertyAsync(createPropertyDto);
			if (isCreated)
			{
				return RedirectToAction("GetMyPropertyList", "Property", new { area = "Users" });
			}
         
            ModelState.AddModelError("", "İlan eklenirken bir hata oluştu.");
            return View(createPropertyDto);
          
		}

		[Route("RemoveProperty/{id}")]
		public async Task<IActionResult> RemoveProperty(int id)
		{
			var isRemoved = await _propertyService.RemovePropertyAsync(id);
			if (isRemoved)
			{
				return RedirectToAction("GetMyPropertyList", "Property", new { area = "Users" });
			}
			return View();
		}

		[HttpGet]
		[Route("UpdateProperty/{id}")]
		public async Task<IActionResult> UpdateProperty(int id)
		{
			var propertyToUpdate = await _propertyService.GetPropertyForUpdateAsync(id);
			return View(propertyToUpdate);
		}

		[HttpPost]
		[Route("UpdateProperty/{id}")]
		public async Task<IActionResult> UpdateProperty(UpdatePropertyDto updatePropertyDto)
		{
			var isUpdated = await _propertyService.UpdatePropertyAsync(updatePropertyDto);
			if (isUpdated)
			{
				return RedirectToAction("GetMyPropertyList", "Property", new { area = "Users" });
			}
			return View();
		}
	}

}

