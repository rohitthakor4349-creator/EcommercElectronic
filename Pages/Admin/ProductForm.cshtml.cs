using Ecommerce.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce.Pages.Admin
{
    public class ProductFormModel : PageModel
    {

        [BindProperty]
        public ProductDTO Productmodel { get; set; }

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
