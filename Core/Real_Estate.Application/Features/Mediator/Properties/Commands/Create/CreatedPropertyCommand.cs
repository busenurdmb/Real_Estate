using AutoMapper;
using MediatR;
using Real_Estate.Application.Interfaces;
using Real_Estate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Application.Features.Mediator.Properties.Commands.Create
{
    public class CreatedPropertyCommand : IRequest<CreatedPropertyResponse>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public string Image { get; set; }
        public int UserId { get; set; }
        public class CreatedPropertyCommandHandler : IRequestHandler<CreatedPropertyCommand, CreatedPropertyResponse>
        {
            private readonly IEntityRepository<Property>  _propertyRepository;
            private readonly IMapper _mapper;

            public CreatedPropertyCommandHandler(IEntityRepository<Property> propertyRepository, IMapper mapper)
            {
                _propertyRepository = propertyRepository;
                _mapper = mapper;
            }

        

            public async Task<CreatedPropertyResponse> Handle(CreatedPropertyCommand request, CancellationToken cancellationToken)
            {
                request.Status = "Onay Bekliyor";
                request.UserId = 3;
                var proporty = _mapper.Map<Property>(request);
                await _propertyRepository.CreateAsync(proporty);
                return _mapper.Map<CreatedPropertyResponse>(proporty);
            }
        }
    }
}
