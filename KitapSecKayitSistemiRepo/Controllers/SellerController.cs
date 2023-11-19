
using KitapSecKayitSistemiRepo.Models;
using KitapSecKayitSistemiRepo.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace KitapSecKayitSistemiRepo.Controllers
{
    public class SellerController : Controller
    {
        public readonly ISeller repositorySeller;
        public SellerController(ISeller repositorySeller)
        {
            this.repositorySeller = repositorySeller;
        }


        public async Task<IActionResult> GetSellerList()
        {
            var result = await repositorySeller.GetSellerList();
            return View(result);
        }

        public async Task<IActionResult> AddSeller()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> AddSeller(Seller seller)
        {

            await repositorySeller.AddSeller(seller);
            if (seller.SellerId == 0)
            {

                TempData["sellerError"] = "Kayıt Başarısız";

            }
            else
            {
                TempData["sellerSuccess"] = "Kayıt Başarılı";


            }
            return RedirectToAction("GetSellerList");

        }

        public async Task<IActionResult> Edit(int id)
        {
            Seller seller = new Seller();

            try
            {
                if (id == 0)
                {  
                    return BadRequest(); 
                }
                 
                else
                {
                    seller=await repositorySeller.GetSellerById(id);
                    if (seller==null)
                    {
                        return NotFound();

                    }

                }
            }
            catch (Exception)
            {

                throw;
            }

            return View(seller);



        }
        [HttpPost]
        public async Task<IActionResult> Edit(Seller seller)
        {
            bool status = await repositorySeller.UpdateSeller(seller);
            if (seller.SellerId==0)
            {
               
                TempData["sellerError"] = "Güncelleme Başarısız";


            }
            else
            {

                TempData["sellerSuccess"] = "Güncelleme Başarılı";
            }
            return RedirectToAction("GetSellerList");
           
        }


        public async Task<IActionResult> Delete(int id)
        {
            Seller seller = new Seller();
            try
            {
                if (id == 0)
                {

                    return BadRequest();
                }
                else
                {
                    seller = await repositorySeller.GetSellerById(id);
                    if (seller == null)
                    {
                        return NotFound();
                    }


                }

            }
            catch (Exception)
            {

                throw;
            }
            return View(seller);

        }



        [HttpPost]
        public async Task<IActionResult> Delete(Seller seller)
        {
            bool status = await repositorySeller.DeleteSeller(seller);
            if (seller.SellerId == 0)
            {

                TempData["sellerError"] = "Silme Başarısız";


            }
            else
            {
                TempData["sellerSuccess"] = "Silme Başarılı";
            }

            return RedirectToAction("GetSellerList");
        }


    }
}
