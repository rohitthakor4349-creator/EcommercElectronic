using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Model
{
    public class BrandDTO 
    {
        public int BrandId { get; set; }
        [Required(ErrorMessage =("Please Enter BrandName"))]
        public string? Brand { get; set; }


        [Required(ErrorMessage = ("Please Select Statsu"))]
        public bool IsActive { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
