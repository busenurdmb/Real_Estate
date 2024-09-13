using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Real_Estate.Application.Interfaces;
using Real_Estate.Domain;
using Real_Estate.Persitance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Persitance.Repository
{
    public class FavoriteRepository : IFavoriteRepository
    {
        protected RealEstateContext _context;

        public FavoriteRepository(RealEstateContext context)
        {
            _context = context;
        }

        public async Task<List<Property>> GetUserFavoritePropertyQuery(int id)
        {
            // Kullanıcının favori ilanlarının ID'lerini al
            var favoritePropertyIds = await GetUserFavoriteQuery(id);

            // Favori ilanların detaylarını al
            var favoriteProperties = await _context.Properties
                .Where(p => favoritePropertyIds.Contains(p.Id))
                .ToListAsync();

            return favoriteProperties;
        }

        public async Task<List<int>> GetUserFavoriteQuery(int id)
        {
            return await _context.Favorites
                     .Where(f => f.UserId == id)
                     .Select(f => f.PropertyId).ToListAsync();
                     
        }

        public async Task<List<Favorite>> GetUserFavoriteQueryy(int id)
        {
            return await _context.Favorites
                      .Where(f => f.UserId == id)
                      .ToListAsync();
        }
    }
}
