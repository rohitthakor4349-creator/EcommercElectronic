using Ecommerce.Entity;
using Ecommerce.ViewModel.Menu;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.NTier
{
    public interface IMenuServices
    {
        Task<List<CategoryMenuVM>> GetMenu();
    }
    public class MenuServices : IMenuServices, IDisposable
    {
        private readonly EntityDbContext db;

        public MenuServices(EntityDbContext db)
        {
            this.db = db;
        }

        public async Task<List<CategoryMenuVM>> GetMenu()
        {
            var data = await db.categoryTbls
              .Select(c => new CategoryMenuVM
              {
                  CategoryId = c.CategoryId,
                  Category = c.Category,

                  SubCategories = db.SubCategoryTbls
                      .Where(sc => sc.CategoryId == c.CategoryId)
                      .Select(sc => new SubCategoryMenuVM
                      {
                          SubCategoryId = sc.SubCategoryId,
                          SubCategory = sc.SubCategory,

                          ThirdCategories = db.ThirdCategoryTbls
                              .Where(tc => tc.SubCategoryId == sc.SubCategoryId)
                              .Select(tc => new ThirdCategoryMenuVM
                              {
                                  ThirdCategoryId = tc.ThirdCategoryId,
                                  ThirdCategory = tc.ThirdCategory
                              }).ToList()
                      }).ToList()
              }).ToListAsync();

            return data;

        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
