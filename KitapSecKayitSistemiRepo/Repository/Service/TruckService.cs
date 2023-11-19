using KitapSecKayitSistemiRepo.Data;
using KitapSecKayitSistemiRepo.Models;
using KitapSecKayitSistemiRepo.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitapSecKayitSistemiRepo.Repository.Service
{
    public class TruckService : ITruck
    {
        public readonly AppDbContext db;
        public TruckService(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<int> AddTruck(Truck truck)
        {
            await db.Trucks.AddAsync(truck);
            await db.SaveChangesAsync();
            return truck.TruckId;



        }

        public async Task<bool> DeleteTruck(Truck truck)
        {
            bool status = false;
            if (truck != null)
            {
                db.Trucks.Remove(truck);
                await db.SaveChangesAsync();
                status = true;
            }

            return status;
        }

        public async Task<Truck> GetTruckById(int id)
        {
            var result = await db.Trucks.Where(i => i.TruckId == id).FirstOrDefaultAsync();
            return result;


        }

        public async Task<IEnumerable<Truck>> GetTruckList()
        {
            var result = await db.Trucks.ToListAsync();
            return result;

        }

        public async Task<bool> UpdateTruck(Truck truck)
        {
            var status = false;

            if (truck != null)
            {
                db.Trucks.Update(truck);
                await db.SaveChangesAsync();

                status = true;
            }

            return status;
        }
    }
}
