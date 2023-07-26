using System.ComponentModel.DataAnnotations;

namespace Avondale_College_Shop.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public string ToStreet { get; set; }
        public string Suburb { get; set; }
        public string ToCity { get; set; }
        public int ToZip { get; set; }
        public DateTime ShipDate { get; set; }

        public ICollection<Product> Product { get; set; }
        public ICollection<Shipment> Shipment { get; set; }
    }
}
