using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Domain
{
   public class Favorite
    {
        public int Id { get; set; } // Favori ID'si, her kaydı benzersiz kılar

        // Foreign Key - Kullanıcı ID
        public int UserId { get; set; }
        public User User { get; set; } // Favori ilanı ekleyen kullanıcı

        // Foreign Key - İlan ID
        public int PropertyId { get; set; }
        public Property Property { get; set; } // Favori ilan
    }
}
