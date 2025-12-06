using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Model
{
    public class ThirdCategoryDTO
    {
        public int ThirdCategoryId { get; set; }
        [Required(ErrorMessage ="Please Select Category")]
        public int? CategoryId { get; set; }

        [Required(ErrorMessage = "Please Select Sub-Category")]
        public int? SubCategoryId { get; set; }

        [Required(ErrorMessage ="Please Enter Third-Category")]
        public string? ThirdCategory { get; set; }

        [Required(ErrorMessage = "Please Select Status")]
        public bool IsActive { get; set; }

        public DateTime EntryDate { get; set; }
    }
}
