using Ecommerce.Entity;
using Ecommerce.Entity.Model;
using Ecommerce.NTier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;

namespace Ecommerce.Pages.Client
{
    public class ShopModel : PageModel
    {
        private readonly IProductTblServices db;
        private readonly EntityDbContext dbContext;

        public ShopModel(IProductTblServices db, EntityDbContext dbContext)
        {
            this.db = db;
            this.dbContext = dbContext;
        }

        public List<ProductTbl> ProductList { get; set; }
    
        public async Task FillProduct()
        {
            ProductList = await db.GetByProductList();
        }
        public async Task<IActionResult> OnGet(int CatId,int SubCatId,int ThirdCatId)
        {

            if (CatId > 0)
            {
               ProductList  = await db.MenuCatgory(CatId);
            }
            else if (SubCatId > 0)
            {
               ProductList  = await db.MenuSubCatgory(SubCatId);

            }
            else if (ThirdCatId > 0)
            {
                ProductList = await db.MenuThirdCatgory(ThirdCatId);

            }
            else
            {
                await FillProduct();

            }

            return Page();
        }
    }
}
