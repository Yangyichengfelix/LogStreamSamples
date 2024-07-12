using Blazor_mac2c.Models;

namespace Blazor_mac2c.Contracts
{
    public interface IAuthenticationRepository
    {
        public Task<bool> Login(LoginModel user);
        public Task Logout();
       // public Task<bool> ForgotPassword(ForgotPasswordModel user);
        //public Task<bool> ResetForgottenPassword(ResetForgottenPasswordModel user);
        public Task<bool> Register(RegisterModel user);

        public Task<bool> ResetPassword(ResetPasswordModel user);
        public Task<bool> ForgotPassword(ForgotPasswordModel user);
        public Task<bool> ResetForgottenPassword(ResetForgottenPasswordModel user);
    }
}
