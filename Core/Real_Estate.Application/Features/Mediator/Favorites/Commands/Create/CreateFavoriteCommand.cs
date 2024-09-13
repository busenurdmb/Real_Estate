using AutoMapper;
using MediatR;
using Real_Estate.Application.Features.Mediator.Properties.Commands.Create;
using Real_Estate.Application.Interfaces;
using Real_Estate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Application.Features.Mediator.Favorites.Commands.Create
{
    public class CreateFavoriteCommand : IRequest<CreateFavoriteResponse>
    {
        public int UserId { get; set; }
      
        public int PropertyId { get; set; }

        public class CreateFavoriteCommandHandler : IRequestHandler<CreateFavoriteCommand, CreateFavoriteResponse>
        {
            private readonly IEntityRepository<Favorite> _FavoriteRepository;
            private readonly IMapper _mapper;

            public CreateFavoriteCommandHandler(IEntityRepository<Favorite> favoriteRepository, IMapper mapper)
            {
                _FavoriteRepository = favoriteRepository;
                _mapper = mapper;
            }

       
            public async Task<CreateFavoriteResponse> Handle(CreateFavoriteCommand request, CancellationToken cancellationToken)
            {
                var proporty = _mapper.Map<Favorite>(request);
                await _FavoriteRepository.CreateAsync(proporty);
                return _mapper.Map<CreateFavoriteResponse>(proporty);
            }
        }
    }
}
