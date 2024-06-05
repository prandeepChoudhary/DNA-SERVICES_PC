using System;
using Microsoft.AspNetCore.Http.Extensions;

namespace DNA_SERVICES.Configuration.MIddleware
{
	public class RequestLogger
	{
		private readonly RequestDelegate _next;
		private readonly ILogger _logger;
		public RequestLogger(RequestDelegate next, ILogger logger)
		{
			_next = next;
			_logger = logger;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			if(!context.Request.GetDisplayUrl().Contains("health"))
			{
				_logger.LogTrace("+Request");
				if (string.IsNullOrEmpty(context.Request.Headers["userid"]))
					_logger.LogTrace("Consumer Key:Not available");
				else
					_logger.LogTrace("Called Method: " + context.Request.Path + " | HTTP Verb: " + context.Request.Method +
								" | UserId: " + context.Request.Headers["userid"].ToString() +
								" | Time: " + System.DateTime.Now.ToString("MM/dd/yyyy HH-mm-ss-fff"));

				context.Response.OnStarting(state =>
				{
					var httpContext = (HttpContext)state;
					var responseTime = httpContext.Response.Headers[ResponseTimeHeader.ResponseTimeHeaderName];
					return Task.FromResult(0);
				}, context);
            }

            await _next.Invoke(context);
		}
	}

	public static class RequestResponseLoggerExtensions
	{
		public static IApplicationBuilder UseRequestResponseLogging(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<RequestLogger>();
		}
	}
}

