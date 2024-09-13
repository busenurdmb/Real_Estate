using Real_Estate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Application.Interfaces
{
   public interface IFavoriteRepository
    {
        Task<List<int>> GetUserFavoriteQuery(int id);
        Task<List<Favorite>> GetUserFavoriteQueryy(int id);
        Task<List<Property>> GetUserFavoritePropertyQuery(int id);
    }
}
