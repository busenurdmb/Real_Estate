using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Application.Features.Mediator.Favorites.Commands.Delete
{
  public class DeleteFavoriteResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public int PropertyId { get; set; }
    }
}
