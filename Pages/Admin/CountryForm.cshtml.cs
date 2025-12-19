using Ecommerce.Entity.Model;
using Ecommerce.Model;
using Ecommerce.NTier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Ecommerce.Pages.Admin
{
    public class CountryFormModel : PageModel
    {
        private readonly ICountryTblSevices db;

        public CountryFormModel(ICountryTblSevices db)
        {
            this.db = db;
        }

        [BindProperty]
        public CountryDTO Countries { get; set; }


        public async Task<IActionResult> OnGet(int EditId)
        {
            if (EditId > 0)
            {
                var Data = await db.GetByCountryId(EditId);

                if (Data != null)
                {
                    Countries = new CountryDTO();
                    Countries.CountryName = Data.CountryName;
                    Countries.CountryId = Data.CountryId;
                }
            }
            return Page();
        }

        public async Task<IActionResult>OnPostCreate()
        {
            if (ModelState.IsValid)
            {
                var Data = await db.AddCountry(new CountryTbl()
                {

                    CountryName = Countries.CountryName,
                    Status = true
                });
                return RedirectToPage("CountryForm", new { Message = Data });
            }
            return Page();
        }
        public async Task<IActionResult>OnPostUpdate()
        {
            var Data = await db.UpdateCounty(Countries.CountryId, new CountryTbl() {

                CountryName = Countries.CountryName,
                Status = true
            });
            return RedirectToPage("CountryForm", new { Message = Data});
        }
    }
}
