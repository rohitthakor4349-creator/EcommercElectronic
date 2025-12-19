using Ecommerce.Entity.Model;
using Ecommerce.NTier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Ecommerce.Pages.Admin
{
    public class CountryListModel : PageModel
    {
        private readonly ICountryTblSevices db;

        public CountryListModel(ICountryTblSevices db)
        {
            this.db = db;   
        }

        [BindProperty]
        public List<CountryTbl> CountryList { get; set; }

        public async Task FillCountry()
        {
            CountryList = await db.GetByCountryList();
        }
        public async Task OnGet()
        {
            await FillCountry();
        }

        public async Task<IActionResult>OnPostDelete(int DeleteId)
        {
            if (DeleteId > 0)
            {
                var Data = await db.DeleteCounrty(DeleteId);
                if (Data != null)
                {
                    return RedirectToPage("CountryList", new { Message = Data });
                }
                await FillCountry();
            }
            return RedirectToPage("CountryList");
        }
    }
}
