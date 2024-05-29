using System;
namespace DNA_SERVICES.Contracts.Input.FeeSchedules
{
	public class FeeScheduleInput
	{
        public required string? FeeScheduleName { get; set; }
        public required string? FeeScheduleType { get; set; }
    }
}

