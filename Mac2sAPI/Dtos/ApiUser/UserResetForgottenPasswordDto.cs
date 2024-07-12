using System.ComponentModel.DataAnnotations;
namespace Mac2sAPI.Dtos.ApiUser
{
    public class UserResetForgottenPasswordDto : UserNameDto
    {
        [Required]
        public string Token { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PasswordConfirm { get; set; }
    }
}
