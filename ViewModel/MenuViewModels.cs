namespace Ecommerce.ViewModel.Menu
{
    public class CategoryMenuVM
    {
        public int CategoryId { get; set; }
        public string? Category { get; set; }
        public List<SubCategoryMenuVM> SubCategories { get; set; }
            = new List<SubCategoryMenuVM>();
    }

    public class SubCategoryMenuVM
    {
        public int SubCategoryId { get; set; }
        public string? SubCategory { get; set; }
        public List<ThirdCategoryMenuVM> ThirdCategories { get; set; }
            = new List<ThirdCategoryMenuVM>();
    }

    public class ThirdCategoryMenuVM
    {
        public int ThirdCategoryId { get; set; }
        public string? ThirdCategory { get; set; }
    }
}
