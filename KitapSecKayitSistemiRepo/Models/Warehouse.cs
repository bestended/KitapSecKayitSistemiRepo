using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KitapSecKayitSistemiRepo.Models
{
    public class Warehouse
    {
        [Key]
        public int WarehouseId { get; set; }
        public string Place { get; set; }       
        public string OfficerName { get; set; }
        public string PhoneNumber { get; set; }
        public int Size { get; set; }

        


    }
}
