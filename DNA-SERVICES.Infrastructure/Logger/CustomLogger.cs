using System;
using Microsoft.AspNetCore.Http;
using Serilog;
namespace DNA_SERVICES.Infrastructure.Logger
{
	public class CustomLogger
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		public CustomLogger(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
        }

		public void LogException(string message)
		{
			var request = _httpContextAccessor.HttpContext.Request;
			Log.Error("Called Method:" + request.Path + " | HTTP verb:" + request.Method + " | UserId:" +
				request.Headers["userid"].ToString() + " | Time:" + System.DateTime.Now.ToString("MM/dd/yyyy HH-mm-ss-fff")
				+ " | Message: " + message);
		}
	}
}

