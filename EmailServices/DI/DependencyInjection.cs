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
            services.Configure<MailSettingsModel>(configuration.GetSection("MailSettings"));

            services.AddTransient<IMailServices, MailServices>();
        }
    }
}
