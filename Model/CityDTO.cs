using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Model
{
    public class CityDTO
    {
        public int CityId { get; set; }

        [Required(ErrorMessage = "Please Select Contry")]
        public int? CounrtyId { get; set; }

        [Required(ErrorMessage = "Please Select State")]
        public int? StateId { get; set; }

        [Required(ErrorMessage = "Please Enter The CityName")]
        public string? CityName { get; set; }
    }
}
