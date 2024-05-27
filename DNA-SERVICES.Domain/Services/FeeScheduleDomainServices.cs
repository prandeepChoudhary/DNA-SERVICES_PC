using System;
using DNA_SERVICES.Domain.Interfaces.Domain;
using DNA_SERVICES.Domain.Interfaces.Repository;
using DNA_SERVICES.Domain.Models.FeeSchedule.Input;
using DNA_SERVICES.Domain.Models.FeeSchedule.Output;
using Microsoft.Extensions.Logging;

namespace DNA_SERVICES.Domain.Services
{
	public class FeeScheduleDomainServices : IFeeScheduleDomainService
	{
        private readonly IFeeScheduleRepository _iFeeScheduleRepository;
        private readonly ILogger<FeeScheduleDomainServices> _logger;
		public FeeScheduleDomainServices(IFeeScheduleRepository feeScheduleRepository, ILogger<FeeScheduleDomainServices> logger) 
		{
            _iFeeScheduleRepository = feeScheduleRepository;
            _logger = logger;
		}

        public async Task<List<FeeScheduleOutputModel>> GetData(FeeScheduleInputModel feeScheduleInput)
        {
            List<FeeScheduleOutputModel> feeScheduleOutputModels = new();
            try
            {
                _logger.LogDebug("+FeeScheduleDomainServices.GetData");
                feeScheduleOutputModels = await _iFeeScheduleRepository.GetData(feeScheduleInput);
                _logger.LogDebug("-FeeScheduleDomainServices.GetData");
            }
            catch(Exception ex)
            {
                _logger.LogError("Error Logger in Method : GetData, Message: " + ex.Message.ToString());
            }
            return feeScheduleOutputModels;
        }
    }
}

