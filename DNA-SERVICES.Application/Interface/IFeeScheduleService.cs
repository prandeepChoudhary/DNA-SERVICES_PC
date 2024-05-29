using System;
using DNA_SERVICES.Contracts.Input.FeeSchedules;
using DNA_SERVICES.Contracts.Output.FeeSchedules;

namespace DNA_SERVICES.Application.Interface
{
	public interface IFeeScheduleService
	{
        public Task<List<FeeScheduleOutput>> GetData(FeeScheduleInput feeScheduleInput);
    }
}

