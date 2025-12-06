using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Model
{
    public class StateDTO
    {
        public int StateId { get; set; }

        [Required(ErrorMessage = "Please Select Country")]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "Please Enter The State Name")]
        public string? StateName { get; set; }
    }
}
