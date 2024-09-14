using MediatR;
using Real_Estate.Application.Features.Mediator.Users.Queries.ChechUser;
using Real_Estate.Application.Interfaces;
using Real_Estate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Application.Features.Mediator.Users.Queries.ChechUser
{
  
    public class GetCheckUserQuery : IRequest<GetCheckUserQueryResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public class GetCheckUserQueryHandler : IRequestHandler<GetCheckUserQuery, GetCheckUserQueryResponse>
        {
            private readonly IEntityRepository<User> _userRepository;
            private readonly IEntityRepository<Role> _roleRepository;

            public GetCheckUserQueryHandler(IEntityRepository<User> userRepository, IEntityRepository<Role> roleRepository)
            {
                _userRepository = userRepository;
                _roleRepository = roleRepository;
            }

            public async Task<GetCheckUserQueryResponse> Handle(GetCheckUserQuery request, CancellationToken cancellationToken)
            {
                var values = new GetCheckUserQueryResponse();
                var user = await _userRepository.GetByFilterAsync(x => x.Username == request.Username && x.Password == request.Password);
                if (user == null)
                {
                    values.IsExist = false;
                }
                else
                {
                    values.IsExist = true;
                    values.Username = user.FirstName;
                    var valuess = await _roleRepository.GetByFilterAsync(x => x.Id == user.RoleId);
                    values.Role = (await _roleRepository.GetByFilterAsync(x => x.Id == user.RoleId)).Name;
                    values.Id = user.Id;
                    values.Email= user.Email;
                    values.FirstName = user.FirstName;
                    values.LastName = user.LastName;
                   
                }
                return values;
            }
        }
    }
}
