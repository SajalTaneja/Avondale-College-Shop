namespace Avondale_College_Shop.Pages.Shared.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public string ToStreet { get; set; }
        public string ToCity { get; set; }
        public string  ToZip { get; set; }
        public string  ShipDate { get; set; }
        public string ProductId { get; set; }

        public ICollection<Product> ProductID { get; set; }
    }
}
