using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Avondale_College_Shop.Areas.Identity.Data;
using Avondale_College_Shop.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Avondale_College_Shop.Pages.Shared
  
{
    
    public class IndexModel : PageModel
    {
        private readonly Avondale_College_Shop.Areas.Identity.Data.AvondaleDbContext _context;

        public IndexModel(Avondale_College_Shop.Areas.Identity.Data.AvondaleDbContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Customer> Customers { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            CurrentFilter = searchString;

            IQueryable<Customer> customerIQ = from s in _context.Customer
                                              select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                customerIQ = customerIQ.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    customerIQ = customerIQ.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    customerIQ = customerIQ.OrderBy(s => s.FirstName);
                    break;
                case "date_desc":
                    customerIQ = customerIQ.OrderByDescending(s => s.FirstName);
                    break;
                default:
                    customerIQ = customerIQ.OrderBy(s => s.LastName);
                    break;
            }

            Customers = await customerIQ.AsNoTracking().ToListAsync();
        }
    }
}   