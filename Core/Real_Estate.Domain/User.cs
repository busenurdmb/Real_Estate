using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Domain
{
    public class User
    {
        public int Id { get; set; } // Kullanıcı ID
        public string Username { get; set; }
        public string FirstName { get; set; } // Ad
        public string LastName { get; set; } // Soyad
        public string Email { get; set; } // Email
        public string Password { get; set; } // Şifre

        // Foreign Key - Role ID
        public int RoleId { get; set; } // Kullanıcının rol ID'si
        public Role Role { get; set; } // Kullanıcının rolü
    }
}
