using AutoMapper;
using MediatR;
using Real_Estate.Application.Features.Mediator.Properties.Queries.GetListByUserId;
using Real_Estate.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Application.Features.Mediator.Properties.Queries.GetUserFavoriteProperty
{
    public class GetUserFavoritePropertyQuery : IRequest<List<GetUserFavoritePropertyResponse>>
    {
        public int Id { get; set; }

        public GetUserFavoritePropertyQuery(int ıd)
        {
            Id = ıd;
        }

        public class GetUserFavoritePropertyQueryHandler : IRequestHandler<GetUserFavoritePropertyQuery, List<GetUserFavoritePropertyResponse>>
        {
            private readonly IFavoriteRepository _propertyRepository;
            private readonly IMapper _mapper;

            public GetUserFavoritePropertyQueryHandler(IFavoriteRepository propertyRepository, IMapper mapper)
            {
                _propertyRepository = propertyRepository;
                _mapper = mapper;
            }

            public async Task<List<GetUserFavoritePropertyResponse>> Handle(GetUserFavoritePropertyQuery request, CancellationToken cancellationToken)
            {
                var Property = await _propertyRepository.GetUserFavoritePropertyQuery(request.Id);

                    return _mapper.Map<List<GetUserFavoritePropertyResponse>>(Property);
            }



       
        }
    }
}
