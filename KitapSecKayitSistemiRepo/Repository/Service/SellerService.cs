using KitapSecKayitSistemiRepo.Data;
using KitapSecKayitSistemiRepo.Models;
using KitapSecKayitSistemiRepo.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitapSecKayitSistemiRepo.Repository.Service
{


    public class SellerService : ISeller
    {
        public readonly AppDbContext db;

        public SellerService(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<int> AddSeller(Seller seller)
        {
            await db.Sellers.AddAsync(seller);
            await db.SaveChangesAsync();
            return seller.SellerId;


        }

        public async Task<bool> DeleteSeller(Seller seller)
        {
            bool status = false;
            if (seller != null)
            {
                db.Sellers.Remove(seller);
                await db.SaveChangesAsync();
                status = true;
            }

            return status;
        }

        public async Task<Seller> GetSellerById(int id)
        {
            var result=await db.Sellers.Where(i => i.SellerId == id).FirstOrDefaultAsync();
            return result;

        }

        public async Task<IEnumerable<Seller>> GetSellerList()
        {
           var result=await db.Sellers.ToListAsync();
            return result;
        }

        public async Task<bool> UpdateSeller(Seller seller)
        {
            bool status = false;
            if (seller != null)
            {
                db.Sellers.Update(seller);
                await db.SaveChangesAsync();
                status = true;
            }
         
            return status;

        }
    }
}
