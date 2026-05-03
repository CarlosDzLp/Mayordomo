using Mayordomo.Helpers;
using Mayordomo.Transversal.Logging.Main;
using Mayordomo.Transversal.Swagger.Configure;
using NLog.Web;

namespace Mayordomo.Configure
{
    public static class ControllerExtension
    {
        public static IServiceCollection AddControllerExtension(this IServiceCollection services, WebApplicationBuilder applicationBuilder)
        {
            var configuration = applicationBuilder.Configuration;
            string connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            LoggerApp.ConfigureNLog(connectionString);
            applicationBuilder.Logging.ClearProviders();
            applicationBuilder.Host.UseNLog();

            services.AddControllersWithViews();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerService(configuration);
            services.AddJwtExtension(configuration);
            services.AddControllers()
                .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
            return services;
        }
    }
}
