using Ecommerce.Entity.Model;
using Ecommerce.Model;
using Ecommerce.NTier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Ecommerce.Pages.Client
{
    public class ProductDetailModel : PageModel
    {
        private readonly IProductTblServices db;

        public ProductDetailModel(IProductTblServices db)
        {
            this.db = db;
        }

        [BindProperty]
        public ProductDTO Product { get; set; }

        public async Task OnGet(int ProductId)
        {
            if (ProductId > 0)
            {
                Product = await db.ProductDetaile(ProductId);
            }
        }
    }
}
