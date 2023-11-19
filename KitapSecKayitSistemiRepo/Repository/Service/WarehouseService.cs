using KitapSecKayitSistemiRepo.Data;
using KitapSecKayitSistemiRepo.Models;
using KitapSecKayitSistemiRepo.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitapSecKayitSistemiRepo.Repository.Service
{
    public class WarehouseService : IWarehouse
    {
        public readonly AppDbContext db;
        public WarehouseService(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<int> AddWarehouse(Warehouse warehouse)
        {
            await db.Warehouses.AddAsync(warehouse);
            await db.SaveChangesAsync();
            return warehouse.WarehouseId;

        }

        public async Task<bool> DeleteWarehouse(Warehouse warehouse)
        {
            bool status = false;
            if (warehouse != null)
            {
                db.Warehouses.Remove(warehouse);
                await db.SaveChangesAsync();
                status = true;
            }

            return status;
        }

        public async Task<IEnumerable<Warehouse>> GetWarehouse()
        {
            var result = await db.Warehouses.ToListAsync();
            return result;
        }

        public async Task<Warehouse> GetWarehouseById(int id)
        {
            var result = await db.Warehouses.Where(i => i.WarehouseId == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> UpdateWarehouse(Warehouse warehouse)
        {
            bool status = false;
            if (warehouse != null)
            {
                db.Warehouses.Update(warehouse);
                await db.SaveChangesAsync();
                status = true;


            }

            return status;
        }
    }
}
