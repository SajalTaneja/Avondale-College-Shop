namespace Avondale_College_Shop.Pages.Shared.Models
{
    public class Shipment
    {
        public int ShipmentID { get; set; }
        public string CardChargeTime { get; set; }
        public string PackingCode { get; set; }
        public string ShipOrderTime { get; set; }
        public string ProductId { get; set; }
        public string OrderNumber { get; set; }

        public ICollection<Order> OrderID { get; set; }
        public ICollection <Product> ProductID { get; set; }
    }
}
