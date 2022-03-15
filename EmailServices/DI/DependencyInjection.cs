using EmailServices.Implementations;
using EmailServices.Interfaces;
using EmailServices.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmailServices.DI
{
    public static class DependencyInjection
    {
        /// <summary>
        /// make the necessary injections
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddEmailServices(this IServiceCollection services, IConfiguration configuration)
        {
            VerifyMailSettings(configuration);

            services.AddTransient<MailSettingsModel>();

            services.AddTransient<IMailServices, MailServices>();
        }

        private static void VerifyMailSettings(IConfiguration configuration)
        {
            if (string.IsNullOrEmpty(configuration.GetSection("MailSettings:UserName").Value) && string.IsNullOrEmpty(configuration.GetSection("EMAIL_USERNAME").Value))
                throw new Exception("You must configure MailSettings:UserName or EMAIL_USERNAME");

            if (string.IsNullOrEmpty(configuration.GetSection("MailSettings:From").Value) && string.IsNullOrEmpty(configuration.GetSection("EMAIL_FROM").Value))
                throw new Exception("You must configure MailSettings:From or EMAIL_FROM");

            if (string.IsNullOrEmpty(configuration.GetSection("MailSettings:Password").Value) && string.IsNullOrEmpty(configuration.GetSection("EMAIL_PASSWORD").Value))
                throw new Exception("You must configure MailSettings:Password or EMAIL_PASSWORD");

            if (string.IsNullOrEmpty(configuration.GetSection("MailSettings:Host").Value) && string.IsNullOrEmpty(configuration.GetSection("EMAIL_HOST").Value))
                throw new Exception("You must configure MailSettings:Host or EMAIL_HOST");

            if (string.IsNullOrEmpty(configuration.GetSection("MailSettings:Port").Value) && string.IsNullOrEmpty(configuration.GetSection("EMAIL_PORT").Value))
                throw new Exception("You must configure MailSettings:Port or EMAIL_PORT");
        }
    }
}
