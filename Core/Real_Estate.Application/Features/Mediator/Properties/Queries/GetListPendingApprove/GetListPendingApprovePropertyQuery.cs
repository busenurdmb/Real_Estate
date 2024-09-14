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
    public class GetListPendingApprovePropertyQuery : IRequest<List<GetListPendingApprovePropertyResponse>>
    {
        public class GetListPropertyQueryHandler : IRequestHandler<GetListPendingApprovePropertyQuery, List<GetListPendingApprovePropertyResponse>>
        {
            private readonly IPropertyRepository _propertyRepository;
            private readonly IMapper _mapper;

			public GetListPropertyQueryHandler(IPropertyRepository propertyRepository, IMapper mapper)
			{
				_propertyRepository = propertyRepository;
				_mapper = mapper;
			}

			public async Task<List<GetListPendingApprovePropertyResponse>> Handle(GetListPendingApprovePropertyQuery request, CancellationToken cancellationToken)
            {
                var Property = await _propertyRepository.GetListPendingByApprove();
                return _mapper.Map<List<GetListPendingApprovePropertyResponse>>(Property);
            }
        }
    }
}
