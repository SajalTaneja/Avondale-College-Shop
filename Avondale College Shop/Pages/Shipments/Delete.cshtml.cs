using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Avondale_College_Shop.Areas.Identity.Data;
using Avondale_College_Shop.Models;

namespace Avondale_College_Shop.Pages.Shipments
{
    public class DeleteModel : PageModel
    {
        private readonly Avondale_College_Shop.Areas.Identity.Data.AvondaleDbContext _context;

        public DeleteModel(Avondale_College_Shop.Areas.Identity.Data.AvondaleDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Shipment Shipment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Shipment == null)
            {
                return NotFound();
            }

            var shipment = await _context.Shipment.FirstOrDefaultAsync(m => m.ShipmentID == id);

            if (shipment == null)
            {
                return NotFound();
            }
            else 
            {
                Shipment = shipment;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Shipment == null)
            {
                return NotFound();
            }
            var shipment = await _context.Shipment.FindAsync(id);

            if (shipment != null)
            {
                Shipment = shipment;
                _context.Shipment.Remove(Shipment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
