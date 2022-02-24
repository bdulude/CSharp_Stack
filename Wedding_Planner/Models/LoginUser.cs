using System.ComponentModel.DataAnnotations;

namespace Wedding_Planner.Models
{
    public class LoginUser
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string LoginEmail { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [MinLength(8, ErrorMessage="Password must be 8 characters or longer!")]
        public string LoginPassword { get; set; }
    }
}