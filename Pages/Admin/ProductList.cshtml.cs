using Ecommerce.Entity.Model;
using Ecommerce.NTier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Ecommerce.Pages.Admin
{
    public class ProductListModel : PageModel
    {
        private readonly IProductTblServices db;

        public List<ProductTbl> ProductList { get; set; }
        public ProductListModel(IProductTblServices db)
        {
            this.db = db;
        }

        public async Task FillProduct()
        {
            ProductList = await db.GetByProductList();
        }
        public async Task OnGet()
        {
            await FillProduct();
        }

        public async Task<IActionResult>OnPostDelete(int DeleteId)
        {
            if (DeleteId > 0)
            {
                var Data = await db.DeleteProduct(DeleteId);

                if (Data != null)
                {
                    return RedirectToPage("ProductList", new { Message = Data });
                }
            }
            await FillProduct();
            return Page();
        }
    }
}
