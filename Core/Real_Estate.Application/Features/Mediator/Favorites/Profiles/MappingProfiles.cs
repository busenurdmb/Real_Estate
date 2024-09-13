using AutoMapper;
using Real_Estate.Application.Features.Mediator.Favorites.Commands.Create;
using Real_Estate.Application.Features.Mediator.Favorites.Commands.Delete;
using Real_Estate.Application.Features.Mediator.Favorites.Queries.GetUserFavorites;
using Real_Estate.Application.Features.Mediator.Properties.Commands.Create;
using Real_Estate.Application.Features.Mediator.Properties.Commands.Delete;
using Real_Estate.Application.Features.Mediator.Properties.Commands.Update;
using Real_Estate.Application.Features.Mediator.Properties.Queries.GetById;
using Real_Estate.Application.Features.Mediator.Properties.Queries.GetList;
using Real_Estate.Application.Features.Mediator.Properties.Queries.GetListByUserId;
using Real_Estate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Application.Features.Mediator.Favorites.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Favorite, CreateFavoriteCommand>().ReverseMap();
            CreateMap<Favorite, CreateFavoriteResponse>().ReverseMap();

            //CreateMap<Favorite, UpdateFavoriteCommand>().ReverseMap();
            //CreateMap<Favorite, UpdateFavoriteResponse>().ReverseMap();

            CreateMap<Favorite, DeleteFavoriteCommand>().ReverseMap();
            CreateMap<Favorite, DeleteFavoriteResponse>().ReverseMap();

            //CreateMap<Favorite, GetListFavoriteResponse>().ReverseMap();
            //CreateMap<Favorite, GetByIdFavoriteResponse>().ReverseMap();
            CreateMap<Favorite, GetUserFavoritesResponse>().ReverseMap();

        }
    }
}
