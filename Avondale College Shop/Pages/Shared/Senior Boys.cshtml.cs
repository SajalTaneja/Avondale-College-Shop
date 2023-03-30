using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Avondale_College_Shop.Pages.Shared
{
    public class Senior_BoysModel : PageModel
    {

        private readonly ILogger<Senior_BoysModel> _logger;

        public Senior_BoysModel(ILogger<Senior_BoysModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
        }
    }
}
