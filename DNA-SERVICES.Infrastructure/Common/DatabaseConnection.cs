using System;
using Serilog;
using Microsoft.Extensions.Configuration;
namespace DNA_SERVICES.Infrastructure.Common
{
	public class DatabaseConnection
	{
		public string GetConnectionString(IConfiguration configuration)
		{
			string connStr;
			Log.Information($"Processed parameters form jenkins : HOST_URL= {configuration["HOST_URL"]}, SVC_NM={configuration["SVC_NM"]}");
			//gethere full connection string
			connStr = $"Data Source={configuration["HOST_URL"]}";
			return connStr;
		}
	}
}

