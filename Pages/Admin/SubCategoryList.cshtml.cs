using Ecommerce.Entity.Model;
using Ecommerce.NTier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Ecommerce.Pages.Admin
{
    public class SubCategoryListModel : PageModel
    {
        private readonly ISubCategoryTblServices db;

        public SubCategoryListModel(ISubCategoryTblServices db)
        {
            this.db = db;
        }

        public List<SubCategoryTbl> SubCategoryList { get; set; }
        public async Task FillSubCategoryList()
        {
             SubCategoryList   = await db.GetBySubCategoryList();
        } 
        public async Task OnGet()
        {
            await FillSubCategoryList();
        }

        public async Task<IActionResult> OnPostDelete(int DeleteId)
        {
            if (DeleteId > 0)
            {
                var responseData = await db.DeleteSubCategory(DeleteId);

                return RedirectToAction("SubCategoryList", new { Message = responseData });

            }
            await FillSubCategoryList();
            return RedirectToAction("/Admin/SubCategoryList");
        }
    }
}
