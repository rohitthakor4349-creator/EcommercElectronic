using Ecommerce.Model;
using Ecommerce.NTier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce.Pages.Admin
{
    public class ThirdCategoryFormModel : PageModel
    {
        private readonly IThirdCategoryTblServices db;

        public ThirdCategoryFormModel(IThirdCategoryTblServices db)
        {
            this.db = db;   
        }
        [BindProperty]
        public ThirdCategoryDTO ThirdCategorymodel { get; set; }
        public void OnGet()
        {
        }
        public void OnPost() {

            if (ModelState.IsValid)
            {

            }
        }
    }
}
