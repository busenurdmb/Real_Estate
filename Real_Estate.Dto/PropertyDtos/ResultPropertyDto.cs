using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Dto.PropertyDtos
{
	public class ResultPropertyDto
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime? AddedDate { get; set; }
		public decimal Price { get; set; }
		public string Status { get; set; }
		public string Image { get; set; }
		public int UserId { get; set; }
		public string Address { get; set; }
		public int NumberOfRooms { get; set; }
		public int NumberOfBathrooms { get; set; }
		public int SquareFeet { get; set; }
		public string PropertyType { get; set; }
		public string ContactInfo { get; set; }
	}
}
