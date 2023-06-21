using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public IList<Customer> Customer { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? FirstName { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? CustomerName { get; set; }

        public async Task OnGetAsync()
        {
            var customers = from m in _context.Customer
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                customers = customers.Where(s => s.FirstName.Contains(SearchString));
            }

            Customer = await customers.ToListAsync();
        }

    }
}
