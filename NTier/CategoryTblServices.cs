using Ecommerce.Entity;
using Ecommerce.Entity.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace Ecommerce.NTier
{
    public interface ICategoryTblServices
    {
        Task<string> AddCategory(CategoryTbl Model);
        Task<string> UpdateCategory(int CatId, CategoryTbl Model);
        Task<string> DeleteCategory(int CatId);
        Task<CategoryTbl> GetByCategoryId(int CatId);
        Task<List<CategoryTbl>> GetByCategoryList();
  
    }
    public class CategoryTblServices : ICategoryTblServices, IDisposable
    {
        private readonly EntityDbContext db;
        public CategoryTblServices(EntityDbContext db)
        {
            this.db = db;
        }
        public async Task<string> AddCategory(CategoryTbl Model)
        {
            try
            {
                if (Model == null)
                {
                    return "Model is Null";
                }
                var Data =  await db.categoryTbls.Where(m => m.Category == Model.Category).FirstOrDefaultAsync();
                if (Data != null)
                {
                    return "Category Name is All Ready Exist";
                }
               await  db.categoryTbls.AddAsync(Model);
                int row = await db.SaveChangesAsync();
                if (row > 0)
                {
                    return "SuccessFullY Store Category Data";
                }
                else
                {
                    return "Something Wrong Database Data";
                }
            }
            catch (Exception Ex)
            {

                return Ex.ToString();
            }
        }

        public async Task<string> DeleteCategory(int CatId)
        {
            try
            {
                if (CatId == 0)
                {
                    return "CatId is Null";
                }
                var Data = await db.categoryTbls.FindAsync(CatId);
                if (Data == null)
                {
                    return "There Is No Data in Given Id";
                }

                db.categoryTbls.Remove(Data);
                int row = await db.SaveChangesAsync();
                if (row > 0)
                {
                    return "SuccessFullY Delete Category Data";
                }
                else
                {
                    return "Something Wrong Database Data";
                }
            }
            catch (Exception Ex)
            {

                return Ex.ToString();
            }
        }

       

        public async Task<CategoryTbl>  GetByCategoryId(int CatId)
        {
            var Data = await db.categoryTbls.FindAsync(CatId);

            if (Data == null)
            {
                return new CategoryTbl();
            }
            return Data;
        }

        public async Task<List<CategoryTbl>> GetByCategoryList()
        {
            var Data = await db.categoryTbls.ToListAsync();

            if (Data == null)
            {
                return new List<CategoryTbl>();
            }
            return Data;
        }

        public async Task<string> UpdateCategory(int CatId, CategoryTbl Model)
        {
            try
            {
                if (CatId == 0)
                {
                    return "CatId is Null";
                }
                if (Model == null)
                {
                    return "Model is Null";
                }
                var Data = await db.categoryTbls.FindAsync(CatId);
                if (Data == null)
                {
                    return "There Is No Data in Given Id";
                }

                Data.Category = Model.Category;
                Data.EntryDate = DateTime.Now;
                
                int row = await db.SaveChangesAsync();
                if (row > 0)
                {
                    return "SuccessFullY Update Category Data";
                }
                else
                {
                    return "Something Wrong Database Data";
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
