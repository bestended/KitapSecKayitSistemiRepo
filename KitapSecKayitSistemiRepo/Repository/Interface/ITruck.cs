using KitapSecKayitSistemiRepo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitapSecKayitSistemiRepo.Repository.Interface
{
    public interface ITruck
    {
        Task<IEnumerable<Truck>> GetTruckList();
        Task<int> AddTruck(Truck truck);
        Task<bool> UpdateTruck(Truck truck);
        Task<Truck> GetTruckById(int id);

        Task<bool> DeleteTruck(Truck truck);
    }
}
