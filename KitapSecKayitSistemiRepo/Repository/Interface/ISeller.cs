using KitapSecKayitSistemiRepo.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitapSecKayitSistemiRepo.Repository.Interface
{
    public interface ISeller
    {
        Task<IEnumerable<Seller>> GetSellerList();
        Task<int> AddSeller(Seller seller);
        Task<bool> UpdateSeller(Seller seller);
        Task<Seller> GetSellerById(int id);


        Task<bool> DeleteSeller(Seller seller);

    }
}
