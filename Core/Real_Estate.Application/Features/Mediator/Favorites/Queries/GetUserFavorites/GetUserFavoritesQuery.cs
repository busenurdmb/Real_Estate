using AutoMapper;
using MediatR;
using Real_Estate.Application.Features.Mediator.Favorites.Commands.Create;
using Real_Estate.Application.Interfaces;
using Real_Estate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Application.Features.Mediator.Favorites.Queries.GetUserFavorites
{
    public class GetUserFavoritesQuery : IRequest<List<GetUserFavoritesResponse>>
    {
        public int UserId { get; set; }

        public GetUserFavoritesQuery(int userId)
        {
            UserId = userId;
        }

        public class GetUserFavoritesQueryHandler : IRequestHandler<GetUserFavoritesQuery, List<GetUserFavoritesResponse>>
        {
            private readonly IFavoriteRepository _FavoriteRepository;
            private readonly IMapper _mapper;

            public GetUserFavoritesQueryHandler(IFavoriteRepository favoriteRepository, IMapper mapper)
            {
                _FavoriteRepository = favoriteRepository;
                _mapper = mapper;
            }

            public async Task<List<GetUserFavoritesResponse>> Handle(GetUserFavoritesQuery request, CancellationToken cancellationToken)
            {
                var values= await _FavoriteRepository.GetUserFavoriteQueryy(request.UserId);
                return _mapper.Map<List<GetUserFavoritesResponse>>(values);
            }
        }
    }
}
