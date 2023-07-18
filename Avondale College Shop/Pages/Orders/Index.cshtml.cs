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
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Avondale_College_Shop.Pages.Orders
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly Avondale_College_Shop.Areas.Identity.Data.AvondaleDbContext _context;

        public IndexModel(Avondale_College_Shop.Areas.Identity.Data.AvondaleDbContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Suburb { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? OrderSuburb { get; set; }

        public async Task OnGetAsync()
        {
            var orders = from m in _context.Order
                            select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                orders = orders.Where(s => s.Suburb.Contains(SearchString));
            }

            Order = await orders.ToListAsync();
        }
    }
}
