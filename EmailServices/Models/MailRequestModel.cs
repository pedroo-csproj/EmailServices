namespace EmailServices.Models
{
    /// <summary>
    /// model that contains data to send email
    /// </summary>
    public class MailRequestModel
    {
        public MailRequestModel(string to, string subject, string body)
        {
            To = to;
            Subject = subject;
            Body = body;
        }

        /// <summary>
        /// address receiving the email
        /// </summary>
        public string To { get; private set; }
        /// <summary>
        /// subject of email
        /// </summary>
        public string Subject { get; private set; }
        /// <summary>
        /// email body, accepts html
        /// </summary>
        public string Body { get; private set; }
    }
}
