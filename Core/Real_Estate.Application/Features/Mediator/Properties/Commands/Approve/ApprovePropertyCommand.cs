using MediatR;
using Real_Estate.Application.Interfaces;
using Real_Estate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Application.Features.Mediator.Properties.Commands.Approve
{
	public class ApprovePropertyCommand : IRequest<bool>
	{
		public int PropertyId { get; set; }

		public class ApprovePropertyCommandHandler : IRequestHandler<ApprovePropertyCommand, bool>
		{
			private readonly IEntityRepository<Property> _propertyRepository;

			public ApprovePropertyCommandHandler(IEntityRepository<Property> propertyRepository)
			{
				_propertyRepository = propertyRepository;
			}

			public async Task<bool> Handle(ApprovePropertyCommand request, CancellationToken cancellationToken)
			{
				var property = await _propertyRepository.GetByIdAsync(request.PropertyId);

				if (property == null)
				{
					return false;
				}

				property.Status = "Onaylandı"; // veya uygun bir onay durumu
				await _propertyRepository.UpdateAsync(property);

				return true;
			}
		}
	}
}
