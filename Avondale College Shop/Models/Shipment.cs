using System.ComponentModel.DataAnnotations;

namespace Avondale_College_Shop.Models
{
    public class Shipment
    {
        public int ShipmentID { get; set; }
        [Display(Name = "Card Charge Time")]
        public DateTime CardChargeTime { get; set; }
        [Display(Name = "Packing Code")]
        public string PackingCode { get; set; }
        [Display(Name = "Ship Order Time")]
        public DateTime ShipOrderTime { get; set; }
        [Display(Name = "Order Number")]
        public string OrderNumber { get; set; }

        public ICollection<Order> OrderID { get; set; }
        public ICollection<Product> ProductID { get; set; }
    }
}
