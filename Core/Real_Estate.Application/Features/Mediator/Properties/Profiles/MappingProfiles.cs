using AutoMapper;
using Real_Estate.Application.Features.Mediator.Favorites.Queries.GetUserFavorites;
using Real_Estate.Application.Features.Mediator.Properties.Commands.Create;
using Real_Estate.Application.Features.Mediator.Properties.Commands.Delete;
using Real_Estate.Application.Features.Mediator.Properties.Commands.Update;
using Real_Estate.Application.Features.Mediator.Properties.Queries.GetById;
using Real_Estate.Application.Features.Mediator.Properties.Queries.GetList;
using Real_Estate.Application.Features.Mediator.Properties.Queries.GetListByUserId;
using Real_Estate.Application.Features.Mediator.Properties.Queries.GetUserFavoriteProperty;
using Real_Estate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Application.Features.Mediator.Properties.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Property, CreatedPropertyCommand>().ReverseMap();
            CreateMap<Property, CreatedPropertyResponse>().ReverseMap();

            CreateMap<Property, UpdatePropertyCommand>().ReverseMap();
            CreateMap<Property, UpdatePropertyResponse>().ReverseMap();

            CreateMap<Property, DeletePropertyCommand>().ReverseMap();
            CreateMap<Property, DeletePropertyResponse>().ReverseMap();

            CreateMap<Property, GetListPropertyResponse>().ReverseMap();
            CreateMap<Property, GetByIdPropertyResponse>().ReverseMap();
            CreateMap<Property, GetListByUserIdPropertyResponse>().ReverseMap();

            CreateMap<Property, GetUserFavoritePropertyResponse>().ReverseMap();

        }
    }
}
