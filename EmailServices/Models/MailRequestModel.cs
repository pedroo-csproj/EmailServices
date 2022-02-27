namespace EmailServices.Models
{
    public class MailRequestModel
    {
        public MailRequestModel(string to, string subject, string body)
        {
            To = to;
            Subject = subject;
            Body = body;
        }

        public string To { get; private set; }
        public string Subject { get; private set; }
        public string Body { get; private set; }
    }
}
