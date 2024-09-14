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


    public class PropertyRepository : IPropertyRepository
    {
        protected RealEstateContext _context;

        public PropertyRepository(RealEstateContext context)
        {
            _context = context;
        }

        public async Task<List<Property>> GetListByUserId(int id)
        {
            return await _context.Properties.Where(x => x.UserId == id).ToListAsync();
        }

		public async Task<IEnumerable<Property>> GetAllFilterAsync(string status, DateTime? date)
		{
			IQueryable<Property> query = _context.Properties;

			if (!string.IsNullOrEmpty(status))
			{
				query = query.Where(p => p.Status == status);
			}
			// Tarih filtresi
			if (date.HasValue)
			{
				var filterDate = date.Value.Date; // Tarih kısmını almak için
				query = query.Where(p => p.AddedDate.HasValue && p.AddedDate.Value.Date == filterDate);
			}

			

			return await query.ToListAsync();
		}

		public async Task<List<Property>> GetListPendingByApprove()
		{
			return await _context.Properties
		   .Where(p => p.Status == "Onay Bekliyor") 
		   .ToListAsync();
		}

		public async Task<int> GetListByApprovee()
		{
			return await _context.Properties
		   .CountAsync(p => p.Status == "Onay Bekliyor");
		}

		public async Task<List<Property>> GetListByApprove()
		{
			return await _context.Properties
	   .Where(p => p.Status == "Onaylandı")
	   .ToListAsync();
		}
	}
}
