using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Real_Estate.Dto.FavoriteDto;
using Real_Estate.Dto.PropertyDtos;
using System.Security.Claims;
using System.Text;

namespace Real_Estate.WebUI.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]
    [Route("User/Favorite")]
    public class FavoriteController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FavoriteController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("MyFavorite")]
        public async Task<IActionResult> MyFavorite()
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var UserId = int.Parse(userid);
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7028/api/Favorite/GetUserFavoritesProperty/" + UserId);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPropertyDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        //[HttpPost]
        [Route("CreateFavorite/{id}")]
        public async Task<IActionResult> CreateFavorite(int id)
        {
            CreateFavoriteDto createFavoriteDto=new CreateFavoriteDto();
             var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            createFavoriteDto.UserId = int.Parse(userid);
            createFavoriteDto.PropertyId = id;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createFavoriteDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7028/api/Favorite", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAll", "Property", new { area = "User" });
            }
            return View();
        }


        [Route("RemoveFavorite/{id}")]
        public async Task<IActionResult> RemoveFavorite(int id)
        {
            DeleteFavoriteDto deleteFavoriteDto=new DeleteFavoriteDto();
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            deleteFavoriteDto.UserId=int.Parse(userid);
            deleteFavoriteDto.PropertyId = id;

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(deleteFavoriteDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, "https://localhost:7028/api/Favorite")
            {
                Content = stringContent
            };

            var responseMessage = await client.SendAsync(requestMessage);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAll", "Property", new { area = "User" });
            }
            return View();
       
        }
    }
}
