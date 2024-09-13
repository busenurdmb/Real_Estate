using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Real_Estate.Dto.PropertyDtos;
using System.Security.Claims;
using System.Text;

namespace Real_Estate.WebUI.Areas.User.Controllers
{
    [Authorize(Roles ="User")]
	[Area("User")]
	[Route("User/Property")]
	public class PropertyController : Controller
    {
		private readonly IHttpClientFactory _httpClientFactory;

		public PropertyController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

        [Route("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7028/api/Property/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultPropertyDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7028/api/Property");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPropertyDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [Route("GetMyPropertyList")]
		public async  Task<IActionResult> GetMyPropertyList()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
           
            var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7028/api/Property/PropertyListUserId/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultPropertyDto>>(jsonData);
				return View(values);
			}
			return View();
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
            createPropertyDto.Status="o";
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createPropertyDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7028/api/Property", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("GetMyProprtyList", "Property", new { area = "User" });
            }
            return View();
        }

        [Route("RemoveProperty/{id}")]
        public async Task<IActionResult> RemoveProperty(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7028/api/Property/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("GetMyProprtyList", "Property", new { area = "User" });

            }
            return View();
        }

        [HttpGet]
        [Route("UpdateProperty/{id}")]
        public async Task<IActionResult> UpdateProperty(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var resposenMessage = await client.GetAsync($"https://localhost:7028/api/Property/{id}");
            if (resposenMessage.IsSuccessStatusCode)
            {
                var jsonData = await resposenMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdatePropertyDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateProperty/{id}")]
        public async Task<IActionResult> UpdateProperty(UpdatePropertyDto updatePropertyDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updatePropertyDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7028/api/Property/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("GetMyProprtyList", "Property", new { area = "User" });

            }
            return View();
        }
    }
}
