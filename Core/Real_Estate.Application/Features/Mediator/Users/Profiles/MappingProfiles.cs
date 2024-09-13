using AutoMapper;
using Real_Estate.Application.Features.Mediator.Properties.Commands.Create;
using Real_Estate.Application.Features.Mediator.Properties.Commands.Delete;
using Real_Estate.Application.Features.Mediator.Properties.Commands.Update;
using Real_Estate.Application.Features.Mediator.Properties.Queries.GetById;
using Real_Estate.Application.Features.Mediator.Properties.Queries.GetList;
using Real_Estate.Application.Features.Mediator.Users.Commands.Create;
using Real_Estate.Application.Features.Mediator.Users.Queries.ChechUser;
using Real_Estate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Application.Features.Mediator.Users.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, CreatedUserCommand>().ReverseMap();
            CreateMap<User, CreatedUserResponse>().ReverseMap();

            //CreateMap<User, UpdateUserCommand>().ReverseMap();
            //CreateMap<User, UpdateUserResponse>().ReverseMap();

            //CreateMap<User, DeleteUserCommand>().ReverseMap();
            //CreateMap<User, DeleteUserResponse>().ReverseMap();

            CreateMap<User, GetCheckUserQuery>().ReverseMap();
            CreateMap<User, GetCheckUserQueryResponse>().ReverseMap();

        }
    }
}
