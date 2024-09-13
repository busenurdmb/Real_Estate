using MediatR;
using Microsoft.AspNetCore.Mvc;
using Real_Estate.Application.Features.Mediator.Favorites.Commands.Create;
using Real_Estate.Application.Features.Mediator.Favorites.Commands.Delete;
using Real_Estate.Application.Features.Mediator.Favorites.Queries.GetUserFavorites;
using Real_Estate.Application.Features.Mediator.Properties.Commands.Create;
using Real_Estate.Application.Features.Mediator.Properties.Commands.Delete;
using Real_Estate.Application.Features.Mediator.Properties.Queries.GetById;
using Real_Estate.Application.Features.Mediator.Properties.Queries.GetList;
using Real_Estate.Application.Features.Mediator.Properties.Queries.GetListByUserId;
using Real_Estate.Application.Features.Mediator.Properties.Queries.GetUserFavoriteProperty;

namespace Real_Estate.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FavoriteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetUserFavorites/{id}")]
        public async Task<IActionResult> GetUserFavorites(int id)
        {
            var values = await _mediator.Send(new GetUserFavoritesQuery(id));

            return Ok(values);
        }
        [HttpGet("GetUserFavoritesProperty/{id}")]
        public async Task<IActionResult> GetUserFavoritesProperety(int id)
        {
            var values = await _mediator.Send(new GetUserFavoritePropertyQuery(id));

            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateFavoriteCommand createFavoriteCommand)
        {
            CreateFavoriteResponse response = await _mediator.Send(createFavoriteCommand);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteFavoriteCommand deleteFavoriteCommand)
        {
            DeleteFavoriteResponse response = await _mediator.Send(deleteFavoriteCommand);

            return Ok(response);
        }

    }
}
