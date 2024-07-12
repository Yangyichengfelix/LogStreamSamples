using System.ComponentModel.DataAnnotations;

namespace Mac2sAPI.Dtos.ApiUser
{
    public class UserResetPasswordDto:UserLoginDto
    {


        [Required]
        public string NewPassword { get; set; }
        [Required]
        public string NewPasswordConfirm { get; set; }
    }
}
