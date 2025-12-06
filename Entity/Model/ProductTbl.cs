using Microsoft.Extensions.FileProviders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Entity.Model
{
    [Table("ProductTbl")]
    public class ProductTbl
    {
        [Key]

        public int ProductId { get; set; }
     
        public int? CategoryId { get; set; }

        
        public int? SubCategoryId { get; set; }

       
        public int? ThirdCategoryId { get; set; }

       
        public int? BrandId { get; set; }

    
        public string? ProductName { get; set; }

        public decimal ProductPrice { get; set; }
        public string? Photo { get; set; }

       
        public string? Description { get; set; }

      
        public bool Status { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
