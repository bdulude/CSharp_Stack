using System.ComponentModel.DataAnnotations;

namespace Dojo_Survey_Validation.Models
{
    public class Survey
    {
        [Required(ErrorMessage = "Required")]
        [MinLength(2, ErrorMessage = "Must be at least 2 characters.")]
        [MaxLength(20, ErrorMessage = "Must be less than 20 characters.")]
        public string Name {get; set;}

        [Required(ErrorMessage = "Required")]
        public string Location {get; set;}

        [Required(ErrorMessage = "Required")]
        public string Lang {get; set;}

        [MaxLength(20, ErrorMessage = "Must be less than 20 characters.")]
        public string Comment {get; set;}
    }
}