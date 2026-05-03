using Microsoft.Extensions.DependencyInjection;

namespace Mayordomo.Transversal.Mapster.Configure
{
    public static class ConfigureService
    {
        #region Service
        public static IServiceCollection AddTransversalMapsterService(this IServiceCollection services)
        {
            //services.AddAutoMapper((e) =>
            //{
            //    e.AddProfile<VersionProfile>();
            //    e.AddProfile<UserProfile>();
            //    e.AddProfile<ResponseProfile>();
            //    e.AddProfile<ImageProfile>();
            //    e.AddProfile<AuthenticateProfile>();
            //    e.AddProfile<CompanyProfile>();
            //    e.AddProfile<SuscriptionProfile>();
            //    e.AddProfile<ServiceProfile>();
            //    e.AddProfile<EmployeeProfile>();
            //});
            return services;
        }
        #endregion
    }
}
