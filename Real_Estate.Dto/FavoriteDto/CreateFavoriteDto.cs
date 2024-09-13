using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Dto.FavoriteDto
{
    public class CreateFavoriteDto
    {
        public int UserId { get; set; }
        public int PropertyId { get; set; }
    }
}
