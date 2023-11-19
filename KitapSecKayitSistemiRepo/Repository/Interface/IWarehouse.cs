using KitapSecKayitSistemiRepo.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitapSecKayitSistemiRepo.Repository.Interface
{
    public interface IWarehouse
    {

        Task<IEnumerable<Warehouse>> GetWarehouse()
;
        Task<int> AddWarehouse(Warehouse warehouse);

        Task<bool> UpdateWarehouse(Warehouse warehouse);
        Task<Warehouse> GetWarehouseById(int id);

        Task<bool> DeleteWarehouse(Warehouse warehouse);
    }
}
