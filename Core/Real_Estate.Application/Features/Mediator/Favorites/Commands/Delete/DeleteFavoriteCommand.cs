using AutoMapper;
using MediatR;
using Real_Estate.Application.Interfaces;
using Real_Estate.Domain;

using System.Security.Claims;
using Microsoft.AspNetCore.Http;




namespace Real_Estate.Application.Features.Mediator.Favorites.Commands.Delete
{
    public class DeleteFavoriteCommand : IRequest<DeleteFavoriteResponse>
    {
        public int UserId { get; set; }

        public int PropertyId { get; set; }

    

        public class DeletedFavoriteCommandHandler : IRequestHandler<DeleteFavoriteCommand, DeleteFavoriteResponse>
        {
            private readonly IEntityRepository<Favorite> _FavoriteRepository;
            private readonly IMapper _mapper;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public DeletedFavoriteCommandHandler(IEntityRepository<Favorite> FavoriteRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
            {
                _FavoriteRepository = FavoriteRepository;
                _mapper = mapper;
                _httpContextAccessor = httpContextAccessor;
            }

            public async Task<DeleteFavoriteResponse> Handle(DeleteFavoriteCommand request, CancellationToken cancellationToken)
            {
             

            
                Favorite? Favorite = await _FavoriteRepository.GetByFilterAsync(c => c.PropertyId == request.PropertyId && c.UserId==request.UserId );
               // var values = await _FavoriteRepository.GetByIdAsync(request.Id);
                await _FavoriteRepository.RemoveAsync(Favorite);

                return _mapper.Map<DeleteFavoriteResponse>(Favorite);

            }
        }
    }
}
