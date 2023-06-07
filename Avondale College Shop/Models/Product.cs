namespace Avondale_College_Shop.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Quantity { get; set; }
        public string ProductItem { get; set; }


        public ICollection<Shipment> ShipmentID { get; set; }
    }
}
