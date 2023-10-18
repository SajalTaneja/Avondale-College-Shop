using System.ComponentModel.DataAnnotations;

namespace Avondale_College_Shop.Models
{
    public class Order
    {
        [Key]
   
        public int OrderID { get; set; }
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        [Display(Name = "To Street")]
        public string ToStreet { get; set; }
        public string Suburb { get; set; }
        [Display(Name = "To City")]
        public string ToCity { get; set; }
        [Display(Name = "To Zip")]
        public string ToZip { get; set; }
        [Display(Name = "Ship Date")]
        public DateTime ShipDate { get; set; }

        public ICollection<Product> Product { get; set; }
        public ICollection<Shipment> Shipment { get; set; }
    }
}
