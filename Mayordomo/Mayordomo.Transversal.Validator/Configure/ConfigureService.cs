using FluentValidation;
using Mayordomo.Transversal.Validator.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Mayordomo.Transversal.Validator.Configure
{
    public static class ConfigureService
    {
        #region Service
        public static IServiceCollection AddTransversalValidatorService(this IServiceCollection services)
        {
            //services.AddScoped<IValidator<CreateAccountApplicationDto>, CreateAccountValidator>();
            //services.AddScoped<IValidator<ResetPasswordUserApplicationDto>, ResetPasswordUserValidator>();
            //services.AddScoped<IValidator<UpdateNotificationUserApplicationDto>, UpdateNotificationUserValidator>();
            //services.AddScoped<IValidator<AddImageUserApplicationDto>, AddImageUserValidator>();
            //services.AddScoped<IValidator<UpdateUserApplicationDto>, UpdateUserValidator>();
            //services.AddScoped<IValidator<AuthenticateApplicationDto>, AuthenticationValidator>();
            //services.AddScoped<IValidator<RefreshTokenApplicationDto>, RefreshTokenValidator>();
            //services.AddScoped<IValidator<SuscribeApplicationDto>, SuscribeValidator>();
            //services.AddScoped<IValidator<AddServiceApplicationDto>, ServiceValidator>();
            services.AddSingleton<IValidator<object>, GenericValueValidator>();
            return services;
        }
        #endregion
    }
}
