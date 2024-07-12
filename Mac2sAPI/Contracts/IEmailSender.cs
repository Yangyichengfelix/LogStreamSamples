using Mac2sAPI.MailHelper;
namespace Mac2sAPI.Contracts
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
        Task SendEmailAsync(Message message);
    }
}
