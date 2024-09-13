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
    }
}
