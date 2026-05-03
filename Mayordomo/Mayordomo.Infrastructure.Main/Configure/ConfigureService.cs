using Mayordomo.Infrastructure.Main.Repository;
using Mayordomo.Infrastructure.Persistence.Configure;
using Mayordomo.Infrastructure.Repository.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mayordomo.Infrastructure.Main.Configure
{
    public static class ConfigureService
    {
        #region Service
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            //services.AddTransient<IVersionInfrastructure, VersionInfraestructure>();
            //services.AddTransient<IUserInfrastructure, UserInfraestructure>();
            //services.AddTransient<IRefreshTokenInfraestructure, RefreshTokenInfraestructure>();
            //services.AddTransient<IGenerateCodeInfrastructure, GenerateCodeInfrastructure>();
            //services.AddTransient<IRolesInfrastructure, RolesInfrastructure>();
            //services.AddTransient<ICompanyInfrastructure, CompanyInfrastructure>();
            //services.AddTransient<IImageCompanyInfrastructure, ImageCompanyInfrastructure>();
            //services.AddTransient<ISuscriptionInfrastructure, SuscriptionInfrastructure>();
            //services.AddTransient<ISuscriptionUserInfrastructure, SuscriptionUserInfrastructure>();
            //services.AddTransient<IServiceInfrastructure, ServiceInfrastructure>();
            //services.AddTransient<IServiceImageInfrastructure, ServiceImageInfrastructure>();
            services.AddInfrastructurePersistenceService(configuration);
            return services;
        }
        #endregion
    }
}
