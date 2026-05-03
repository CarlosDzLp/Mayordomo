using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Mayordomo.Transversal.Swagger.Configure
{
    public class SwaggerHeaderParameterFilter : IOperationFilter
    {
        #region Filter
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<IOpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter()
            {
                Name = "Api-Version",
                In = ParameterLocation.Header,
                Required = true
            });
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Accept-Language",
                In = ParameterLocation.Header,
                Required = true
            });
        }
        #endregion
    }
}
