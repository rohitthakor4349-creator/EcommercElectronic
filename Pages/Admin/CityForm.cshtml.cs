using Ecommerce.Entity.Model;
using Ecommerce.Model;
using Ecommerce.NTier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Ecommerce.Pages.Admin
{
    public class CityFormModel : PageModel
    {
        private readonly ICityTblServices db;
        public CityFormModel(ICityTblServices db)
        {
            this.db = db;
        }

        [BindProperty]
        public CityDTO Cities { get; set; }

        public List<SelectListItem> CountryList { get; set; }
        public List<SelectListItem> StateList { get; set; }

        public async Task FillCountry()
        {
            CountryList = await db.DropCountry();
        }
        public async Task<IActionResult> OnGet(int EditId)
        {
            await FillCountry();
            if (EditId > 0)
            {
                var Data = await db.GetByCityId(EditId);
                if (Data.CountryId != null)
                {
                    StateList = await db.DropState(Data.CountryId);
                }
                else
                {
                    StateList = new List<SelectListItem>();
                }

                if (Data != null)
                {
                    Cities = new CityDTO();
                    Cities.CounrtyId = Data.CountryId;
                    Cities.StateId = Data.StateId;
                    Cities.CityName = Data.CityName;
                    Cities.CityId = Data.CityId;
                }
             
            }
            return Page();
        }

        public async Task<IActionResult> OnPostCreate() {

            if (ModelState.IsValid)
            {
                var Msg = await db.AddCity(new CityTbl() {

                    CountryId = Cities.CounrtyId,
                    StateId = Cities.StateId,
                    
                    CityName = Cities.CityName,
                    Status = true
                });
                return RedirectToPage("CityForm", new { Message = Msg});
            }
            return Page();
        }

        public async Task<IActionResult>OnPostUpdate()
        {
            var Msg = await db.UpdateCity(Cities.CityId, new CityTbl() {

                CountryId = Cities.CounrtyId,
                StateId = Cities.StateId,

                CityName = Cities.CityName,
                Status = true

            });
            return RedirectToPage("CityForm", new { Message = Msg });

        }
    }
}
