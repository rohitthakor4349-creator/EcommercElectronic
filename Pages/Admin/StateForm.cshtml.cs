using Ecommerce.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce.Pages.Admin
{
    public class StateFormModel : PageModel
    {
        public StateDTO StateModel { get; set; }
        public void OnGet()
        {
        }
    }
}
