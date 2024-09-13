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

        public string Image { get; set; } // Resim
        public decimal Price { get; set; } // Fiyat
        public string Status { get; set; } // İlan durumu (onaylı/onay bekliyor)

        // Foreign Key - Kullanıcı ID
        public int UserId { get; set; }
        public User User { get; set; } // İlanın sahibi olan kullanıcı
    }
}
