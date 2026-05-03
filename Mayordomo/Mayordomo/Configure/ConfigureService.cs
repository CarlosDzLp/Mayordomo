using Mayordomo.Application.Main.Configure;
using Mayordomo.Domain.Core.Configure;
using Mayordomo.Infrastructure.Main.Configure;
using Mayordomo.Transversal.Common.Configure;
using Mayordomo.Transversal.Email.Repository;
using Mayordomo.Transversal.Middleware.Configure;

namespace Mayordomo.Configure
{
    public static class ConfigureService
    {
        public static WebApplication AddServiceConfigure(this IServiceCollection services, WebApplicationBuilder applicationBuilder)
        {
            services.AddControllerExtension(applicationBuilder);
            services.AddApplicationService();
            services.AddDomainService();
            services.AddInfrastructureService(applicationBuilder.Configuration);


            var configurationEmail = applicationBuilder.Configuration.GetSection("EmailSettings");
            applicationBuilder.Services.Configure<EmailSettings>(configurationEmail);
            services.AddTransversalCommonService();
            return applicationBuilder.Build();
        }


        public static IApplicationBuilder AddAppConfigure(this IApplicationBuilder applicationBuilder, IServiceCollection services, WebApplication app)
        {
            // Manejo de errores
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();

            // Swagger
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.RoutePrefix = "swagger"; // 👈 Swagger ya no está en "/"

                var descriptions = app.DescribeApiVersions();
                foreach (var item in descriptions)
                {
                    options.SwaggerEndpoint(
                        $"/swagger/{item.GroupName}/swagger.json",
                        item.GroupName.ToUpperInvariant());
                }
            });

            // Localización y middlewares
            app.UseRequestLocalization();
            app.AddTransversalWiddlewareService();

            app.UseHttpsRedirection();
            app.UseStaticFiles(); // 👈 importante para vistas

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            // Rutas
            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}");

            return app;
        }
    }
}
