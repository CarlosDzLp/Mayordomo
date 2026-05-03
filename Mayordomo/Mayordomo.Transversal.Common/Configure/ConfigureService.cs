using Mayordomo.Transversal.Common.Helpers;
using Mayordomo.Transversal.Common.Interfaces;
using Mayordomo.Transversal.Common.Main;
using Mayordomo.Transversal.Email;
using Mayordomo.Transversal.Email.Repository;
using Mayordomo.Transversal.Logging.Main;
using Mayordomo.Transversal.Mapster.Configure;
using Mayordomo.Transversal.Resources.Configure;
using Mayordomo.Transversal.Validator.Configure;
using Microsoft.Extensions.DependencyInjection;

namespace Mayordomo.Transversal.Common.Configure
{
    public static class ConfigureService
    {
        #region Service
        public static IServiceCollection AddTransversalCommonService(this IServiceCollection services)
        {
            services.AddTransient<IPasswordHash, PasswordHash>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IGenerateCode, GenerateCode>();
            services.AddTransient<IFileStorageService, FileStorageService>();
            services.AddTransient<IEncryptService, EncryptService>();
            services.AddTransient(typeof(IAppLogger<>), typeof(AppLogger<>));
            services.AddTransient<IPathConstans, PathConstans>();
            services.AddTransversalMapsterService();
            services.AddTransversalResourceService();
            services.AddTransversalValidatorService();
            return services;
        }
        #endregion
    }
}
