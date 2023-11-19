using KitapSecKayitSistemiRepo.Data;
using KitapSecKayitSistemiRepo.Models;
using KitapSecKayitSistemiRepo.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace KitapSecKayitSistemiRepo.Controllers
{
    public class TruckController : Controller
    {
        public readonly ITruck repositoryTruck;
        public TruckController(ITruck repositoryTruck)
        {
            this.repositoryTruck = repositoryTruck;
        }



        public async Task<IActionResult> GetTruckList()
        {
            var result = await repositoryTruck.GetTruckList();
            return View(result);


        }



        public async Task<IActionResult> AddTruck()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> AddTruck(Truck truck)
        {
            await repositoryTruck.AddTruck(truck);

            if (truck.TruckId == 0)
            {
                TempData["truckError"] = "Kayıt Başarısız";


            }
            else
            {
                TempData["truckSuccess"] = "Kayıt Başarılı";


            }
            return RedirectToAction("GetTruckList");

        }


        public async Task<IActionResult> Edit(int id)
        {
            Truck truck = new Truck();
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                else
                {
                    truck = await repositoryTruck.GetTruckById(id);

                    if (truck == null)
                    {
                        return NotFound();
                    }


                }
            }
            catch (System.Exception)
            {

                throw;
            }
            return View(truck);

          
        }



        [HttpPost]
        public async Task<IActionResult> Edit(Truck truck)
        {
            if (truck != null)
            {
                bool result = await repositoryTruck.UpdateTruck(truck);
                if (truck.TruckId == 0)
                {
                    TempData["truckError"] = "Güncelleme Başarısız";
                }
                else
                {
                    TempData["truckSuccess"] = "Güncelleme Başarılı";
                }

            }
            return RedirectToAction("GetTruckList");

        }



        public async Task<IActionResult> Delete(int id)
        {
            Truck truck = new Truck();
            try
            {
                if (id == 0)
                {

                    return BadRequest();
                }
                else
                {
                    truck = await repositoryTruck.GetTruckById(id);
                    if (truck == null)
                    {
                        return NotFound();
                    }


                }

            }
            catch (Exception)
            {

                throw;
            }
            return View(truck);

        }



        [HttpPost]
        public async Task<IActionResult> Delete(Truck truck)
        {
            bool status = await repositoryTruck.DeleteTruck(truck);
            if (truck.TruckId == 0)
            {

                TempData["truckError"] = "Silme Başarısız";


            }
            else
            {
                TempData["truckSuccess"] = "Silme Başarılı";
            }

            return RedirectToAction("GetTruckList");
        }


    }
}
