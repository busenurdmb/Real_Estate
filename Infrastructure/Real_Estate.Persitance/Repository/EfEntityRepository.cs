using Microsoft.EntityFrameworkCore;
using Real_Estate.Application.Interfaces;
using Real_Estate.Persitance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Persitance.Repository
{
    public class EfEntityRepository<T> : IEntityRepository<T>
         where T : class
         
    {
        protected RealEstateContext _context;

        public EfEntityRepository(RealEstateContext context)
        {
            _context = context;
        }

        //protected bu sınıfı miras alan sınıflarda kullanabilir.



        public async Task CreateAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {

            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(filter);
        }

        public async Task<T> GetByIdAsync(int id)

        {

            return await _context.Set<T>().FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
