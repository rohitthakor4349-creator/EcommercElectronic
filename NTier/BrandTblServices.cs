using Ecommerce.Entity;
using Ecommerce.Entity.Model;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Ecommerce.NTier
{
    public interface IBrandTblServices
    {
        Task<string> AddBrand(BrandTbl Model);
        Task<string> UpdateBrand(BrandTbl Model,int BId);
        Task<string> DeleteBrand(int BId);
        Task<BrandTbl> GetBrandId(int BId);
        Task<List<BrandTbl>> GetByBrandList();
    }
    public class BrandTblServices : IBrandTblServices, IDisposable
    {
        private readonly EntityDbContext db;

        public BrandTblServices(EntityDbContext db)
        {
            this.db = db;   
        }
        public async Task<string> AddBrand(BrandTbl Model)
        {
            try
            {
                if (Model == null)
                {
                    return "Model Is Null";
                }

                var Data = await db.BrandTbls.Where(m => m.Brand == Model.Brand).FirstOrDefaultAsync();
                if (Data == null)
                {
                    return "Brand Name Is All Ready Exist";
                }
                await db.BrandTbls.AddAsync(Model);

                int row = await db.SaveChangesAsync();

                if (row > 0)
                {
                    return "SuccessFullY Store Brand Data";
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

        public async Task<string> DeleteBrand(int BId)
        {
            try
            {
                if (BId == 0)
                {
                    return "BrandId Is Null";
                }

                var Data = await db.BrandTbls.FindAsync(BId);
                if (Data == null)
                {
                    return "There Is No Data in Given Id";
                }
                db.BrandTbls.Remove(Data);
                int row = await db.SaveChangesAsync();

                if (row > 0)
                {
                    return "SuccessFullY Delete Brand Data";
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

     

        public async Task<BrandTbl> GetBrandId(int BId)
        {
            var Data = await db.BrandTbls.FindAsync(BId);

            if (Data == null)
            {
                return new BrandTbl();
            }
            return Data;
        }

        public async Task<List<BrandTbl>> GetByBrandList()
        {
            var Data = await db.BrandTbls.ToListAsync();

            if (Data == null)
            {
                return new List<BrandTbl>();

            }
            return Data;
        }

        public async Task<string> UpdateBrand(BrandTbl Model, int BId)
        {
            try
            {
                if (BId == 0)
                {
                    return "BrandId Is Null";
                }
                if (Model == null)
                {
                    return "Model Id Null";
                }
                var Data = await db.BrandTbls.FindAsync(BId);
                if (Data == null)
                {
                    return "There Is No Data in Given Id";
                }
                Data.Brand = Model.Brand;
                Data.EntryDate = System.DateTime.Now;
               
                int row = await db.SaveChangesAsync();

                if (row > 0)
                {
                    return "SuccessFullY Update Brand Data";
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
            throw new NotImplementedException();
        }
    }
}
