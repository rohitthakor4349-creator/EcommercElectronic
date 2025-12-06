using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Entity.Model
{
    [Table("StateTbl")]
    public class StateTbl
    {
        [Key]
        public int StateId { get; set; }

       
        public int CountryId { get; set; }

       
        public string? StateName { get; set; }

        public bool Statsu { get; set; }
    }
}
