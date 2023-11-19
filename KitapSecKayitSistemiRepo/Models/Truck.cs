using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KitapSecKayitSistemiRepo.Models
{
    public class Truck
    {
        [Key]
        public int TruckId { get; set; }
        public string TruckDriver { get; set; }
        public string DriverPhone { get; set; }
        public int TruckSize { get; set; }
        public string DrivingLicenceNumber { get; set; }
        public string NumberPlate { get; set; }

        public int WarehouseId { get; set; }
        [ForeignKey("WarehouseId")]
        public virtual Warehouse Warehouses { get; set; }


    }
}
