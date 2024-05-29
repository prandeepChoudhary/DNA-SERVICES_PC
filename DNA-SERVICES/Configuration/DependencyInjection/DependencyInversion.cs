using System;
using DNA_SERVICES.Application.Interface;
using DNA_SERVICES.Application.Services;
using DNA_SERVICES.Domain.Interfaces.Domain;
using DNA_SERVICES.Domain.Interfaces.Repository;
using DNA_SERVICES.Domain.Services;
using DNA_SERVICES.Infrastructure.Repository;

namespace DNA_SERVICES.Configuration.DependencyInjection
{
	public static class DependencyInversion
	{
		public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddTransient<IFeeScheduleService, FeeScheduleServices>();
			services.AddTransient<IFeeScheduleDomainService, FeeScheduleDomainServices>();
			services.AddTransient<IFeeScheduleRepository, FeeScheduleRepository>();

			return services;
		}
	}
}

