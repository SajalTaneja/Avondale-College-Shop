namespace Avondale_College_Shop.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public string ToStreet { get; set; }
        public string ToCity { get; set; }
        public int ToZip { get; set; }
        public DateTime ShipDate { get; set; }
        public string ProductId { get; set; }

        public ICollection<Product> ProductID { get; set; }
    }
}
