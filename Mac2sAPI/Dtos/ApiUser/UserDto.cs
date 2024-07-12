using System.ComponentModel.DataAnnotations;

namespace Mac2sAPI.Dtos.ApiUser
{
    public class UserDto:UserLoginDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
