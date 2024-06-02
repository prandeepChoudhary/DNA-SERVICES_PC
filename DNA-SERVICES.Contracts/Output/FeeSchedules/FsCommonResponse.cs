using System;
namespace DNA_SERVICES.Contracts.Output.FeeSchedules
{
	public class FsCommonResponse
	{
		public int Id { get; set; }
		public string? Action { get; set; }
		public string? StatusMessage { get; set; }
	}
}

