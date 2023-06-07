using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Avondale_College_Shop.Areas.Identity.Data;
using Avondale_College_Shop.Models;

namespace Avondale_College_Shop.Pages.Shipments
{
    public class EditModel : PageModel
    {
        private readonly Avondale_College_Shop.Areas.Identity.Data.AvondaleDbContext _context;

        public EditModel(Avondale_College_Shop.Areas.Identity.Data.AvondaleDbContext context)
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

            var shipment =  await _context.Shipment.FirstOrDefaultAsync(m => m.ShipmentID == id);
            if (shipment == null)
            {
                return NotFound();
            }
            Shipment = shipment;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Shipment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShipmentExists(Shipment.ShipmentID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ShipmentExists(int id)
        {
          return (_context.Shipment?.Any(e => e.ShipmentID == id)).GetValueOrDefault();
        }
    }
}
