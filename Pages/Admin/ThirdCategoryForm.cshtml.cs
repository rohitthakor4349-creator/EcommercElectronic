using Ecommerce.Entity.Model;
using Ecommerce.Model;
using Ecommerce.NTier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

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
        public ThirdCategoryDTO ThirdCategories { get; set; }

        public List<SelectListItem> CategoryList { get; set; }
        public List<SelectListItem> SubCategoryList { get; set; }
       

        public async Task FillCategory()
        {
            CategoryList = await db.DropCategory();
        }
        public async Task OnGet(int EditId)
        {
          await  FillCategory();
            if (EditId > 0)
            {
                var Data = await db.GetByThirdCategoryId(EditId);

                if (Data.CategoryId != null)
                {
                    SubCategoryList = await db.DropSubCategory(Data.CategoryId.Value);
                }
                else
                {
                    SubCategoryList = new List<SelectListItem>();
                }
                if (Data != null)
                {
                    ThirdCategories = new ThirdCategoryDTO();
                    ThirdCategories.SubCategoryId = Data.SubCategoryId;
                    ThirdCategories.CategoryId = Data.CategoryId;
                    ThirdCategories.ThirdCategory = Data.ThirdCategory;
                    ThirdCategories.ThirdCategoryId = Data.ThirdCategoryId;
                }
            }
        }
        public async Task<IActionResult> OnPostCreate() {

            if (ModelState.IsValid)
            {
                var responseData = await db.AddThirdCategory(new ThirdCategoryTbl() { 
                
                    SubCategoryId = ThirdCategories.SubCategoryId,
                    CategoryId = ThirdCategories.CategoryId,
                    ThirdCategory = ThirdCategories.ThirdCategory,
                    Status = true,
                    EntryDate = DateTime.Now,
                });

                return RedirectToPage("ThirdCategoryForm", new { Message = responseData });
            }
            return Page();
        }
        public async Task<IActionResult>OnPostUpdate()
        {
            var responseData = await db.UpdateThirdCategory(ThirdCategories.ThirdCategoryId, new ThirdCategoryTbl() {

                SubCategoryId = ThirdCategories.SubCategoryId,
                CategoryId = ThirdCategories.CategoryId,
                ThirdCategory = ThirdCategories.ThirdCategory,
                EntryDate = DateTime.Now
            });
            return RedirectToPage("ThirdCategoryForm", new { Message = responseData });
        }

    }
}
