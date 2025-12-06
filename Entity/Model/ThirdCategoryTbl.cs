using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Entity.Model
{
    [Table("ThirdCategoryTbl")]
    public class ThirdCategoryTbl
    {
        [Key]

        public int ThirdCategoryId { get; set; }
 
        public int? CategoryId { get; set; }

       
        public int? SubCategoryId { get; set; }

      
        public string? ThirdCategory { get; set; }

        
        public bool Status { get; set; }

        public DateTime EntryDate { get; set; }
    }
}
