using System;
using AutoMapper;
using DNA_SERVICES.Contracts.Input.FeeSchedules;
using DNA_SERVICES.Contracts.Output.FeeSchedules;
using DNA_SERVICES.Domain.Models.FeeSchedule.Input;
using DNA_SERVICES.Domain.Models.FeeSchedule.Output;

namespace DNA_SERVICES.Application.Helper
{
	public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<FeeScheduleInputModel, FeeScheduleInput>();
            CreateMap<FeeScheduleOutputModel, FeeScheduleOutput>();

            CreateMap<FeeScheduleInput, FeeScheduleInputModel>();
            CreateMap<FeeScheduleOutput, FeeScheduleOutputModel>();
        }
    }
}

