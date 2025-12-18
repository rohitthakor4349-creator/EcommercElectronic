using Ecommerce.Entity.Model;
using Ecommerce.NTier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Ecommerce.Pages.Admin
{
    public class ThirdCategoryListModel : PageModel
    {
        private readonly IThirdCategoryTblServices db;

        public ThirdCategoryListModel(IThirdCategoryTblServices db)
        {
            this.db = db;
        }

        public List<ThirdCategoryTbl> ThirdCategoryList { get; set; }

        public async Task FillThirdCategory()
        {
            ThirdCategoryList = await db.GetByThirdCategoryList();
        }
        public async Task OnGet()
        {
            await FillThirdCategory();
        }

        public async Task<IActionResult> OnPostDelete(int DeleteId)
        {
            if (DeleteId > 0)
            {
                var Data = await db.DeleteThirdCategory(DeleteId);

                return RedirectToPage("ThirdCategoryList", new { Mesaage = Data });
            }
            await FillThirdCategory();
            return RedirectToPage("ThirdCategoryList");
            
        }
    }
}
