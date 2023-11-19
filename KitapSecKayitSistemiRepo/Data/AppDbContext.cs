using KitapSecKayitSistemiRepo.Models;
using Microsoft.EntityFrameworkCore;

namespace KitapSecKayitSistemiRepo.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>option):base(option)
        {
            
        }

        public DbSet<Books> Books { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        

    }
}
