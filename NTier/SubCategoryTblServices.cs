using Ecommerce.Entity;
using Ecommerce.Entity.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.NTier
{

    public interface ISubCategoryTblServices
    {
        Task<string> AddSubCategory(SubCategoryTbl Model);
        Task<string> UpdateSubCategory(int SubCatId, SubCategoryTbl Model);
        Task<string> DeleteSubCategory(int SubCatId);
        Task<SubCategoryTbl> GetBySubCategoryId(int SubCatId);
        Task<List<SubCategoryTbl>> GetBySubCategoryList();
        Task<List<SelectListItem>> DropCategory();
    }
    public class SubCategoryTblServices : ISubCategoryTblServices, IDisposable
    {
        private readonly EntityDbContext db;

        public SubCategoryTblServices(EntityDbContext db)
        {
            this.db = db;
        }
        public async Task<string> AddSubCategory(SubCategoryTbl Model)
        {
            try
            {
                if (Model == null)
                {
                    return "Model is Null";
                }
                var Data = await db.SubCategoryTbls.Where(m => m.SubCategory == Model.SubCategory).FirstOrDefaultAsync();
                if (Data != null)
                {
                    return "SubCategory Is All Ready Exist";
                }
                await db.SubCategoryTbls.AddAsync(Model);
                int row = await db.SaveChangesAsync();
                if (row > 0)
                {
                    return "SuccessFully Store SubCategory Data";
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

        public async Task<string> DeleteSubCategory(int SubCatId)
        {
            try
            {
                if (SubCatId == 0)
                {
                    return "SuncatId is Null";
                }
                var Data = await db.SubCategoryTbls.FindAsync(SubCatId);
                if (Data == null)
                {
                    return "There Is No Data in Given Id";
                }
                db.SubCategoryTbls.Remove(Data);
                int row = await db.SaveChangesAsync();
                if (row > 0)
                {
                    return "SuccessFully Delete SubCategory Data";
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



        public async Task<SubCategoryTbl> GetBySubCategoryId(int SubCatId)
        {
            var Data = await db.SubCategoryTbls.FindAsync(SubCatId);
            if (Data == null)
            {
                return new SubCategoryTbl();
            }
            return Data;
        }

        public async Task<List<SubCategoryTbl>> GetBySubCategoryList()
        {
            var Data = await db.SubCategoryTbls.ToListAsync();
            if (Data == null)
            {
                return new List<SubCategoryTbl>();
            }
            return Data;
        }

        public async Task<string> UpdateSubCategory(int SubCatId, SubCategoryTbl Model)
        {
            try
            {
                if (SubCatId == 0)
                {
                    return "SuncatId is Null";
                }
                if (Model == null)
                {
                    return "Model IOs Null";
                }
                var Data = await db.SubCategoryTbls.FindAsync(SubCatId);
                if (Data == null)
                {
                    return "There Is No Data in Given Id";
                }
                Data.CategoryId = Model.CategoryId;
                Data.SubCategory = Model.SubCategory;
                Data.EntryDate = System.DateTime.Now;
               
                int row = await db.SaveChangesAsync();
                if (row > 0)
                {
                    return "SuccessFully Update SubCategory Data";
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
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
