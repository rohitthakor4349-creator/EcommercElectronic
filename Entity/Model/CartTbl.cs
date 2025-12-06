using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Entity.Model
{
    [Table("CartTbl")]
    public class CartTbl
    {
        [Key]

        public int CartId { get; set; }
        public int UniqId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
