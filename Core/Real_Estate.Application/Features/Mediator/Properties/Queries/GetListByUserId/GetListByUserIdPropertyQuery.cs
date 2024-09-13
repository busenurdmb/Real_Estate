using AutoMapper;
using MediatR;
using Real_Estate.Application.Features.Mediator.Properties.Queries.GetList;
using Real_Estate.Application.Interfaces;
using Real_Estate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Application.Features.Mediator.Properties.Queries.GetListByUserId
{
    public class GetListByUserIdPropertyQuery : IRequest<List<GetListByUserIdPropertyResponse>>
    {
        public int Id { get; set; }

        public GetListByUserIdPropertyQuery(int ıd)
        {
            Id = ıd;
        }

        public class GetListByUserIdPropertyQueryHandler : IRequestHandler<GetListByUserIdPropertyQuery, List<GetListByUserIdPropertyResponse>>
        {
            private readonly IPropertyRepository _propertyRepository;
            private readonly IMapper _mapper;

            public GetListByUserIdPropertyQueryHandler(IPropertyRepository propertyRepository, IMapper mapper)
            {
                _propertyRepository = propertyRepository;
                _mapper = mapper;
            }

            public async Task<List<GetListByUserIdPropertyResponse>> Handle(GetListByUserIdPropertyQuery request, CancellationToken cancellationToken)
            {
                var Property = await _propertyRepository.GetListByUserId(request.Id);
                return _mapper.Map<List<GetListByUserIdPropertyResponse>>(Property);
            }
        }
    }
}
