using Ecommerce.Entity;
using Ecommerce.Entity.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.NTier
{
    public interface ICityTblServices
    {
        Task<string> AddCountry(CityTbl Model);
        Task<string> UpdateCounty(CityTbl Model, int CityId);
        Task<string> DeleteCounrty(int CityId);
        Task<CityTbl> GetByCountryId(int CityId);
        Task<List<CityTbl>> GetByCountryList();
        Task<List<SelectListItem>> DropCountry();
        Task<List<SelectListItem>> DropState(int CountryId);
    }
    public class CityTblServices : ICityTblServices, IDisposable
    {
        private readonly EntityDbContext db;

        public CityTblServices(EntityDbContext db)
        {
            this.db = db;
        }
        public async Task<string> AddCountry(CityTbl Model)
        {
            try
            {
                if (Model == null)
                {
                    return "Model Is Null";
                }

                var Data = await db.CityTbls.Where(m => m.CityName == Model.CityName).FirstOrDefaultAsync();
                if (Data != null)
                {
                    return "City Name Is All Ready Exist";
                }

                await db.CityTbls.AddAsync(Model);
                int row = await db.SaveChangesAsync();

                if (row > 0)
                {
                    return "SuccessFully Store City Data";
                }
                else
                {
                    return "Something Wrong Data";
                }
            }
            catch (Exception Ex)
            {

                return Ex.ToString();
            }
        }

        public async Task<string> DeleteCounrty(int CityId)
        {
            try
            {
                if (CityId == 0)
                {
                    return "Model Is Null";
                }

                var Data = await db.CityTbls.FindAsync(CityId);
                if (Data == null)
                {
                    return "There Is No Data in Given Id";
                }
                db.CityTbls.Remove(Data);
                int row = await db.SaveChangesAsync();

                if (row > 0)
                {
                    return "SuccessFully Delete City Data";
                }
                else
                {
                    return "Something Wrong Data";
                }
            }
            catch (Exception Ex)
            {

                return Ex.ToString();
            }
        }

       

        public async Task<CityTbl> GetByCountryId(int CityId)
        {
            var Data = await db.CityTbls.FindAsync(CityId);

            if (Data == null)
            {
                return new CityTbl();
            }
            return Data;
        }

        public async Task<List<CityTbl>> GetByCountryList()
        {
            var Data = await db.CityTbls.ToListAsync();

            if (Data == null)
            {
                return new List<CityTbl>();
            }
            return Data;
        }

        public async Task<string> UpdateCounty(CityTbl Model, int CityId)
        {
            try
            {
                if (CityId == 0)
                {
                    return "Model Is Null";
                }
                if (Model == null)
                {
                    return "Model Is Null";
                }
                var Data = await db.CityTbls.FindAsync(CityId);
                if (Data == null)
                {
                    return "There Is No Data in Given Id";
                }
                
                Data.CounrtyId = Model.CounrtyId;
                Data.StateId = Model.StateId;
                Data.CityName = Model.CityName;
                int row = await db.SaveChangesAsync();

                if (row > 0)
                {
                    return "SuccessFully Update City Data";
                }
                else
                {
                    return "Something Wrong Data";
                }
            }
            catch (Exception Ex)
            {

                return Ex.ToString();
            }
        }

        public async Task<List<SelectListItem>> DropCountry()
        {
            var Data = await db.CountryTbls.ToListAsync();

            List<SelectListItem> List = new List<SelectListItem>();
            foreach (var item in Data)
            {
                List.Add(new SelectListItem() { Value = item.CountryId.ToString(), Text = item.CountryName });

            }
            return List;
        }
     
    

        public async Task<List<SelectListItem>> DropState(int CountryId)
        {
            var Data = await db.StateTbls.Where(m => m.CountryId == CountryId).ToListAsync();

            List<SelectListItem> List = new List<SelectListItem>();
            foreach (var item in Data)
            {
                List.Add(new SelectListItem() { Value = item.StateId.ToString(), Text = item.StateName });
            }
            return List;
        }
        public void Dispose()
        {
            db.Dispose();
        }

    }
}
