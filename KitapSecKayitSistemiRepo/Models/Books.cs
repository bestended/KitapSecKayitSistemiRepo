using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KitapSecKayitSistemiRepo.Models
{
    public class Books
    {
        [Key]
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Writer { get; set; }
        public bool IsStockState { get; set; }
        public decimal Price { get; set; }
        public int PageCount { get; set; }
        public int TruckId { get; set; }
        [ForeignKey("TruckId")]
        public virtual Truck Trucks { get; set; }

        public int SellerId { get; set; }
        [ForeignKey("SellerId")]
        public virtual Seller Sellers { get; set; }


    }
}
