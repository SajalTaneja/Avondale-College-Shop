using System.ComponentModel.DataAnnotations;

namespace Avondale_College_Shop.Models
{
    public class Product
    {
        [Key] 
        public int ProductID { get; set; }
        [Range (1,10, ErrorMessage="Please enter a value between 1 to 10")]
        public int Quantity { get; set; }
        [Display(Name = "Product Item")]
        public string ProductItem { get; set; }

        public ICollection<Order> Order { get; set; }
        public ICollection<Shipment> Shipment { get; set; }
    }
}
