
using Ecommerce.Entity.Model;
using Ecommerce.Model;
using Ecommerce.NTier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Ecommerce.Pages.Admin
{

    public class BrandFormModel : PageModel
    {
        private readonly IBrandTblServices db;

        public BrandFormModel(IBrandTblServices db)
        {
            this.db = db;
        }
        [BindProperty]
        public BrandDTO Brands { get; set; }
        public async Task<IActionResult> OnGet(int EditId)
        {
            if (EditId > 0)
            {
                var Data = await db.GetBrandId(EditId);
                if (Data != null)
                {
                    Brands = new BrandDTO();
                    Brands.Brand = Data.Brand;
                    Brands.BrandId = Data.BrandId;
                }
            }
            return Page();
        }
        public async Task<IActionResult> OnPostCreate()
        {
            if (ModelState.IsValid)
            {
                var Data = await db.AddBrand(new BrandTbl()
                {

                    Brand = Brands.Brand,
                    Status = true,
                    EntryDate = DateTime.Now,


                });
                return RedirectToPage("BrandForm", new { Message = Data });
            }
            return Page();
        }
        public async Task<IActionResult> OnPostUpdate()
        {
            var Data = await db.UpdateBrand(Brands.BrandId, new BrandTbl()
            {

                Brand = Brands.Brand,
                EntryDate = DateTime.Now

            });
            return RedirectToPage("BrandList", new { Message = Data });
        }
    }
}
