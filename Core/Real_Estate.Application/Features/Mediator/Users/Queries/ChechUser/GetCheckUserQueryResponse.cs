using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Application.Features.Mediator.Users.Queries.ChechUser
{
    public class GetCheckUserQueryResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public bool IsExist { get; set; }
    }
}
