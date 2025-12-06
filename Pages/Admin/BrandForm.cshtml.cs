
using Ecommerce.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce.Pages.Admin
{
   
    public class BrandFormModel : PageModel
    {
        [BindProperty]
        public BrandDTO Brandmodel { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {

            }
        }
    }
}
