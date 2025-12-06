using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Model
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Please Enter Category")]
        public string? CategoryName { get; set; }

        [Required(ErrorMessage ="Please Select Status")]
        public bool Status { get; set; }
    }
}
