using System;
using Microsoft.AspNetCore.Builder;
using Serilog.Context;

namespace DNA_SERVICES.Configuration.MIddleware
{
	public class RequestIdHeader
	{
		public const string RequestIdHeaderName = "x-glic-request-id";
		private readonly RequestDelegate _next;
		public RequestIdHeader(RequestDelegate next)
		{
			_next = next;
		}
		public async Task InvokeAsync(HttpContext context)
		{
			string correlationId = context.Request.Headers[RequestIdHeaderName].ToString();
			if(string.IsNullOrEmpty(correlationId))
			{
				correlationId = Guid.NewGuid().ToString();
			}

			LogContext.PushProperty("correlationRequestId", correlationId);
			LogContext.PushProperty("Path", context.Request.Path);
			LogContext.PushProperty("Method", context.Request.Method);

			context.Items.TryAdd(RequestIdHeaderName, correlationId);

			context.Response.OnStarting(state => {
				var httpContext = (HttpContext)state;
				httpContext.Response.Headers.TryAdd(RequestIdHeaderName, correlationId);
				return Task.FromResult(0);
			}, context);
			await _next.Invoke(context);
		}
	}

	public static class RequestIdHeaderExtensions
	{
		public static IApplicationBuilder AddRequestHeader(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<RequestIdHeader>();
		}
	}
}

