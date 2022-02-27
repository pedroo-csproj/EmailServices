using EmailServices.Models;

namespace EmailServices.Interfaces
{
    public interface IMailServices
    {
        Task SendAsync(MailRequestModel mailRequest, CancellationToken cancellationToken);
        void Send(MailRequestModel mailRequest);
    }
}
