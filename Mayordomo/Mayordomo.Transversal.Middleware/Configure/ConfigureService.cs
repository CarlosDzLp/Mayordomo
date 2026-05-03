using Microsoft.AspNetCore.Builder;

namespace Mayordomo.Transversal.Middleware.Configure
{
    public static class ConfigureService
    {
        #region Service
        public static IApplicationBuilder AddTransversalWiddlewareService(this IApplicationBuilder app)
        {
            //app.UseMiddleware<RequestLoggingMiddleware>();
            //app.UseMiddleware<RequestMobileMiddleware>();
            //app.UseMiddleware<LanguageMiddleware>();
            //app.UseMiddleware<ApiVersionMiddleware>();
            return app;
        }
        #endregion
    }
}
