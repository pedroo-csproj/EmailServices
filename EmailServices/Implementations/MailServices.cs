using EmailServices.Interfaces;
using EmailServices.Models;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace EmailServices.Implementations
{
    internal class MailServices : IMailServices
    {
        public MailServices(IOptions<MailSettingsModel> mailSettings) =>
            _mailSettings = mailSettings.Value;

        private readonly MailSettingsModel _mailSettings;

        public async Task SendAsync(MailRequestModel mailRequest, CancellationToken cancellationToken)
        {
            var client = BuildSmtpClient(_mailSettings.Host, _mailSettings.Port, _mailSettings.UserName, _mailSettings.Password);

            var mailMessage = BuildMailMessage(_mailSettings.From, mailRequest.To, mailRequest.Subject, mailRequest.Body);

            await client.SendMailAsync(mailMessage, cancellationToken);
        }

        public void Send(MailRequestModel mailRequest)
        {
            var client = BuildSmtpClient(_mailSettings.Host, _mailSettings.Port, _mailSettings.UserName, _mailSettings.Password);

            var mailMessage = BuildMailMessage(_mailSettings.From, mailRequest.To, mailRequest.Subject, mailRequest.Body);

            client.Send(mailMessage);
        }

        private static SmtpClient BuildSmtpClient(string host, int port, string userName, string password) =>
            new(host, port)
            {
                Credentials = new NetworkCredential(userName, password),
                EnableSsl = true
            };

        private static MailMessage BuildMailMessage(string from, string to, string subject, string body) =>
            new(from, to)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
    }
}
