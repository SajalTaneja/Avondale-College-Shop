namespace Avondale_College_Shop.Pages.Shared.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string  Zip { get; set; }
        public string  Phone { get; set; }

        public ICollection<Order> OrderID { get; set; }
    }
}
