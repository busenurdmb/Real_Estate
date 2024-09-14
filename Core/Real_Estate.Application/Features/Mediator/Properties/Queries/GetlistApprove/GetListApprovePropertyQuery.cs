using AutoMapper;
using MediatR;
using Real_Estate.Application.Features.Mediator.Properties.Queries.GetList;
using Real_Estate.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Application.Features.Mediator.Properties.Queries.GetlistApprove
{
	public class GetListApprovePropertyQuery : IRequest<List<GetListApprovePropertyResponse>>
	{
		public class GetListPropertyQueryHandler : IRequestHandler<GetListApprovePropertyQuery, List<GetListApprovePropertyResponse>>
		{
			private readonly IPropertyRepository _propertyRepository;
			private readonly IMapper _mapper;

			public GetListPropertyQueryHandler(IPropertyRepository propertyRepository, IMapper mapper)
			{
				_propertyRepository = propertyRepository;
				_mapper = mapper;
			}

			public async Task<List<GetListApprovePropertyResponse>> Handle(GetListApprovePropertyQuery request, CancellationToken cancellationToken)
			{
				var Property = await _propertyRepository.GetListByApprove();
				return _mapper.Map<List<GetListApprovePropertyResponse>>(Property);
			}
		}
	}
}
