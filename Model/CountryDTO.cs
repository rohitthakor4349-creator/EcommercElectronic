using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Model
{
    public class CountryDTO
    {
        public int CountryId { get; set; }

        [Required(ErrorMessage = "Enter the Country Name")]

        public string? CountryName { get; set; }

    }
}
