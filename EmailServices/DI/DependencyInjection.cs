using EmailServices.Implementations;
using EmailServices.Interfaces;
using EmailServices.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmailServices.DI
{
    public static class DependencyInjection
    {
        public static void AddEmailServices(this IServiceCollection services, IConfiguration configuration)
        {
            VerifyMailSettings(configuration);

            services.Configure<MailSettingsModel>(configuration.GetSection("MailSettings"));

            services.AddTransient<IMailServices, MailServices>();
        }

        private static void VerifyMailSettings(IConfiguration configuration)
        {
            if (string.IsNullOrEmpty(configuration.GetSection("MailSettings:UserName").Value))
                throw new Exception("You must configure the MailSettings:UserName");

            if (string.IsNullOrEmpty(configuration.GetSection("MailSettings:From").Value))
                throw new Exception("You must configure the MailSettings:From");

            if (string.IsNullOrEmpty(configuration.GetSection("MailSettings:Password").Value))
                throw new Exception("You must configure the MailSettings:Password");

            if (string.IsNullOrEmpty(configuration.GetSection("MailSettings:Host").Value))
                throw new Exception("You must configure the MailSettings:Host");

            if (string.IsNullOrEmpty(configuration.GetSection("MailSettings:Port").Value))
                throw new Exception("You must configure the MailSettings:Port");
        }
    }
}
