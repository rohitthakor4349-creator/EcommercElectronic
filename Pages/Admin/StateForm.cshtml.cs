using Ecommerce.Entity.Model;
using Ecommerce.Model;
using Ecommerce.NTier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Ecommerce.Pages.Admin
{
    public class StateFormModel : PageModel
    {
        private readonly IStateTblServices db;

        public StateFormModel(IStateTblServices db)
        {
            this.db = db;
        }

        [BindProperty]
        public StateDTO States { get; set; }

       
        public List<SelectListItem> CountryList { get; set; }

        public async Task FillCountry()
        {
            CountryList = await db.DropCountry();
        }
        public async Task<IActionResult> OnGet(int EditId)
        {
            await FillCountry();
            if (EditId > 0)
            {
                var Data = await db.GetByState(EditId);

                if (Data != null)
                {
                    States = new StateDTO();
                    States.StateName = Data.StateName;
                    States.CountryId = Data.CountryId;
                    States.StateId = Data.StateId;
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPostCreate()
        {
            if (ModelState.IsValid)
            {
                var Msg = await db.AddState(new StateTbl() {
                
                    StateName = States.StateName,
                    CountryId = States.CountryId,
                    Status = true
                });
                return RedirectToPage("StateForm", new {Message = Msg });
            }
            return Page();
        }

        public async Task<IActionResult> OnPostUpdate()
        {
            var Msg = await db.UpdateState(States.StateId, new StateTbl() {

                StateName = States.StateName,
                CountryId = States.CountryId,
                Status = true
            });
            return RedirectToPage("StateForm", new { Message = Msg});
        }
    }
}
