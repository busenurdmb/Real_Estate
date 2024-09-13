using Microsoft.EntityFrameworkCore;
using Real_Estate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Persitance.Context
{
    public class RealEstateContext : DbContext
    {
        public RealEstateContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Property> Properties { get; set; }

        public DbSet<Favorite> Favorites { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            // İlanın Price özelliği için saklama türünü belirtme
            modelBuilder.Entity<Property>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)"); // Saklama türünü belirtir

            // Diğer konfigürasyonlar
        }

    }
}
