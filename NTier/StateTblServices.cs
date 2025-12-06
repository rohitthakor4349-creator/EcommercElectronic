using Ecommerce.Entity;
using Ecommerce.Entity.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Ecommerce.NTier
{
    public interface IStateTblServices
    {
        Task<string> AddState(StateTbl Model);
        Task<string> UpdateState(StateTbl Model, int StateId);
        Task<string> DeleteState(int StateId);
        Task<StateTbl> GetByState(int StateId);
        Task<List<StateTbl>> GetByStateList();
        Task<List<SelectListItem>> DropCountry();
    }
    public class StateTblServices : IStateTblServices, IDisposable
    {
        private readonly EntityDbContext db;

        public StateTblServices(EntityDbContext db)
        {
            this.db = db;
        }
        public async Task<string> AddState(StateTbl Model)
        {
            try
            {
                if (Model == null)
                {
                    return "Model Is Null";
                }

                var Data = await db.StateTbls.Where(m => m.StateName == Model.StateName).FirstOrDefaultAsync();
                if (Data != null)
                {
                    return "State Name Is All Ready Exist";
                }

                await db.StateTbls.AddAsync(Model);
                int row = await db.SaveChangesAsync();

                if (row > 0)
                {
                    return "SuccessFully Store StateId Data";
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

        public async Task<string> DeleteState(int StateId)
        {
            try
            {
                if (StateId == 0)
                {
                    return "Model Is Null";
                }

                var Data = await db.StateTbls.FindAsync(StateId);
                if (Data == null)
                {
                    return "There Is No Data in Given Id";
                }
                db.StateTbls.Remove(Data);
                int row = await db.SaveChangesAsync();

                if (row > 0)
                {
                    return "SuccessFully Delete State Data";
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



        public async Task<StateTbl> GetByState(int StateId)
        {
            var Data = await db.StateTbls.FindAsync(StateId);
            if (Data == null)
            {
                return new StateTbl(); 
            }
            return Data;
        }

        public async Task<List<StateTbl>> GetByStateList()
        {
            var Data = await db.StateTbls.ToListAsync();
            if (Data == null)
            {
                return new List<StateTbl>();
            }
            return Data;
        }

        public async Task<string> UpdateState(StateTbl Model, int StateId)
        {

            try
            {
                if (StateId == 0)
                {
                    return "Model Is Null";
                }
                if (Model == null)
                {
                    return "Model Is Null";
                }
                var Data = await db.StateTbls.FindAsync(StateId);
                if (Data == null)
                {
                    return "There Is No Data in Given Id";
                }
                Data.CountryId = Model.CountryId;
                Data.StateName = Model.StateName;

         
                int row = await db.SaveChangesAsync();

                if (row > 0)
                {
                    return "SuccessFully Update State Data";
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
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
