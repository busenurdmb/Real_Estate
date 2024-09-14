using MediatR;
using Real_Estate.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Application.Features.Mediator.Properties.Queries.GetListByApproveCount
{
	public class GetPendingApprovalCountQuery : IRequest<int>
	{
		public class GetPendingApprovalCountQueryHandler : IRequestHandler<GetPendingApprovalCountQuery, int>
		{
            private readonly IPropertyRepository _propertyRepository;

			public GetPendingApprovalCountQueryHandler(IPropertyRepository propertyRepository)
			{
				_propertyRepository = propertyRepository;
			}

			public async Task<int> Handle(GetPendingApprovalCountQuery request, CancellationToken cancellationToken)
			{
				return await _propertyRepository.GetListByApprovee();
			}
		}
	}
}
