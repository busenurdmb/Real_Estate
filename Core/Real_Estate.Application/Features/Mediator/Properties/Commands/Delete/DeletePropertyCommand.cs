using AutoMapper;
using MediatR;
using Real_Estate.Application.Interfaces;
using Real_Estate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Application.Features.Mediator.Properties.Commands.Delete
{
    public class DeletePropertyCommand : IRequest<DeletePropertyResponse>
    {
        public int Id { get; set; }

        public DeletePropertyCommand(int ıd)
        {
            Id = ıd;
        }

        public class DeletedPropertyCommandHandler : IRequestHandler<DeletePropertyCommand, DeletePropertyResponse>
        {
            private readonly IEntityRepository<Property> _propertyRepository;
            private readonly IMapper _mapper;

            public DeletedPropertyCommandHandler(IEntityRepository<Property> propertyRepository, IMapper mapper)
            {
                _propertyRepository = propertyRepository;
                _mapper = mapper;
            }

            public async Task<DeletePropertyResponse> Handle(DeletePropertyCommand request, CancellationToken cancellationToken)
            {
                //Property? Property = await _propertyRepository.GetByFilterAsync(c => c.Id == request.Id);
                var values = await _propertyRepository.GetByIdAsync(request.Id);
                await _propertyRepository.RemoveAsync(values);

                return _mapper.Map<DeletePropertyResponse>(values);

            }
        }
    }
}
