using Ecommerce.Entity.Model;
using Ecommerce.NTier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Ecommerce.Pages.Admin
{
    public class CityListModel : PageModel
    {
        private readonly ICityTblServices db;

        public CityListModel(ICityTblServices db)
        {
            this.db = db;
        }

        public List<CityTbl> CityList { get; set; }

        public async Task FillCity()
        {
            CityList = await db.GetByCityList();
        }
        public async Task OnGet()
        {
            await FillCity();
        }

        public async Task<IActionResult> OnPostDelete(int DeleteId)
        {
            if (DeleteId > 0)
            {
                var Msg = await db.DeleteCity(DeleteId);

                if (Msg != null)
                {
                    return RedirectToPage("CityList", new {Message = Msg });
                }
                await FillCity();
            }
            return RedirectToPage("CityList");
        }
    }
}
