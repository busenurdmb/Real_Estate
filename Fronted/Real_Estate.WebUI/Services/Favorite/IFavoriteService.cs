using Real_Estate.Dto.FavoriteDto;
using Real_Estate.Dto.PropertyDtos;

namespace Real_Estate.WebUI.Services.Favorite
{
	public interface IFavoriteService
	{
		Task<List<ResultPropertyDto>> GetUserFavoritesAsync(int userId);
		Task<bool> AddToFavoritesAsync(CreateFavoriteDto favoriteDto);
		Task<bool> RemoveFromFavoritesAsync(DeleteFavoriteDto deleteFavoriteDto);
		
	}
}
