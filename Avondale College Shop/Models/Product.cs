using System.ComponentModel.DataAnnotations;

namespace Avondale_College_Shop.Models
{
    public class Product
    {
        [Key] 
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public string ProductItem { get; set; }

        public ICollection<Order> Order { get; set; }
        public ICollection<Shipment> Shipment { get; set; }
    }
}
