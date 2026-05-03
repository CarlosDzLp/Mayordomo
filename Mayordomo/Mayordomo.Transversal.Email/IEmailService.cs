using Mayordomo.Transversal.Email.Repository;

namespace Mayordomo.Transversal.Email
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailMessage message);
    }
}
