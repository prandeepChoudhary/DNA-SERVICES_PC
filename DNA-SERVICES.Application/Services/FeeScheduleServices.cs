﻿using System;
using AutoMapper;
using DNA_SERVICES.Application.Interface;
using DNA_SERVICES.Contracts.Input.FeeSchedules;
using DNA_SERVICES.Contracts.Output.FeeSchedules;
using DNA_SERVICES.Domain.Interfaces.Domain;
using DNA_SERVICES.Domain.Models.FeeSchedule.Input;
using DNA_SERVICES.Domain.Models.FeeSchedule.Output;
using Microsoft.Extensions.Logging;

namespace DNA_SERVICES.Application.Services
{
	public class FeeScheduleServices : IFeeScheduleService
    {
		readonly IFeeScheduleDomainService _feeScheduleDomainService;
		readonly ILogger<FeeScheduleServices> _logger;
		private readonly IMapper _mapper;
		public FeeScheduleServices(IFeeScheduleDomainService feeScheduleDomainService, ILogger<FeeScheduleServices> logger,
			IMapper mapper)
		{
			_feeScheduleDomainService = feeScheduleDomainService;
			_logger = logger;
			_mapper = mapper;
		}

        public async Task<List<FeeScheduleOutput>> GetData(FeeScheduleInput feeScheduleInput)
		{
			List<FeeScheduleOutput> lst = new();
			try
			{
				_logger.LogInformation("FsServices.GetData+");
				var result = await _feeScheduleDomainService.GetData(_mapper.Map<FeeScheduleInput, FeeScheduleInputModel>(feeScheduleInput));
				lst = _mapper.Map<List<FeeScheduleOutputModel>, List<FeeScheduleOutput>>(result);
				_logger.LogInformation("FsServices.GetData-");
            }
            catch (Exception ex)
			{
                _logger.LogError("Log Error in FsServices.GetData, Message: " + ex.Message);
                lst = new List<FeeScheduleOutput>();
			}
			return lst;
		}

		public async Task<FsCommonResponse> update(FeeScheduleInput feeScheduleInput)
		{
			FsCommonResponse fsCommonResponse = new FsCommonResponse();
			int response = 0;
			try
			{
                _logger.LogInformation("FsServices.update+");
				response = await _feeScheduleDomainService.update(_mapper.Map<FeeScheduleInput, FeeScheduleInputModel>(feeScheduleInput));
				fsCommonResponse.Id = response;
				fsCommonResponse.Action = "Update Fee Schedule";
				if(response == 1)
					fsCommonResponse.StatusMessage = "Successfull";
				else
					fsCommonResponse.StatusMessage = "failure";
                _logger.LogInformation("FsServices.update-");
            }
			catch(Exception ex)
			{
                _logger.LogError("Log Error in FsServices.update, Message: " + ex.Message);
            }
			return fsCommonResponse;
		}
    }
}

