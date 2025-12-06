using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Model
{
    public class SubCategoryDTO
    {
        public int SubCategoryId { get; set; }

        [Required(ErrorMessage ="Please  Select Categories")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Please Enter Sub-Category")]
        public string? SubCategory { get; set; }

        [Required(ErrorMessage ="Please Select Status")]
        public bool IsActive { get; set; }

        public DateTime EntryDate { get; set; }
    }
}
