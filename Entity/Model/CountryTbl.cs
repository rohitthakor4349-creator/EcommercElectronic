using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Entity.Model
{
    [Table("CountryTbl")]
    public class CountryTbl
    {
        [Key]
        public int CountryId { get; set; }

       
        public string? CountryName { get; set; }

        public bool Status { get; set; }
    }
}
