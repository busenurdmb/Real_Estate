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
		Task<IEnumerable<Property>> GetAllFilterAsync(string status, DateTime? date);
		public Task<List<Property>> GetListByUserId(int id);
		public Task<List<Property>> GetListPendingByApprove();
		public Task<List<Property>> GetListByApprove();
		public Task<int> GetListByApprovee();
	}
}
