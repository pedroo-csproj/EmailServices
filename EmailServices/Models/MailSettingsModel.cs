using Microsoft.Extensions.Configuration;

namespace EmailServices.Models
{
    internal class MailSettingsModel
    {
        public MailSettingsModel(IConfiguration configuration) =>
            _configuration = configuration;

        private readonly IConfiguration _configuration;

        public string UserName { get => string.IsNullOrEmpty(_configuration["MailSettings:UserName"]) ? _configuration["EMAIL_USERNAME"] : _configuration["MailSettings:UserName"]; }
        public string From { get => string.IsNullOrEmpty(_configuration["MailSettings:From"]) ? _configuration["EMAIL_FROM"] : _configuration["MailSettings:From"]; }
        public string Password { get => string.IsNullOrEmpty(_configuration["MailSettings:Password"]) ? _configuration["EMAIL_PASSWORD"] : _configuration["MailSettings:Password"]; }
        public string Host { get => string.IsNullOrEmpty(_configuration["MailSettings:Host"]) ? _configuration["EMAIL_HOST"] : _configuration["MailSettings:Host"]; }
        public int Port { get => string.IsNullOrEmpty(_configuration["MailSettings:Port"]) ? Convert.ToInt32(_configuration["EMAIL_PORT"]) : Convert.ToInt32(_configuration["MailSettings:Port"]); }
    }
}
