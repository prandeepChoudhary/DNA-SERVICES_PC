using System;
using System.Diagnostics;

namespace DNA_SERVICES.Configuration.MIddleware
{
	public class ResponseTimeHeader
	{
        public const string ResponseTimeHeaderName = "x-glic-response-time";
        private readonly RequestDelegate _next;

        public ResponseTimeHeader(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            context.Response.OnStarting(state =>
            {
                var httpContext = (HttpContext)state;
                httpContext.Response.Headers.TryAdd(ResponseTimeHeaderName, $"{stopWatch.ElapsedMilliseconds}ms");
                return Task.FromResult(0);
            }, context);
            await _next.Invoke(context);
        }
    }
    public static class ResponseTimeHeaderExtensions
    {
        public static IApplicationBuilder AddResponseTimeHeader(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ResponseTimeHeader>();
        }
    }
}

