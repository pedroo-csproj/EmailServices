using EmailServices.Models;

namespace EmailServices.Interfaces
{
    /// <summary>
    /// interface that provides methods for sending email requests
    /// </summary>
    public interface IMailServices
    {
        /// <summary>
        /// send a email as asynchronous
        /// </summary>
        /// <param name="mailRequest">model that contains data to send email</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task SendAsync(MailRequestModel mailRequest, CancellationToken cancellationToken);
        /// <summary>
        /// send a email
        /// </summary>
        /// <param name="mailRequest">model that contains data to send email</param>
        void Send(MailRequestModel mailRequest);
    }
}
