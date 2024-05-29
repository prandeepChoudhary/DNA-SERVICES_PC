using System;
namespace DNA_SERVICES.Contracts.Output.FeeSchedules
{
	public class FeeScheduleOutput
	{
        public int FeeScheduleId { get; set; }
        public string? FeeScheduleName { get; set; }
        public string? FeeScheduleType { get; set; }
    }
}

