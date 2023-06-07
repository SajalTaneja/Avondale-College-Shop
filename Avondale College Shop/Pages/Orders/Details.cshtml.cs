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
    public class DetailsModel : PageModel
    {
        private readonly Avondale_College_Shop.Areas.Identity.Data.AvondaleDbContext _context;

        public DetailsModel(Avondale_College_Shop.Areas.Identity.Data.AvondaleDbContext context)
        {
            _context = context;
        }

      public Order Order { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Order == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }
            else 
            {
                Order = order;
            }
            return Page();
        }
    }
}
