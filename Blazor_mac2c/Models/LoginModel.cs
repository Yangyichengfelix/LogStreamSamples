using System.ComponentModel.DataAnnotations;

namespace Blazor_mac2c.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
