using MediatR;
using Real_Estate.Application.Interfaces;
using Real_Estate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Application.Features.Mediator.Properties.Commands.Reject
{
	public class RejectPropertyCommand : IRequest<bool>
	{
		public int PropertyId { get; set; }
		public class RejectPropertyCommandHandler : IRequestHandler<RejectPropertyCommand, bool>
		{
			private readonly IEntityRepository<Property> _propertyRepository;

			public RejectPropertyCommandHandler(IEntityRepository<Property> propertyRepository)
			{
				_propertyRepository = propertyRepository;
			}

			public async Task<bool> Handle(RejectPropertyCommand request, CancellationToken cancellationToken)
			{
				var property = await _propertyRepository.GetByIdAsync(request.PropertyId);

				if (property == null)
				{
					return false;
				}

				property.Status = "İptal Edildi"; // veya uygun bir reddetme durumu
				await _propertyRepository.UpdateAsync(property);

				return true;
			}
		}
	}
}
