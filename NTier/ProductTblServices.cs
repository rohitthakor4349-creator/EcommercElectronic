using Ecommerce.Entity;
using Ecommerce.Entity.Model;
using Ecommerce.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.NTier
{
    public interface IProductTblServices
    {
        Task<string> AddProduct(ProductTbl Model);
        Task<string> UpdateProduct(int PId, ProductTbl Model);
        Task<string> DeleteProduct(int PId);
        Task<ProductTbl> GetByProductId(int PId);
        Task<List<ProductTbl>> GetByProductList();
        Task<List<SelectListItem>> DropCategory();
        Task<List<SelectListItem>> DropSubCategory(int CategoryId);
        Task<List<SelectListItem>> DropThirdCategory(int SubCategoryId);
        Task<List<SelectListItem>> DropBrand();
        Task<List<ProductTbl>> MenuCatgory(int CatId);
        Task<List<ProductTbl>> MenuSubCatgory(int SubCatId);
        Task<List<ProductTbl>> MenuThirdCatgory(int ThirdCatId);
        Task<ProductDTO> ProductDetaile(int PId);

    }
    public class ProductTblServices : IProductTblServices, IDisposable
    {
        private readonly EntityDbContext db;

        public ProductTblServices(EntityDbContext db)
        {
            this.db = db;
        }
        public async Task<string> AddProduct(ProductTbl Model)
        {
            try
            {
                if (Model == null)
                {
                    return "Model Id Null";
                }

                var data = await db.ProductTbls.Where(m => m.ProductName == Model.ProductName).FirstOrDefaultAsync();
                if (data != null)
                {
                    return "ProductName Is All Ready Exist";
                }

                await db.ProductTbls.AddAsync(Model);
                int row = await db.SaveChangesAsync();
                if (row > 0)
                {
                    return "SuccessFully Store Product";
                }
                else
                {
                    return "Something Wrong data";
                }
            }
            catch (Exception Ex)
            {

                return Ex.ToString();
            }
        }

        public async Task<string> DeleteProduct(int PId)
        {
            try
            {
                if (PId == 0)
                {
                    return "PId Id Null";
                }

                var Data = await db.ProductTbls.FindAsync(PId);
                if (Data == null)
                {
                    return "There Is No Data in Given Id";

                }
                db.ProductTbls.Remove(Data);
                int row = await db.SaveChangesAsync();
                if (row > 0)
                {
                    return "SuccessFully Delete Product Data";
                }
                else
                {
                    return "Something Wrong data";
                }
            }
            catch (Exception Ex)
            {

                return Ex.ToString();
            }
        }



        public async Task<ProductTbl> GetByProductId(int PId)
        {
            var Data = await db.ProductTbls.FindAsync(PId);

            if (Data == null)
            {
                return new ProductTbl();
            }
            return Data;
        }

        public async Task<List<ProductTbl>> GetByProductList()
        {
            var Data = await db.ProductTbls.ToListAsync();

            if (Data == null)
            {
                return new List<ProductTbl>();
            }
            return Data;
        }

        public async Task<string> UpdateProduct(int PId, ProductTbl Model)
        {
            try
            {
                if (PId == 0)
                {
                    return "PId Id Null";
                }
                if (Model == null)
                {
                    return "Model Is Null";
                }
                var Data = await db.ProductTbls.FindAsync(PId);
                if (Data == null)
                {
                    return "There Is No Data in Given Id";

                }

                Data.CategoryId = Model.CategoryId;
                Data.SubCategoryId = Model.SubCategoryId;
                Data.ThirdCategoryId = Model.ThirdCategoryId;
                Data.BrandId = Model.BrandId;
                Data.ProductName = Model.ProductName;
                Data.ProductPrice = Model.ProductPrice;
                Data.Photo = Model.Photo;
                Data.Description = Model.Description;
                Data.EntryDate = System.DateTime.Now;

                int row = await db.SaveChangesAsync();
                if (row > 0)
                {
                    return "SuccessFully Update Product Data";
                }
                else
                {
                    return "Something Wrong data";
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

        public async Task<List<SelectListItem>> DropThirdCategory(int SubCategoryId)
        {
            var Data = await db.ThirdCategoryTbls.Where(m => m.SubCategoryId == SubCategoryId).ToListAsync();

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in Data)
            {
                List.Add(new SelectListItem() { Value = item.ThirdCategoryId.ToString(), Text = item.ThirdCategory });

            }
            return List;

        }

        public async Task<List<SelectListItem>> DropBrand()
        {
            var Data = await db.BrandTbls.ToListAsync();

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in Data)
            {
                List.Add(new SelectListItem() { Value = item.BrandId.ToString(), Text = item.Brand });
            }
            return List;
        }

        public async Task<List<ProductTbl>> MenuCatgory(int CatId)
        {

            var Data = await db.ProductTbls.Where(m => m.CategoryId == CatId).ToListAsync();
            if (Data == null)
            {
                Data = new List<ProductTbl>();
            }

            return Data;


        }

        public async Task<List<ProductTbl>> MenuSubCatgory(int SubCatId)
        {
            var Data = await db.ProductTbls.Where(m => m.SubCategoryId == SubCatId).ToListAsync();

            if (Data == null)
            {
                Data = new List<ProductTbl>();
            }
            return Data;
        }

        public async Task<List<ProductTbl>> MenuThirdCatgory(int ThirdCatId)
        {
            var Data = await db.ProductTbls.Where(m => m.ThirdCategoryId == ThirdCatId).ToListAsync();

            if (Data == null)
            {
                Data = new List<ProductTbl>();
            }

            return Data;
        }

        public async Task<ProductDTO> ProductDetaile(int PId)
        {
            var Data = await (from p in db.ProductTbls

                              join cat in db.categoryTbls
                              on p.CategoryId equals cat.CategoryId
                              join SubC in db.SubCategoryTbls
                              on p.SubCategoryId equals SubC.SubCategoryId
                              join ThirdC in db.ThirdCategoryTbls
                              on p.ThirdCategoryId equals ThirdC.ThirdCategoryId
                              join b in db.BrandTbls
                              on p.BrandId equals b.BrandId
                              where p.ProductId == PId
                              select new ProductDTO()
                              {
                                  ProductName = p.ProductName,
                                  ProductId = p.ProductId,
                                  ProductPrice = p.ProductPrice,
                                  CategoryName = p.CategoryId.ToString(),
                                  SubCategoryName = p.SubCategoryId.ToString(),
                                  ThirdCategoryName = p.ThirdCategoryId.ToString(),
                                  BrandName = p.BrandId.ToString(),
                                  Photo = p.Photo,
                                  Description = p.Description,
                              }).FirstOrDefaultAsync();

           
            return Data;
           
        }
    }
}
