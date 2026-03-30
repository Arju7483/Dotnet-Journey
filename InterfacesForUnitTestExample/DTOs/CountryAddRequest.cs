using System;
using System.ComponentModel.DataAnnotations;
namespace UnitTestServices.DTOs
{
    public class CountryAddRequest
    {
        [Required(ErrorMessage ="Country name is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage ="Country length should be fall within the range")]
        public string CountryName { get; set; } = string.Empty;
    }
}
