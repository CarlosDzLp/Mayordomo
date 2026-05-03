using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace Mayordomo.Transversal.Resources.Configure
{
    public static class ConfigureService
    {
        #region Service
        public static IServiceCollection AddTransversalResourceService(this IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "");
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[] { "en-US", "es-MX" }
                    .Select(c => new CultureInfo(c)).ToList();

                options.DefaultRequestCulture = new RequestCulture("es-MX");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
            return services;
        }
        #endregion
    }
}
