using System;
namespace DNA_SERVICES.Contracts.Common
{
	public class StatusModel
	{
		public int StatusCode { get; set; }
		public string? Action { get; set; }
		public string? StatusMessage { get; set; }
	}
}

