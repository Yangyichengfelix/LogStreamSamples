using System.ComponentModel.DataAnnotations;

namespace Mac2sAPI.Dtos.ApiUser
{
    public class UserLoginDto
    {
        [Required]
        [EmailAddress]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
