using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Entity.Model
{
    [Table("CategoryTbl")]
    public class CategoryTbl
    {
        [Key]
        public int CategoryId { get; set; }
        public string? Category { get; set; }
        public bool Status { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
