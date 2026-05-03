using Mayordomo.Transversal.Logging.Main;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace Mayordomo.Transversal.Email.Repository
{
    public class EmailService : IEmailService
    {
        public EmailService(IAppLogger<EmailService> logger, IOptions<EmailSettings> options)
        {
            this.logger = logger;
            _to = options.Value;
            _from = _to.From;

            _smtpClient = new SmtpClient(_to.Host, _to.Port)
            {
                Credentials = new NetworkCredential(_to.User, _to.Password),
                EnableSsl = _to.EnableSsl
            };
        }

        private readonly SmtpClient _smtpClient;
        private readonly string _from;
        private readonly EmailSettings _to;
        private readonly IAppLogger<EmailService> logger;

        public async Task SendEmailAsync(EmailMessage message)
        {
            try
            {
                using var mailMessage = new MailMessage()
                {
                    From = new MailAddress(_from),
                    Subject = message.Subject,
                    Body = message.Body,
                    IsBodyHtml = message.IsHtml
                };

                foreach (var to in message.To)
                    mailMessage.To.Add(to);


                mailMessage.CC.Add(_to.From);

                mailMessage.Bcc.Add(_to.From);

                if (message.Attachments != null)
                {
                    foreach (var attachment in message.Attachments)
                    {
                        var stream = new MemoryStream(attachment.FileContent);
                        mailMessage.Attachments.Add(new Attachment(stream, attachment.FileName));
                    }
                }

                await _smtpClient.SendMailAsync(mailMessage);
            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message, ex);
            }
        }
    }
}
