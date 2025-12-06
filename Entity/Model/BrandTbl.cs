using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Entity.Model
{
    [Table("BrandTbl")]
    public class BrandTbl
    {
        [Key]

        public int BrandId { get; set; }
    
        public string? Brand { get; set; }
        public bool Status { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
