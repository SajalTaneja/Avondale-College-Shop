﻿using System.ComponentModel.DataAnnotations;

namespace Avondale_College_Shop.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        [StringLength(4, MinimumLength = 4)]
        [Range(0, 4)]
        public int Zip { get; set; }
        [Range(0, 4)]
        [StringLength(50, MinimumLength = 8)]
        public int Phone { get; set; }
        [StringLength(50, MinimumLength = 8)]
        public string Email { get; set; }

        public ICollection<Order> OrderID { get; set; }
    }
}
