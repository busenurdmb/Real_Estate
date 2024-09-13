using Real_Estate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Application.Interfaces
{
   
    public interface IPropertyRepository
    {
        
        public Task<List<Property>> GetListByUserId(int id);
    }
}
