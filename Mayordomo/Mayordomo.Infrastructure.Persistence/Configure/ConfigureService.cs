using Mayordomo.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mayordomo.Infrastructure.Persistence.Configure
{
    public static class ConfigureService
    {
        #region Service
        public static IServiceCollection AddInfrastructurePersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString, action => action.UseNetTopologySuite());
            });
            return services;
        }
        #endregion
    }
}
