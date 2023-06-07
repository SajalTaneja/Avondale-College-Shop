using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Avondale_College_Shop.Areas.Identity.Data;
using Avondale_College_Shop.Models;

namespace Avondale_College_Shop.Pages.Shared
{
    public class CreateModel : PageModel
    {
        private readonly Avondale_College_Shop.Areas.Identity.Data.AvondaleDbContext _context;

        public CreateModel(Avondale_College_Shop.Areas.Identity.Data.AvondaleDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Customer == null || Customer == null)
            {
                return Page();
            }

            _context.Customer.Add(Customer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
