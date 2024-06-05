using System;
using DNA_SERVICES.Configuration.MIddleware;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DNA_SERVICES.Configuration.Documentation
{
    public class ResponseTimeOpertionFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<OpenApiParameter>();
            }
            operation.Parameters.Add(
                new OpenApiParameter
                {
                    Description = "Measure the total; request time in millisecounds",
                    In = ParameterLocation.Header,
                    Name = RequestIdHeader.RequestIdHeaderName,
                    Required = false,
                    Style = ParameterStyle.Form,
                    Schema = new OpenApiSchema
                    {
                        Type = "string"
                    }
                });
        }
    }
}

