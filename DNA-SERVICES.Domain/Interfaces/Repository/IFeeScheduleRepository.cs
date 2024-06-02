using System;
using DNA_SERVICES.Domain.Models.FeeSchedule.Input;
using DNA_SERVICES.Domain.Models.FeeSchedule.Output;

namespace DNA_SERVICES.Domain.Interfaces.Repository
{
	public interface IFeeScheduleRepository
	{
		public Task<List<FeeScheduleOutputModel>> GetData(FeeScheduleInputModel feeScheduleInput);
		public Task<int> update(FeeScheduleInputModel feeScheduleInput);
    }
}

