using System.ComponentModel.DataAnnotations;

namespace Mac2sAPI.Dtos.ApiUser
{
    public class UserNameDto
    {
        [Required]
        [EmailAddress]
        public string UserName { get; set; }
    }
}
