using Ecommerce.Entity;
using Ecommerce.Entity.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.NTier
{
    public interface IThirdCategoryTblServices
    {
        Task<string> AddThirdCategory(ThirdCategoryTbl Model);
        Task<string> UpdateThirdCategory(ThirdCategoryTbl Model, int ThirdCatId);
        Task<string> DeleteThirdCategory(int ThirdCatId);
        Task<ThirdCategoryTbl> GetByThirdCategoryId(int ThirdCatId);
        Task<List<ThirdCategoryTbl>> GetByThirdCategoryList();
        Task<List<SelectListItem>> DropCategory();
        Task<List<SelectListItem>> DropSubCategory(int CategoryId);
    }
    public class ThirdCategoryTblServices : IThirdCategoryTblServices, IDisposable
    {
        private readonly EntityDbContext db;

        public ThirdCategoryTblServices(EntityDbContext db)
        {
            this.db = db;
        }
        public async Task<string> AddThirdCategory(ThirdCategoryTbl Model)
        {
            try
            {
                if (Model == null)
                {
                    return "Model IS null";
                }

                var Data = await db.ThirdCategoryTbls.Where(m => m.ThirdCategory == Model.ThirdCategory).FirstOrDefaultAsync();
                if (Data != null)
                {
                    return "ThirdCategory Name Is All Ready Exist";
                }
               await  db.ThirdCategoryTbls.AddAsync(Model);

                int row = await db.SaveChangesAsync();
                if (row > 0)
                {
                    return "SuccessFully Store ThirdCategory Data";
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

        public async Task<string> DeleteThirdCategory(int ThirdCatId)
        {
            try
            {
                if (ThirdCatId == 0)
                {
                    return "ThirdCatId IS null";
                }

                var Data = await db.ThirdCategoryTbls.FindAsync(ThirdCatId);
                if (Data == null)
                {
                    return "There Is No Data in Given Id";
                }
                 db.ThirdCategoryTbls.Remove(Data);

                int row = await db.SaveChangesAsync();
                if (row > 0)
                {
                    return "SuccessFully Delete ThirdCategory Data";
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

       
        public async Task<ThirdCategoryTbl> GetByThirdCategoryId(int ThirdCatId)
        {
            var Data = await db.ThirdCategoryTbls.FindAsync(ThirdCatId);
            if (Data == null)
            {
                return new ThirdCategoryTbl();
            }
            return Data;
        }

        public async Task<List<ThirdCategoryTbl>> GetByThirdCategoryList()
        {
            var Data = await db.ThirdCategoryTbls.ToListAsync();

            if (Data == null)
            {
                return new List<ThirdCategoryTbl>();

            }
            return Data;
        }

        public async Task<string> UpdateThirdCategory(ThirdCategoryTbl Model, int ThirdCatId)
        {
            try
            {
                if (ThirdCatId == 0)
                {
                    return "ThirdCatId IS null";
                }
                if (Model == null)
                {
                    return "Model Is Null";
                }

                var Data = await db.ThirdCategoryTbls.FindAsync(ThirdCatId);
                if (Data == null)
                {
                    return "There Is No Data in Given Id";
                }
                 Data.CategoryId = Model.CategoryId;
                Data.SubCategoryId = Model.SubCategoryId;
                Data.ThirdCategory = Model.ThirdCategory;
                Data.EntryDate = System.DateTime.Now;

                int row = await db.SaveChangesAsync();
                if (row > 0)
                {
                    return "SuccessFully Update ThirdCategory Data";
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

        public async Task<List<SelectListItem>> DropCategory()
        {
            var Data = await db.categoryTbls.ToListAsync();

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in Data)
            {
                List.Add(new SelectListItem() { Value = item.CategoryId.ToString(), Text = item.Category });
            }
            return List;
        }

       

        public async Task<List<SelectListItem>> DropSubCategory(int CategoryId)
        {
            var Data = await db.SubCategoryTbls.Where(m => m.CategoryId == CategoryId).ToListAsync();
            List<SelectListItem> List = new List<SelectListItem>();
            foreach (var item in Data)
            {
                List.Add(new SelectListItem() { Value = item.SubCategoryId.ToString(), Text = item.SubCategory });
            }
            return List;
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
