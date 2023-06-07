using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Avondale_College_Shop.Areas.Identity.Data;
using Avondale_College_Shop.Models;

namespace Avondale_College_Shop.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly Avondale_College_Shop.Areas.Identity.Data.AvondaleDbContext _context;

        public IndexModel(Avondale_College_Shop.Areas.Identity.Data.AvondaleDbContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Order != null)
            {
                Order = await _context.Order.ToListAsync();
            }
        }
    }
}
