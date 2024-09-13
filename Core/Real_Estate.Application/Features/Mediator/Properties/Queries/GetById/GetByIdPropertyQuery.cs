using AutoMapper;
using MediatR;
using Real_Estate.Application.Interfaces;
using Real_Estate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Application.Features.Mediator.Properties.Queries.GetById
{
    public class GetByIdPropertyQuery : IRequest<GetByIdPropertyResponse>
    {
        public int Id { get; set; }
        public class GetByIdPropertyQueryHandler : IRequestHandler<GetByIdPropertyQuery, GetByIdPropertyResponse>
        {
            private readonly IEntityRepository<Property> _propertyRepository;
            private readonly IMapper _mapper;
            public GetByIdPropertyQueryHandler(IEntityRepository<Property> propertyRepository, IMapper mapper)
            {
                _propertyRepository = propertyRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdPropertyResponse> Handle(GetByIdPropertyQuery request, CancellationToken cancellationToken)
            {
                var values = await _propertyRepository.GetByFilterAsync(b => b.Id == request.Id);
                return _mapper.Map<GetByIdPropertyResponse>(values);
            }
        }
    }
}
