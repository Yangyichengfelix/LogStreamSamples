using Microsoft.AspNetCore.Identity;

namespace Mac2sAPI.Data
{
    public class ApiUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
