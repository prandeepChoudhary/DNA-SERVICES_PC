using System;
using DNA_SERVICES.Configuration.MIddleware;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DNA_SERVICES.Configuration.Documentation
{
    public class RequestOperationFilter : IOperationFilter
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
                    Description = "Used to uniquely identify the HTTP request. This ID is used to correlate the HTTP request between a client and server.",
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

