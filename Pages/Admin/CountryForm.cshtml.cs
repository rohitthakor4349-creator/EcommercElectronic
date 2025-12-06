using Ecommerce.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce.Pages.Admin
{
    public class CountryFormModel : PageModel
    {

        public CountryDTO CountryModel { get; set; }
        public void OnGet()
        {
        }
    }
}
