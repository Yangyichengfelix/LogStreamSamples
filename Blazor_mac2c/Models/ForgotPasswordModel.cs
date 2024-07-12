using System.ComponentModel.DataAnnotations;
namespace Blazor_mac2c.Models
{
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string UserName { get; set; }
    }
}
