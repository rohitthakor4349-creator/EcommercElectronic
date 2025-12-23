using Ecommerce.Entity.Model;
using Ecommerce.NTier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Ecommerce.Pages.Admin
{
    public class StateListModel : PageModel
    {
        private readonly IStateTblServices db;

        public StateListModel(IStateTblServices db)
        {
            this.db = db;
        }

        public List<StateTbl> StateList { get; set; }

        public async Task FillState()
        {
            StateList = await db.GetByStateList();
        }
        public async Task OnGet()
        {
            await FillState();
        }

        public async Task<IActionResult>OnPostDelete(int DeleteId)
        {
            if (DeleteId > 0)
            {
                var Msg = await db.DeleteState(DeleteId);

                if (Msg != null)
                {
                    return RedirectToPage("StateList", new { Message = Msg });
                }
                await FillState();
            }
            return Page();
        }
    }
}
