using Ecommerce.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce.Pages.Admin
{
    public class CityFormModel : PageModel
    {
        public CityDTO CityModel { get; set; }
        public void OnGet()
        {
        }
    }
}
