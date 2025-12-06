using Ecommerce.Entity.Model;
using Ecommerce.NTier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce.Pages.Admin
{
    public class CategoryModel : PageModel
    {
        private readonly ICategoryTblServices db;

        public CategoryModel(ICategoryTblServices db)
        {
            this.db = db;
        }

        public List<CategoryTbl> CategoryList { get; set; }

        public async Task FillCategoryList()
        {
            CategoryList = await db.GetByCategoryList();
        }
        public async Task OnGet()
        {
           await FillCategoryList();
        }

        public async Task<IActionResult> OnPostDelete(int DeleteId)
        {
            if (DeleteId > 0)
            {
                var responseData = await db.DeleteCategory(DeleteId);

                return RedirectToAction("Category", new { Message = responseData });
                
            }
              await  FillCategoryList();

            return RedirectToAction("/Admin/Category");


        }
    }
}
