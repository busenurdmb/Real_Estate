using Real_Estate.Dto.PropertyDtos;

namespace Real_Estate.WebUI.Services.Property
{
	public interface IPropertyService
	{
		Task<ResultPropertyDto> GetPropertyDetailsAsync(int id);
		Task<List<ResultPropertyDto>> GetAllPropertiesAsync();
		Task<List<ResultPropertyDto>> GetAllApprovePropertiesAsync();
		Task<List<ResultPropertyDto>> GetUserPropertiesAsync(string userId);
		Task<bool> CreatePropertyAsync(CreatePropertyDto createPropertyDto);
		Task<bool> RemovePropertyAsync(int id);
		Task<UpdatePropertyDto> GetPropertyForUpdateAsync(int id);
		Task<bool> UpdatePropertyAsync(UpdatePropertyDto updatePropertyDto);

		Task<bool> ApprovePropertyAsync(int id);
		Task<bool> RejectPropertyAsync(int id);
		Task<bool> TakedownPropertyAsync(int id);

        Task<IEnumerable<ResultPropertyDto>> FilterPropertiesAsync(string statusFilter, DateTime? startDate, DateTime? endDate, string sortOrder);

    }

}
