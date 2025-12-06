using Ecommerce.Entity;
using Ecommerce.Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.NTier
{
    public interface ICartTblServices
    {
        Task<string> AddCart(CartTbl Model);
        Task<string> UpdateCart(CartTbl Model, int CartId);
        Task<string> DeleteCart(int CartId);
        Task<CartTbl> GetByCartId(int CartId);
        Task<List<CartTbl>> GetByCartList();
    }
    public class CartTblServices : ICartTblServices, IDisposable
    {
        private readonly EntityDbContext db;

        public CartTblServices(EntityDbContext db)
        {
            this.db = db;
        }
        public async Task<string> AddCart(CartTbl Model)
        {
            try
            {
                if (Model == null)
                {
                    return "Model Is Null";
                }
              await db.CartTbls.AddAsync(Model);
                int row = await db.SaveChangesAsync();
                if (row > 0)
                {
                    return "SuccessFully Store Cart Data";
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

        public async Task<string> DeleteCart(int CartId)
        {
            try
            {
                if (CartId == 0)
                {
                    return "CartId Is Null";
                }
                var Data = await db.CartTbls.FindAsync(CartId);
                if (Data == null)
                {
                    return "There Is No Data in Given Id";
                }
                db.CartTbls.Remove(Data);
                int row = await db.SaveChangesAsync();
                if (row > 0)
                {
                    return "SuccessFully Delete Cart Data";
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

        public async Task<CartTbl> GetByCartId(int CartId)
        {
            var Data = await db.CartTbls.FindAsync(CartId);

            if (Data != null)
            {
                return new CartTbl();
            }
            return Data;
        }

        public async Task<List<CartTbl>> GetByCartList()
        {
            var Data = await db.CartTbls.ToListAsync();

            if (Data !=  null)
            {
                return new List<CartTbl>();
            }
            return Data;
        }

        public async Task<string> UpdateCart(CartTbl Model, int CartId)
        {
            try
            {
                if (CartId == 0)
                {
                    return "CartId Is Null";
                }
                if (Model == null)
                {
                    return "Model Is Null";
                }
                var Data = await db.CartTbls.FindAsync(CartId);
                if (Data == null)
                {
                    return "There Is No Data in Given Id";
                }
                Data.Qty = Model.Qty;

               
                int row = await db.SaveChangesAsync();
                if (row > 0)
                {
                    return "SuccessFully Update Cart Data";
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
    }
}
