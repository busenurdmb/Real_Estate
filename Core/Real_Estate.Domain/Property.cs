using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Domain
{
    public class Property
    {
        public int Id { get; set; } // İlan ID
        public string Title { get; set; } // Başlık
        public string Description { get; set; } // Açıklama
        public DateTime? AddedDate { get; set; } // İlanın eklenme tarihi
        public string Image { get; set; } // Resim
        public decimal Price { get; set; } // Fiyat
        public string Status { get; set; } // İlan durumu (onaylı/onay bekliyor)

		
		public string? Address { get; set; } // İlanın adresi
		public int? NumberOfRooms { get; set; } // Oda sayısı
		public int? NumberOfBathrooms { get; set; } // Banyo sayısı
		public int? SquareFeet { get; set; } // İlanın metrekare cinsinden büyüklüğü
		public string? PropertyType { get; set; } // İlanın türü (örneğin: "Apartment", "House")
		public string? ContactInfo { get; set; } // İlanın iletişim bilgileri
		

		// Foreign Key - Kullanıcı ID
		public int UserId { get; set; }
        public User User { get; set; } // İlanın sahibi olan kullanıcı
    }
}
