using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Entity.Model
{
    [Table("CityTbl")]
    public class CityTbl
    {
        [Key]

        public int CityId { get; set; }

       
        public int CountryId { get; set; }

   
        public int StateId { get; set; }

      
        public string? CityName { get; set; }

        public bool Status { get; set; }
    }
}
