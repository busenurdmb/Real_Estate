using AutoMapper;
using MediatR;
using Real_Estate.Application.Interfaces;
using Real_Estate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Application.Features.Mediator.Properties.Commands.Update
{
    public class UpdatePropertyCommand : IRequest<UpdatePropertyResponse>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public string Image { get; set; }
        public int UserId { get; set; }

        public class UpdatePropertyCommandHandler : IRequestHandler<UpdatePropertyCommand, UpdatePropertyResponse>
        {
            private readonly IEntityRepository<Property> _propertyRepository;
            private readonly IMapper _mapper;

            public UpdatePropertyCommandHandler(IEntityRepository<Property> propertyRepository, IMapper mapper)
            {
                _propertyRepository = propertyRepository;
                _mapper = mapper;
            }

         

            public async  Task<UpdatePropertyResponse> Handle(UpdatePropertyCommand request, CancellationToken cancellationToken)
            {
                Property? Property = await _propertyRepository.GetByFilterAsync(c => c.Id == request.Id);

                Property = _mapper.Map(request, Property);

                await _propertyRepository.UpdateAsync(Property);

                return _mapper.Map<UpdatePropertyResponse>(Property);
            }
        }
    }
}
