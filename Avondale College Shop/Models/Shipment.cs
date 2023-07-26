namespace Avondale_College_Shop.Models
{
    public class Shipment
    {
        public int ShipmentID { get; set; }
        public DateTime CardChargeTime { get; set; }
        public string PackingCode { get; set; }
        public DateTime ShipOrderTime { get; set; }
        public string OrderNumber { get; set; }

        public ICollection<Order> OrderID { get; set; }
        public ICollection<Product> ProductID { get; set; }
    }
}
