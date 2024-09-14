using Newtonsoft.Json;
using Real_Estate.Dto.FavoriteDto;
using Real_Estate.Dto.PropertyDtos;
using System.Security.Claims;
using System.Text;

namespace Real_Estate.WebUI.Services.Favorite
{
	public class FavoriteService : IFavoriteService
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public FavoriteService(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		
		public async Task<List<ResultPropertyDto>> GetUserFavoritesAsync(int userId)
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync($"https://localhost:7028/api/Favorite/GetUserFavoritesProperty/{userId}");

			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<List<ResultPropertyDto>>(jsonData);
			}

			return null;
		}

		public async Task<bool> AddToFavoritesAsync(CreateFavoriteDto favoriteDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(favoriteDto);
			var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var response = await client.PostAsync("https://localhost:7028/api/Favorite", content);

			return response.IsSuccessStatusCode;
		}

		public async Task<bool> RemoveFromFavoritesAsync(DeleteFavoriteDto deleteFavoriteDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(deleteFavoriteDto);
			var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var requestMessage = new HttpRequestMessage(HttpMethod.Delete, "https://localhost:7028/api/Favorite")
			{
				Content = content
			};

			var response = await client.SendAsync(requestMessage);

			return response.IsSuccessStatusCode;
		}

	
	}
}
