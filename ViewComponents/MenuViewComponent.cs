using Ecommerce.Entity.Model;
using Ecommerce.NTier;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.ViewComponents
{
    
    public class MenuViewComponent : ViewComponent
    {
        private readonly IMenuServices db;

        public MenuViewComponent(IMenuServices db)
        {
            this.db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var menu = await db.GetMenu();
            return View(menu);
        }
    }
}
