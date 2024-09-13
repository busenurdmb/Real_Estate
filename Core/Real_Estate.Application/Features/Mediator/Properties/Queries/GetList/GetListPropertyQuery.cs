using AutoMapper;
using MediatR;
using Real_Estate.Application.Interfaces;
using Real_Estate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Application.Features.Mediator.Properties.Queries.GetList
{
    public class GetListPropertyQuery : IRequest<List<GetListPropertyResponse>>
    {
        public class GetListPropertyQueryHandler : IRequestHandler<GetListPropertyQuery, List<GetListPropertyResponse>>
        {
            private readonly IEntityRepository<Property> _propertyRepository;
            private readonly IMapper _mapper;

            public GetListPropertyQueryHandler(IEntityRepository<Property> propertyRepository, IMapper mapper)
            {
                _propertyRepository = propertyRepository;
                _mapper = mapper;
            }

            public async Task<List<GetListPropertyResponse>> Handle(GetListPropertyQuery request, CancellationToken cancellationToken)
            {
                var Property = await _propertyRepository.GetAllAsync();
                return _mapper.Map<List<GetListPropertyResponse>>(Property);
            }
        }
    }
}
