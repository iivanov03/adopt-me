namespace AdoptMe.Web.Infrastructure.EmailSender
{
    using System.Threading.Tasks;

    using AdoptMe.Web.Infrastructure.EmailSender.EmailViewModels;

    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);

        Task SendEmailToUsAsync(EmailSendToUsModel viewEmailModel);
    }
}
