using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mayordomo.Application.Main.Configure
{
    public static class ConfigureService
    {
        #region Service
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            //services.AddTransient<IVersionApplication, VersionApplication>();
            //services.AddTransient<IUserApplication, UserApplication>();
            //services.AddTransient<IImageApplication, ImageApplication>();
            //services.AddTransient<ICompanyApplication, CompanyApplication>();
            //services.AddTransient<ISuscriptionApplication, SuscriptionApplication>();
            //services.AddTransient<IServiceApplication, ServiceApplication>();
            return services;
        }
        #endregion
    }
}
