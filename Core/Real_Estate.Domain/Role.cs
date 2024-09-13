using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Domain
{
    public class Role
    {
        public int Id { get; set; } // Rol ID
        public string Name { get; set; } // Rol ismi (örneğin: Admin, User)

        // Navigation Property
        public ICollection<User> Users { get; set; } // Bu role sahip kullanıcılar
    }
}
