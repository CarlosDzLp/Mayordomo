using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi;

namespace Mayordomo.Transversal.Swagger.Configure
{
    public static class ConfigureService
    {
        #region Service
        public static IServiceCollection AddSwaggerService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(opt =>
            {
                opt.OperationFilter<SwaggerHeaderParameterFilter>();
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Ingrese el token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                opt.AddSecurityRequirement(document => new OpenApiSecurityRequirement
                {
                    [new OpenApiSecuritySchemeReference("bearer", document)] = []
                });


                var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

                foreach (var description in provider.ApiVersionDescriptions)
                {
                    opt.SwaggerDoc(description.GroupName, new OpenApiInfo
                    {
                        Title = $"My API {description.ApiVersion}",
                        Version = description.GroupName
                    });
                }

                opt.DocInclusionPredicate((docName, apiDesc) =>
                {
                    if (!apiDesc.RelativePath.StartsWith("api/"))
                        return false;

                    return apiDesc.GroupName == docName;
                });

            });       
            return services;
        }
        #endregion
    }
}
