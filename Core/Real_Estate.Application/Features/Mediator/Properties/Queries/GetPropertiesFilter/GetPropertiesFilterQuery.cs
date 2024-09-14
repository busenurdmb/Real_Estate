using MediatR;
using Real_Estate.Application.Interfaces;
using Real_Estate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Application.Features.Mediator.Properties.Queries.GetPropertiesFilter
{
	public class GetPropertiesFilterQuery : IRequest<IEnumerable<GetPropertiesFilterResponse>>
	{
		public string Status { get; set; }
		public DateTime? Date { get; set; }
		public class GetPropertiesQueryHandler : IRequestHandler<GetPropertiesFilterQuery, IEnumerable<GetPropertiesFilterResponse>>
		{
			private readonly IPropertyRepository _propertyRepository;

			public GetPropertiesQueryHandler(IPropertyRepository propertyRepository)
			{
				_propertyRepository = propertyRepository;
			}

			public async Task<IEnumerable<GetPropertiesFilterResponse>> Handle(GetPropertiesFilterQuery request, CancellationToken cancellationToken)
			{
				var properties = await _propertyRepository.GetAllFilterAsync(request.Status, request.Date);
				return properties.Select(p => new GetPropertiesFilterResponse
				{
					Id = p.Id,
					Title = p.Title,
					Status = p.Status,
					AddedDate = p.AddedDate
				});
			}

			
		}
	}
}
