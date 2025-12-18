using Ecommerce.Entity.Model;
using Ecommerce.NTier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Ecommerce.Pages.Admin
{
    public class BrandListModel : PageModel
    {
        private readonly IBrandTblServices db;

        public BrandListModel(IBrandTblServices db)
        {
            this.db = db;
        }
        public List<BrandTbl> BrandList { get; set; }
        public async Task FillBrand()
        {
            BrandList = await db.GetByBrandList();
        }
        public async Task OnGet()
        {
            await FillBrand();
        }
        public async Task<IActionResult> OnPostDelete(int DeleteId)
        {
            if (DeleteId > 0)
            {
                var Data = await db.DeleteBrand(DeleteId);

                return RedirectToPage("BrandList", new { Message = Data });

            }
            await FillBrand();  
            return Page();
        }
    }
}
