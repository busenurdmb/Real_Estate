using Newtonsoft.Json;
using Real_Estate.Dto.PropertyDtos;
using System.Text;

namespace Real_Estate.WebUI.Services.Property
{
	public class PropertyService : IPropertyService
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public PropertyService(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<ResultPropertyDto> GetPropertyDetailsAsync(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7028/api/Property/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				return  JsonConvert.DeserializeObject<ResultPropertyDto>(jsonData);
			}
			return null;
		}

		public async Task<List<ResultPropertyDto>> GetAllPropertiesAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7028/api/Property");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<List<ResultPropertyDto>>(jsonData);
			}
			return new List<ResultPropertyDto>();
		}

		public async Task<List<ResultPropertyDto>> GetUserPropertiesAsync(string userId)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7028/api/Property/PropertyListUserId/" + userId);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<List<ResultPropertyDto>>(jsonData);
			}
			return new List<ResultPropertyDto>();
		}

		public async Task<bool> CreatePropertyAsync(CreatePropertyDto createPropertyDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createPropertyDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7028/api/Property", stringContent);
			return responseMessage.IsSuccessStatusCode;
		}

		public async Task<bool> RemovePropertyAsync(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync("https://localhost:7028/api/Property/" + id);
			return responseMessage.IsSuccessStatusCode;
		}

		public async Task<UpdatePropertyDto> GetPropertyForUpdateAsync(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7028/api/Property/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<UpdatePropertyDto>(jsonData);
			}
			return null;
		}

		public async Task<bool> UpdatePropertyAsync(UpdatePropertyDto updatePropertyDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updatePropertyDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7028/api/Property", stringContent);
			return responseMessage.IsSuccessStatusCode;
		}

        public async Task<bool> ApprovePropertyAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.PostAsync($"https://localhost:7028/api/Property/Approve/{id}", null);
            return responseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> RejectPropertyAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.PostAsync($"https://localhost:7028/api/Property/Reject/{id}", null);
            return responseMessage.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<ResultPropertyDto>> FilterPropertiesAsync(string statusFilter, DateTime? startDate, DateTime? endDate)
        {
            var properties = await GetAllPropertiesAsync();

            if (!string.IsNullOrEmpty(statusFilter))
            {
                properties = properties.Where(p => p.Status == statusFilter).ToList();
            }

            if (startDate.HasValue && endDate.HasValue)
            {
                properties = properties.Where(p => p.AddedDate >= startDate && p.AddedDate <= endDate).ToList();
            }

            return properties;
        }

		public async Task<List<ResultPropertyDto>> GetAllApprovePropertiesAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7028/api/Property/PropertyApproveList");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<List<ResultPropertyDto>>(jsonData);
			}
			return new List<ResultPropertyDto>();
		}

        public async Task<bool> TakedownPropertyAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.PostAsync($"https://localhost:7028/api/Property/Takedown/{id}", null);
            return responseMessage.IsSuccessStatusCode;
        }
    }

}
