using Ecommerce.Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Entity
{
    public class EntityDbContext : DbContext
    {
        public EntityDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<CategoryTbl> categoryTbls { get; set; }
        public DbSet<SubCategoryTbl>SubCategoryTbls { get; set; }
        public DbSet<ThirdCategoryTbl>ThirdCategoryTbls { get; set; }
        public DbSet<BrandTbl>BrandTbls { get; set; }
        public DbSet<ProductTbl>ProductTbls { get; set; }
        public DbSet<CountryTbl>CountryTbls { get; set; }
        public DbSet<StateTbl>StateTbls { get; set; }
        public DbSet<CityTbl>CityTbls { get; set; }
        public DbSet<CartTbl>CartTbls { get; set; }
    }
}
