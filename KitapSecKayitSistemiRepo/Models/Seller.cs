using System;
using System.ComponentModel.DataAnnotations;

namespace KitapSecKayitSistemiRepo.Models
{
    public class Seller
    {
        [Key]
        public int SellerId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime FoundationDate { get; set; }
        public string Address { get; set; }


    }
}
