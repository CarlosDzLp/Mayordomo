using Microsoft.Extensions.DependencyInjection;

namespace Mayordomo.Domain.Core.Configure
{
    public static class ConfigureService
    {
        #region Service
        public static IServiceCollection AddDomainService(this IServiceCollection services)
        {
            //services.AddTransient<IVersionDomain, VersionDomain>();
            //services.AddTransient<IUserDomain, UserDomain>();
            //services.AddTransient<IImageDomain, ImageDomain>();
            //services.AddTransient<IAuthenticationService, AuthenticationService>();
            //services.AddTransient<ICompanyDomain, CompanyDomain>();
            //services.AddTransient<ISuscriptionDomain, SuscriptionDomain>();
            //services.AddTransient<IServiceDomain, ServiceDomain>();
            return services;
        }
        #endregion
    }
}
