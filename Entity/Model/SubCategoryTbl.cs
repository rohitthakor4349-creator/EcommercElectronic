using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Entity.Model
{
    [Table("SubCategoryTbl")]
    public class SubCategoryTbl
    {
        [Key]

        public int SubCategoryId { get; set; }

        
        public int CategoryId { get; set; }
     
        public string? SubCategory { get; set; }

       
        public bool Status { get; set; }

        public DateTime EntryDate { get; set; }
    }
}
