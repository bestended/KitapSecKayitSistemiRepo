using KitapSecKayitSistemiRepo.Models;
using KitapSecKayitSistemiRepo.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace KitapSecKayitSistemiRepo.Controllers
{
    public class WarehouseController : Controller
    {
        public readonly IWarehouse repositoryWarehouse;
        public WarehouseController(IWarehouse repositoryWarehouse)
        {
            this.repositoryWarehouse = repositoryWarehouse;
        }

        public async Task<IActionResult> GetWarehouseList()
        {
            var result=await repositoryWarehouse.GetWarehouse();
            return View(result);
        }



        public async Task<IActionResult> AddWarehouse()
        {
            return View();


        }


        [HttpPost]
        public async Task<IActionResult> AddWarehouse(Warehouse warehouse)
        {
            await repositoryWarehouse.AddWarehouse(warehouse);

            if (warehouse.WarehouseId == 0)
            {
                TempData["warehouseError"] = "Ekleme Başarısız";

            }
            else
            {
                TempData["warehouseSuccess"] = "Ekleme Başarılı";
            }

            return RedirectToAction("GetWarehouseList");
        }


        public async Task<IActionResult> Edit(int id)
        {
            Warehouse warehouse = new Warehouse();
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                else
                {

                    warehouse = await repositoryWarehouse.GetWarehouseById(id);
                    if (warehouse.WarehouseId == 0)
                    {
                        return NotFound();
                    }

                }




            }
            catch (System.Exception)
            {

                throw;
            }


            return View(warehouse);



        }

        [HttpPost]
        public async Task<IActionResult> Edit(Warehouse warehouse)
        {

            bool result = await repositoryWarehouse.UpdateWarehouse(warehouse);

            if (warehouse.WarehouseId==0)
            {
                TempData["warehouseError"] = "Güncelleme Başarısız";
            }
            else
            {
                TempData["warehouseSuccess"] = "Güncelleme Başarılı";
            }
            return RedirectToAction("GetWarehouseList");
        }


        public async Task<IActionResult> Delete(int id)
        {
            Warehouse warehouse = new Warehouse();
            try
            {
                if (id == 0)
                {

                    return BadRequest();
                }
                else
                {
                    warehouse = await repositoryWarehouse.GetWarehouseById(id);
                    if (warehouse == null)
                    {
                        return NotFound();
                    }


                }

            }
            catch (Exception)
            {

                throw;
            }
            return View(warehouse);

        }



        [HttpPost]
        public async Task<IActionResult> Delete(Warehouse warehouse)
        {
            bool status = await repositoryWarehouse.DeleteWarehouse(warehouse);
            if (warehouse.WarehouseId == 0)
            {

                TempData["warehouseError"] = "Silme Başarısız";


            }
            else
            {
                TempData["warehouseSuccess"] = "Silme Başarılı";
            }

            return RedirectToAction("GetWarehouseList");
        }


    }
}
