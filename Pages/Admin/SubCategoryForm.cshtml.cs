using Ecommerce.Entity.Model;
using Ecommerce.Model;
using Ecommerce.NTier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Ecommerce.Pages.Admin
{
    public class SubCategoryModel : PageModel
    {


        private readonly ISubCategoryTblServices db;

        public SubCategoryModel(ISubCategoryTblServices db)
        {
            this.db = db;
        }

        [BindProperty]
        public SubCategoryTbl SubcategoryModel { get; set; }

        public string Message { get; set; }

        public List<SelectListItem> CategoryList { get; set; }
        public async Task FillDropCategory()
        {
            CategoryList = await db.DropCategory();
        }
      
        public async Task<IActionResult> OnGet(int EditId)
        {

            await FillDropCategory();
            if (EditId > 0)
            {
                var responseData = await db.GetBySubCategoryId(EditId);

                if (responseData != null)
                {
                    SubcategoryModel = new SubCategoryTbl();
                    SubcategoryModel.CategoryId = responseData.CategoryId;
                    SubcategoryModel.SubCategory = responseData.SubCategory;
                    SubcategoryModel.SubCategoryId = responseData.SubCategoryId;


                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPostCreate()
        {

            if (ModelState.IsValid)
            {
                var responseData = await db.AddSubCategory(new SubCategoryTbl()
                {


                    CategoryId = SubcategoryModel.CategoryId,
                    SubCategory = SubcategoryModel.SubCategory,
                    Status = true,
                    EntryDate = DateTime.Now,
                });
                if (!string.IsNullOrEmpty(responseData))
                {
                    Message = responseData;
                }
                return RedirectToAction("SubCategoryForm", new { Message = responseData });
            }
            return Page();
        }

        public async Task<IActionResult> OnPostUpdate()
        {
            var responseData = await db.UpdateSubCategory(SubcategoryModel.SubCategoryId, new SubCategoryTbl()
            {

                CategoryId = SubcategoryModel.CategoryId,
                SubCategory = SubcategoryModel.SubCategory,
                Status = true,
                EntryDate = DateTime.Now
            });
            if (!string.IsNullOrEmpty(responseData))
            {
                Message = (string)responseData;
            }
            return RedirectToAction("SubCategoryForm", new { Message = responseData });
        }
    }
}
