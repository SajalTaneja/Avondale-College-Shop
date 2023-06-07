namespace Avondale_College_Shop.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int Zip { get; set; }
        public int Phone { get; set; }

        public ICollection<Order> OrderID { get; set; }
    }
}
