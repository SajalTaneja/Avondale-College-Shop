using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Avondale_College_Shop.Areas.Identity.Data;

// Add profile data for application users by adding properties to the AvondaleCollegeShopUser class
public class AvondaleCollegeShopUser : IdentityUser
{
    public AvondaleCollegeShopUser(string userName) : base(userName)
    {
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }

}
