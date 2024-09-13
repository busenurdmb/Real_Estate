using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Dto.PropertyDtos
{
	public class CreatePropertyDto
	{
		
		public string Title { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public string Status { get; set; }
        public string Image { get; set; }
        public int UserId { get; set; }
	}
}
