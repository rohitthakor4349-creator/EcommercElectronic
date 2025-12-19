using Microsoft.Extensions.FileProviders;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Model
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage =("Please Select CategoryName"))]
        public int? CategoryId { get; set; }

        [Required(ErrorMessage =("Please Select Sub-Category"))]
        public int? SubCategoryId { get; set; }

        [Required(ErrorMessage = ("Please Select Third-Category"))]
        public int? ThirdCategoryId { get; set; }

        [Required(ErrorMessage =("Please Select BrandName"))]
        
        public int? BrandId { get; set; }

        [Required(ErrorMessage =("Please Enetr ProductName"))]
        public string? ProductName { get; set; }

        [Required(ErrorMessage = ("Please Enetr Price"))]
        public decimal ProductPrice { get; set; }

        [Required(ErrorMessage =("Plese Upload Image"))]
        public string? Photo { get; set; }
        public IFormFile? ImgUpload { get; set; }

        [Required(ErrorMessage =("Please Enter Description"))]
        public string? Description { get; set; }

        [Required(ErrorMessage = ("Please Select Statsu"))]
        public bool Status { get; set; }
        public DateTime EntryDate { get; set; }

    }
}
