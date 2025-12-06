using Ecommerce.Entity.Model;
using Ecommerce.Model;
using Ecommerce.NTier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce.Pages.Admin
{
    public class CategoryFormModel : PageModel
    {
        private readonly ICategoryTblServices db;

        public CategoryFormModel(ICategoryTblServices db)
        {
            this.db = db;
        }

        [BindProperty]
        public CategoryTbl Categeries { get; set; }

      
        public string Message { get; set; }

       
        public async Task<IActionResult> OnGet(int EditId)
        {

            if (EditId > 0)
            {
                var responseData = await db.GetByCategoryId(EditId);
                if (responseData != null)
                {
                    Categeries = new CategoryTbl();
                    Categeries.Category = responseData.Category;
                    Categeries.CategoryId = responseData.CategoryId;

                }
            }
            return Page();

        }



        public async Task<IActionResult> OnPostCreate()
        {
            if (ModelState.IsValid)
            {
                var responseData = await db.AddCategory(new CategoryTbl()
                {

                    Category = Categeries.Category,
                    Status = true,
                    EntryDate = System.DateTime.Now
                });
                if (!string.IsNullOrEmpty(responseData))
                {
                    Message = responseData; 
                }
                return RedirectToAction("CategoryForm", new { Message = responseData });

            }
            return Page();

        }

        public async Task<IActionResult> OnPostUpdate()
        {

            var responseData = await db.UpdateCategory(Categeries.CategoryId,new CategoryTbl() { 
            
                Category = Categeries.Category,
                EntryDate = System.DateTime.Now
            });
            if (!string.IsNullOrEmpty(responseData))
            {
                Message = (string)responseData;
            }
            return RedirectToAction("CategoryForm", new { Message = responseData });
          
        }
      

    }
}
