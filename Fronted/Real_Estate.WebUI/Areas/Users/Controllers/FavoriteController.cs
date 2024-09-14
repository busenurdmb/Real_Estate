using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Real_Estate.Dto.FavoriteDto;
using Real_Estate.Dto.PropertyDtos;
using Real_Estate.WebUI.Services.Favorite;
using System.Security.Claims;
using System.Text;
using X.PagedList.Extensions;

namespace Real_Estate.WebUI.Areas.Users.Controllers
{
	[Authorize(Roles = "User")]
	[Area("Users")]
	[Route("Users/Favorite")]
	public class FavoriteController : Controller
	{
		private readonly IFavoriteService _favoriteService;

		public FavoriteController(IFavoriteService favoriteService)
		{
			_favoriteService = favoriteService;
		}

		[Route("MyFavorite")]
		public async Task<IActionResult> MyFavorite(int? page)
		{
			var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
			var favorites = await _favoriteService.GetUserFavoritesAsync(userId);
            int pageNumber = page ?? 1;
            var pagedList = favorites.ToPagedList(pageNumber, 6);

            return View(pagedList);
            
		}

		[Route("CreateFavorite/{id}")]
		public async Task<IActionResult> CreateFavorite(int id)
		{
			var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
			var createFavoriteDto = new CreateFavoriteDto
			{
				UserId = userId,
				PropertyId = id
			};

			var success = await _favoriteService.AddToFavoritesAsync(createFavoriteDto);

			if (success)
			{
				return RedirectToAction("GetAll", "Property", new { area = "User" });
			}

			return View();
		}

		[Route("RemoveFavorite/{id}")]
		public async Task<IActionResult> RemoveFavorite(int id)
		{
			var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
			var deleteFavoriteDto = new DeleteFavoriteDto
			{
				UserId = userId,
				PropertyId = id
			};

			var success = await _favoriteService.RemoveFromFavoritesAsync(deleteFavoriteDto);

			if (success)
			{
				return RedirectToAction("GetAll", "Property", new { area = "User" });
			}

			return View();
		}
	}
}
