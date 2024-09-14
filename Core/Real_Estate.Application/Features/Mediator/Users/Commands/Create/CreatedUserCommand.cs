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

namespace Real_Estate.Application.Features.Mediator.Users.Commands.Create
{
    public class CreatedUserCommand : IRequest<CreatedUserResponse>
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
		public string ImageUrl { get; set; }
		public int RoleId { get; set; }
        public class CreatedUserCommandHandler : IRequestHandler<CreatedUserCommand, CreatedUserResponse>
        {
            private readonly IEntityRepository<User> _UserRepository;
            private readonly IMapper _mapper;

            public CreatedUserCommandHandler(IEntityRepository<User> UserRepository, IMapper mapper)
            {
                _UserRepository = UserRepository;
                _mapper = mapper;
            }



            public async Task<CreatedUserResponse> Handle(CreatedUserCommand request, CancellationToken cancellationToken)
            {
                request.RoleId = 1;
                var user = _mapper.Map<User>(request);
                await _UserRepository.CreateAsync(user);
                return _mapper.Map<CreatedUserResponse>(user);
            }
        }
    }
}
