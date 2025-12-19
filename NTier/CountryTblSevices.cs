using Ecommerce.Entity;
using Ecommerce.Entity.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.NTier
{
    public interface ICountryTblSevices
    {
        Task<string> AddCountry(CountryTbl Model);
        Task<string> UpdateCounty(int CountryId, CountryTbl Model);
        Task<string> DeleteCounrty(int CountryId);
        Task<CountryTbl> GetByCountryId(int CountryId);
        Task<List<CountryTbl>> GetByCountryList();
    

    }
    public class CountryTblSevices : ICountryTblSevices, IDisposable
    {
        private readonly EntityDbContext db;

        public CountryTblSevices(EntityDbContext db)
        {
            this.db = db;
        }
        public async Task<string> AddCountry(CountryTbl Model)
        {
            try
            {
                if (Model == null)
                {
                    return "Model Is Null";
                }

                var Data = await db.CountryTbls.Where(m => m.CountryName == Model.CountryName).FirstOrDefaultAsync();
                if (Data != null)
                {
                    return "Country Name Is All Ready Exist";
                }

                await db.CountryTbls.AddAsync(Model);
                int row = await db.SaveChangesAsync();

                if (row > 0)
                {
                    return "SuccessFully Store Country Data";
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

        public async Task<string> DeleteCounrty(int CountryId)
        {
            try
            {
                if (CountryId == 0)
                {
                    return "Model Is Null";
                }

                var Data = await db.CountryTbls.FindAsync(CountryId);
                if (Data == null)
                {
                    return "There Is No Data in Given Id";
                }
                db.CountryTbls.Remove(Data);
                int row = await db.SaveChangesAsync();

                if (row > 0)
                {
                    return "SuccessFully Delete Country Data";
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

        public async Task<CountryTbl> GetByCountryId(int CountryId)
        {
            var Data = await db.CountryTbls.FindAsync(CountryId);
            if (Data == null)
            {
                return new CountryTbl();
            }
            return Data;
        }

        public async Task<List<CountryTbl>> GetByCountryList()
        {
            var Data = await db.CountryTbls.ToListAsync();
            if (Data == null)
            {
                return new List<CountryTbl>();
            }
            return Data;
        }

        public async Task<string> UpdateCounty(int CountryId, CountryTbl Model)
        {
            try
            {
                if (CountryId == 0)
                {
                    return "Model Is Null";
                }
                if (Model == null)
                {
                    return "Model Is Null";
                }
                var Data = await db.CountryTbls.FindAsync(CountryId);
                if (Data == null)
                {
                    return "There Is No Data in Given Id";
                }
                Data.CountryName = Model.CountryName;
                int row = await db.SaveChangesAsync();

                if (row > 0)
                {
                    return "SuccessFully Update Country Data";
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


        public void Dispose()
        {
            db.Dispose();
        }

    }
}
